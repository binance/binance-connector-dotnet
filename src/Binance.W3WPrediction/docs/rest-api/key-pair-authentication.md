# Key Pair Based Authentication

The REST API supports key pair-based authentication for secure communication. You can use `RSA` or `Ed25519` keys for signing requests, given as PEM text (`PrivateKeyPem`) or as the path of a PEM file (`PrivateKeyFile`). Without a private key, `ApiSecret` signs with HMAC-SHA256.

```csharp
using Binance.Common;
using Binance.W3WPrediction.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    PrivateKeyFile = "/path/to/private-key.pem",
    PrivateKeyPassphrase = "your-passphrase", // only if the key is encrypted
};
using var client = W3WPredictionRestApi.Production(config);

var response = await client.ListPredictionCategoriesAsync();

Console.WriteLine(W3WPredictionRestApiJson.ToJson(response.Data()));
```

`config.ToString()` never prints the key, the secret, the private key or the passphrase.
