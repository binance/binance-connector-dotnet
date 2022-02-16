# Binance Public API Connector DotNET

[![[Nuget]](https://img.shields.io/nuget/v/Binance.Spot)](https://www.nuget.org/packages/Binance.Spot)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

This is a lightweight library that works as a connector to [Binance public API](https://github.com/binance/binance-spot-api-docs)

- Supported APIs:
    - `/api/*`
    - `/sapi/*`
    - Spot Websocket Market Stream
    - Spot User Data Stream
- Test cases and examples
- Customizable base URL, request timeout and HTTP proxy
- Response Metadata


## Installation

```bash
dotnet add package Binance.Spot
```

## RESTful APIs

Usage example
```csharp
using System;
using System.Threading.Tasks;
using Binance.Spot;

class Program
{
    static async Task Main(string[] args)
    {
        Wallet wallet = new Wallet();

        string status = await wallet.SystemStatus();

        Console.WriteLine(status);
    }
}
```
Please find more  examples folder to check for more endpoints.

## Websocket

```csharp
using System;
using System.Threading;
using System.Threading.Tasks;
using Binance.Spot;

class Program
{
    static async Task Main(string[] args)
    {
        var websocket = new MarketDataWebSocket("btcusdt@aggTrade");

        websocket.OnMessageReceived(
            (data) =>
        {
            Console.WriteLine(data);

            return Task.CompletedTask;
        }, CancellationToken.None);

        await websocket.ConnectAsync(CancellationToken.None);
    }
}
```
More websocket examples are available in the `Examples` folder

### Heartbeat

Once connected, the websocket server sends a ping frame every 3 minutes and requires a response pong frame back within
a 10 minutes period. This package handles the pong responses automatically.

### Testnet

While `/sapi/*` endpoints don't have testnet environment yet, `/api/*` endpoints can be tested in 
[Spot Testnet](https://testnet.binance.vision/).

```csharp
using Binance.Spot;

Wallet wallet = new Wallet(baseUrl: "https://testnet.binance.vision");
```

### Base URL

If `baseUrl` is not provided, it defaults to `https://api.binance.com`.

It's recommended to pass in the `baseUrl` parameter, even in production as Binance provides alternative URLs
in case of performance issues:
- `https://api1.binance.com`
- `https://api2.binance.com`
- `https://api3.binance.com`


### RecvWindow parameter

Additional parameter `recvWindow` is available for endpoints requiring signature.

It defaults to `5000` (milliseconds) and can be any value lower than `60000`(milliseconds).
Anything beyond the limit will result in an error response from Binance server.

```csharp
using Binance.Spot;

Wallet wallet = new Wallet();

await wallet.AccountStatus(recvWindow=4000)
```

### Timeout
The default timeout is 100,000 milliseconds (100 seconds).  

Usage Example
```csharp
using System;
using System.Net.Http;
using Binance.Spot;

HttpClient httpClient = new HttpClient() { 
    Timeout = TimeSpan.FromSeconds(10)
}

Wallet wallet = new Wallet(httpClient: httpClient);
```

### Proxy
Usage Example
```csharp
using System;
using System.Net;
using System.Net.Http;
using Binance.Spot;

WebProxy proxy = new WebProxy(new Uri("http://1.2.3.4:8080"));
HttpClientHandler proxyHandler = new HttpClientHandler { Proxy = proxy };
HttpClient httpClient = new HttpClient(handler: proxyHandler);

Wallet wallet = new Wallet(httpClient: httpClient);
```

### Exceptions

There are 2 types of exceptions returned from the library:
- `Binance.Common.BinanceClientException`
    - This is thrown when server returns `4XX`, it's an issue from client side.
    - Properties:
        - `Code` - Server's error code, e.g. `-1102`
        - `Message` - Server's error message, e.g. `Unknown order sent.`
- `Binance.Common.BinanceServerException`
    - This is thrown when server returns `5XX`, it's an issue from server side.

Both exceptions inherit `Binance.Common.BinanceHttpException` along with the following properties:
- `StatusCode` - Response http status code, e.g. `401`
- `Headers` -  Dictionary with response headers

### Logging
This library implements the .NET logging API that works with a variety of built-in and third-party logging providers. 

For more information on how to configure logging in .NET, visit [Microsoft's logging article](https://docs.microsoft.com/en-us/dotnet/core/extensions/logging?tabs=command-line)

Usage Example
```csharp
using System;
using System.Net;
using System.Net.Http;
using Binance.Spot;

public async Task LoggingExample(ILogger logger) {
    BinanceLoggingHandler loggingHandler = new BinanceLoggingHandler(logger: logger);
    HttpClient httpClient = new HttpClient(handler: loggingHandler);

    Wallet wallet = new Wallet(httpClient: httpClient);

    await wallet.SystemStatus();
}
```

Sample Output


```
Method: GET, RequestUri: 'https://www.binance.com/?timestamp=1631525776809&signature=f07558c98cb82bcb3556a6a21b8a8a2582bae93d0bb9604a0df72cae8c1c6642', Version: 1.1, Content: <null>, Headers: { }
StatusCode: 200, ReasonPhrase: 'OK', Version: 1.1, Content: <null>, Headers: {}
{"status": 0,"msg": "normal"}
```

## Test Cases

```bash
dotnet test
```

## Limitations

Futures and Vanilla Options APIs are not supported:
- /fapi/*
- /dapi/*
- /vapi/*
- Associated Websocket Market and User Data Streams

## Contributing

Contributions are welcome.

If you've found a bug within this project, please open an issue to discuss what you would like to change.

If it's an issue with the API, please open a topic at [Binance Developer Community](https://dev.binance.vision)
