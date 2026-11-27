# Custom CA Certificates and Certificate Pinning

To trust a private CA, set `CaFile` or `CaPem` (added to the system store; `CaOnly = true` trusts only them). To enhance security, you can pin a certificate with `ServerCertificateValidator`: it is called for every certificate of the chain with its depth (`0` is the server certificate) and whether the built-in checks passed (`preverified`), and it returns `true` to accept the certificate. This ensures the client only communicates with servers using specific certificates. An exception thrown by the validator rejects the certificate.

```csharp
using Binance.Common;
using Binance.MarginTrading.RestApi;
using Binance.MarginTrading.WebSocketStreams;

var config = new WebSocketStreamsConfig
{
    CaFile = "/path/to/private-ca.pem",
    ServerCertificateValidator = (certificate, depth, preverified) =>
        depth != 0 ? preverified : certificate.GetCertHashString(System.Security.Cryptography.HashAlgorithmName.SHA256) == "<SHA-256 of the server certificate>",
};
var client = MarginTradingWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

using var rest = MarginTradingRestApi.Production(new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
});
// Keep the listen key open with KeepaliveUserDataStreamAsync at least every 60 minutes.
var listenKey = (await rest.StartUserDataStreamAsync()).Data()!.ListenKey!;

using var riskData = connection.RiskData(listenKey);

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
try
{
    await foreach (var e in riskData.Events.ReadAllAsync(cts.Token))
        Console.WriteLine(MarginTradingWebSocketStreamsJson.ToJson(e));
}
catch (OperationCanceledException)
{
}
```
