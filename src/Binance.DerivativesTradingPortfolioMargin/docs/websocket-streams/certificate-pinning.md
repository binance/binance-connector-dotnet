# Custom CA Certificates and Certificate Pinning

To trust a private CA, set `CaFile` or `CaPem` (added to the system store; `CaOnly = true` trusts only them). To enhance security, you can pin a certificate with `ServerCertificateValidator`: it is called for every certificate of the chain with its depth (`0` is the server certificate) and whether the built-in checks passed (`preverified`), and it returns `true` to accept the certificate. This ensures the client only communicates with servers using specific certificates. An exception thrown by the validator rejects the certificate.

```csharp
using Binance.Common;
using Binance.DerivativesTradingPortfolioMargin.RestApi;
using Binance.DerivativesTradingPortfolioMargin.WebSocketStreams;

var config = new WebSocketStreamsConfig
{
    CaFile = "/path/to/private-ca.pem",
    ServerCertificateValidator = (certificate, depth, preverified) =>
        depth != 0 ? preverified : certificate.GetCertHashString(System.Security.Cryptography.HashAlgorithmName.SHA256) == "<SHA-256 of the server certificate>",
};
var client = DerivativesTradingPortfolioMarginWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

using var rest = DerivativesTradingPortfolioMarginRestApi.Production(new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
});
// Keep the listen key open with KeepaliveUserDataStreamAsync at least every 60 minutes.
var listenKey = (await rest.StartUserDataStreamAsync()).Data()!.ListenKey!;

using var userData = connection.UserData(listenKey);

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
try
{
    await foreach (var e in userData.Events.ReadAllAsync(cts.Token))
        Console.WriteLine(DerivativesTradingPortfolioMarginWebSocketStreamsJson.ToJson(e));
}
catch (OperationCanceledException)
{
}
```
