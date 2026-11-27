# Custom CA Certificates and Certificate Pinning

To trust a private CA, set `CaFile` or `CaPem` (added to the system store; `CaOnly = true` trusts only them). To enhance security, you can pin a certificate with `ServerCertificateValidator`: it is called for every certificate of the chain with its depth (`0` is the server certificate) and whether the built-in checks passed (`preverified`), and it returns `true` to accept the certificate. This ensures the client only communicates with servers using specific certificates. An exception thrown by the validator rejects the certificate.

```csharp
using Binance.Common;
using Binance.StockOptions.WebSocketStreams;

var config = new WebSocketStreamsConfig
{
    CaFile = "/path/to/private-ca.pem",
    ServerCertificateValidator = (certificate, depth, preverified) =>
        depth != 0 ? preverified : certificate.GetCertHashString(System.Security.Cryptography.HashAlgorithmName.SHA256) == "<SHA-256 of the server certificate>",
};
var client = StockOptionsWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

using var subscription = connection.OrderReportV2Stream(new()
{
    ListenKey = "3f9a1c2e-7b4d-4e8a-9c61-0d2f5b7e8a13",
});

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
try
{
    await foreach (var e in subscription.Events.ReadAllAsync(cts.Token))
        Console.WriteLine(StockOptionsWebSocketStreamsJson.ToJson(e));
}
catch (OperationCanceledException)
{
}
```
