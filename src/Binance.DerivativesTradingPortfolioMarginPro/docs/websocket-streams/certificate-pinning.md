# Custom CA Certificates and Certificate Pinning

To trust a private CA, set `CaFile` or `CaPem` (added to the system store; `CaOnly = true` trusts only them). To enhance security, you can pin a certificate with `ServerCertificateValidator`: it is called for every certificate of the chain with its depth (`0` is the server certificate) and whether the built-in checks passed (`preverified`), and it returns `true` to accept the certificate. This ensures the client only communicates with servers using specific certificates. An exception thrown by the validator rejects the certificate.

```csharp
using Binance.Common;
using Binance.DerivativesTradingPortfolioMarginPro.WebSocketStreams;

var config = new WebSocketStreamsConfig
{
    CaFile = "/path/to/private-ca.pem",
    ServerCertificateValidator = (certificate, depth, preverified) =>
        depth != 0 ? preverified : certificate.GetCertHashString(System.Security.Cryptography.HashAlgorithmName.SHA256) == "<SHA-256 of the server certificate>",
};
var client = DerivativesTradingPortfolioMarginProWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

var listenKey = "your-listen-key"; // from StartUserDataStreamAsync of Binance.DerivativesTradingPortfolioMargin

using var userData = connection.UserData(listenKey);

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
try
{
    await foreach (var e in userData.Events.ReadAllAsync(cts.Token))
        Console.WriteLine(DerivativesTradingPortfolioMarginProWebSocketStreamsJson.ToJson(e));
}
catch (OperationCanceledException)
{
}
```
