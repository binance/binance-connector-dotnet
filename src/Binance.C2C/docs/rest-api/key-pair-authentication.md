# Key Pair Based Authentication

The REST API supports key pair-based authentication for secure communication. You can use `RSA` or `Ed25519` keys for signing requests, given as PEM text (`PrivateKeyPem`) or as the path of a PEM file (`PrivateKeyFile`). Without a private key, `ApiSecret` signs with HMAC-SHA256.

```csharp
using Binance.Common;
using Binance.C2C.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    PrivateKeyFile = "/path/to/private-key.pem",
    PrivateKeyPassphrase = "your-passphrase", // only if the key is encrypted
};
using var client = C2CRestApi.Production(config);

var response = await client.GetC2CTradeHistoryAsync();

Console.WriteLine(C2CRestApiJson.ToJson(response.Data()));
```

`config.ToString()` never prints the key, the secret, the private key or the passphrase.
