# Key Pair Based Authentication

The streams of this product are signed. You can sign the connections with an `RSA` or `Ed25519` key instead of `ApiSecret`, given as PEM text (`PrivateKeyPem`) or as the path of a PEM file (`PrivateKeyFile`).

```csharp
using Binance.Common;
using Binance.W3WPrediction.WebSocketStreams;

var config = new WebSocketStreamsConfig
{
    ApiKey = "your-api-key",
    PrivateKeyFile = "/path/to/private-key.pem",
    PrivateKeyPassphrase = "your-passphrase", // only if the key is encrypted
};
var client = W3WPredictionWebSocketStreams.Production(config);
await using var connection = await client.ConnectAsync();

using var subscription = connection.BatchClaimPartiallySucceeded();

using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
try
{
    await foreach (var e in subscription.Events.ReadAllAsync(cts.Token))
        Console.WriteLine(W3WPredictionWebSocketStreamsJson.ToJson(e));
}
catch (OperationCanceledException)
{
}
```
