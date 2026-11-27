# Binance.Common.DependencyInjection

![.NET](https://img.shields.io/badge/.NET-8.0%20%7C%2010.0-blue)
[![NuGet version](https://img.shields.io/nuget/v/Binance.Common.DependencyInjection)](https://www.nuget.org/packages/Binance.Common.DependencyInjection)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Registers any Binance client with `Microsoft.Extensions.DependencyInjection`. The product packages do not
depend on it.

## Installation

```bash
dotnet add package Binance.Common.DependencyInjection
```

## Usage

```csharp
using Binance.Common.DependencyInjection;
using Binance.Spot.RestApi;
using Binance.Spot.WebSocketStreams;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddBinanceRestApi<SpotRestApi>(SpotRestApi.Production, o => o.ApiKey = Environment.GetEnvironmentVariable("API_KEY"));
services.AddBinanceWebSocketStreams<SpotWebSocketStreams>(SpotWebSocketStreams.Testnet);
```

The first argument is the factory of the environment (`Production`, `Testnet` or `Demo`). The configuration is a named
options instance (the name of the client type by default), so it can also be bound from configuration:
`services.AddOptions<RestApiConfig>(nameof(SpotRestApi)).Bind(section)`. Clients are singletons that the container disposes.
The first client created sends the log to the container's `ILoggerFactory`.

## Contributing

See the [root README](https://github.com/binance/binance-connector-dotnet/blob/master/README.md#contributing).

## License

This project is licensed under the MIT License - see the [LICENCE](https://github.com/binance/binance-connector-dotnet/blob/master/LICENCE) file for details.
