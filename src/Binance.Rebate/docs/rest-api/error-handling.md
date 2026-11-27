# Error Handling

The REST API provides detailed error types to help you handle issues effectively. Every error derives from `BinanceException`:

- `BinanceBadRequestException`: Invalid request (HTTP 400).
- `BinanceUnauthorizedException`: Missing or invalid authentication credentials (HTTP 401).
- `BinanceForbiddenException`: Access to the requested resource is forbidden (HTTP 403).
- `BinanceNotFoundException`: Resource not found (HTTP 404).
- `BinanceConflictException`: The request conflicts with the current state of the resource (HTTP 409).
- `BinanceRateLimitBanException`: IP address banned for exceeding rate limits (HTTP 418).
- `BinanceTooManyRequestsException`: Rate limit exceeded (HTTP 429).
- `BinanceServerException`: Internal server error (HTTP 5xx).
- `BinanceNetworkException`: Issues with network connectivity; `BinanceTimeoutException` is an attempt that took longer than `Timeout`.
- `BinanceClientException`: General client error (unexpected status, malformed response).
- `BinanceConfigException`: Invalid configuration or request.
- `BinanceCancelledException`: The operation was cancelled (for example the client was disposed).

```csharp
using Binance.Common;
using Binance.Rebate.RestApi;

using var client = RebateRestApi.Production(new RestApiConfig
{
    ApiKey = "your-api-key",
    ApiSecret = "your-api-secret",
});
try
{
    var response = await client.GetSpotRebateHistoryRecordsAsync();
}
catch (BinanceTooManyRequestsException e)
{
    await Task.Delay(e.RetryAfter ?? TimeSpan.FromSeconds(1));
}
catch (BinanceApiException e)
{
    Console.WriteLine($"{e.HttpStatus} {e.Code} {e.Message}");
}
catch (BinanceNetworkException e) when (!e.RequestSent)
{
    // The request never reached the server: it is safe to send it again.
}
```

`BinanceException` carries `Kind`, `HttpStatus`, `Code` (the Binance error code), `RetryAfter` (REST 418 and 429), `RetryAt` (WebSocket API), `TransportCode`, `TransportCategory` and `RequestSent`, for a REST error the response that caused it (`Body`, `Headers` and `RateLimits`), and for a WebSocket API error its `WebSocketRateLimits` and `ErrorData` (the `error.data` of the answer). Cancelling a `CancellationToken` cancels the request in flight and throws `OperationCanceledException`.

If you need another endpoint, create the client from a configuration: `new RebateRestApi(new RestApiConfig { BasePath = "https://..." })`. The default is `RebateRestApi.ProductionUrl`.
