# Tests

`tests/Binance.<Product>.Tests/` has a test for every operation, WebSocket API request and stream of a connector, plus a test that decodes an instance
of every model. They are maintained together with the connector (see [Contributing](../README.md#contributing)); the test support they
share lives in [`tests/Binance.Common.Tests/Support`](./Binance.Common.Tests/Support).

Each test runs the client against a loopback server. The response is the example documented for the API, decoded into the typed
model and compared with the example: every field the model declares must match. A field that the example has and the model lacks is not a
failure: the test prints a warning (the API documentation is incomplete, not the client). Operations without an example are checked on the
request side only (path, query, body and signature).

For each operation there is also a test that sets every parameter, required and optional, and checks that each reaches the server as the
expected text, and (REST and WebSocket API) a test in which the server answers a 400 with a Binance error and the typed exception is
checked (`BinanceBadRequestException`, or `BinanceWebSocketResponseException` for the WebSocket API, with the HTTP status and the error code).
A missing required parameter is a compile error, so it has no test.

```bash
dotnet test Binance.slnx                                  # everything
dotnet test tests/Binance.Spot.Tests                      # one connector
dotnet test tests/Binance.Common.Tests                    # the shared library
```

The tests marked `Category=Native` load the platform library of `Binance.Common`; the ones that do not can be selected with
`--filter "Category!=Native"`. See [`src/Binance.Common/README.md`](../src/Binance.Common/README.md#supported-platforms).
