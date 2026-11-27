# Custom CA Certificates and Certificate Pinning

To trust a private CA, set `CaFile` or `CaPem` (added to the system store; `CaOnly = true` trusts only them). To enhance security, you can pin a certificate with `ServerCertificateValidator`: it is called for every certificate of the chain with its depth (`0` is the server certificate) and whether the built-in checks passed (`preverified`), and it returns `true` to accept the certificate. This ensures the client only communicates with servers using specific certificates. An exception thrown by the validator rejects the certificate.

```csharp
using Binance.Common;
using Binance.Rebate.RestApi;

var config = new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
    CaFile = "/path/to/private-ca.pem",
    ServerCertificateValidator = (certificate, depth, preverified) =>
        depth != 0 ? preverified : certificate.GetCertHashString(System.Security.Cryptography.HashAlgorithmName.SHA256) == "<SHA-256 of the server certificate>",
};
using var client = RebateRestApi.Production(config);

var response = await client.GetSpotRebateHistoryRecordsAsync();

Console.WriteLine(RebateRestApiJson.ToJson(response.Data()));
```
