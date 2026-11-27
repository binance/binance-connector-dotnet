//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Binance.Common.DependencyInjection;

/// <summary>Registers Binance clients (of any product) in a service collection.</summary>
public static class BinanceServiceCollectionExtensions
{
    private static int _logging;

    /// <summary>
    /// Registers a REST client, e.g. <c>services.AddBinanceRestApi&lt;SpotRestApi&gt;(SpotRestApi.Production, o =&gt; o.ApiKey = key)</c>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="factory">Creates the client from its configuration: the <c>Production</c>, <c>Testnet</c> or <c>Demo</c> method of the client.</param>
    /// <param name="configure">Configures the options; credentials, timeouts, ...</param>
    /// <param name="name">The name of the options instance; the name of the client type by default.</param>
    /// <typeparam name="TClient">The client type.</typeparam>
    public static IServiceCollection AddBinanceRestApi<TClient>(this IServiceCollection services, Func<RestApiConfig?, TClient> factory, Action<RestApiConfig>? configure = null, string? name = null)
        where TClient : class =>
        services.AddBinanceClient(factory, configure, name);

    /// <summary>Registers a WebSocket API client; see <see cref="AddBinanceRestApi{TClient}"/>.</summary>
    /// <param name="services">The service collection.</param>
    /// <param name="factory">Creates the client from its configuration.</param>
    /// <param name="configure">Configures the options.</param>
    /// <param name="name">The name of the options instance; the name of the client type by default.</param>
    /// <typeparam name="TClient">The client type.</typeparam>
    public static IServiceCollection AddBinanceWebSocketApi<TClient>(this IServiceCollection services, Func<WebSocketApiConfig?, TClient> factory, Action<WebSocketApiConfig>? configure = null, string? name = null)
        where TClient : class =>
        services.AddBinanceClient(factory, configure, name);

    /// <summary>Registers a WebSocket Streams client; see <see cref="AddBinanceRestApi{TClient}"/>.</summary>
    /// <param name="services">The service collection.</param>
    /// <param name="factory">Creates the client from its configuration.</param>
    /// <param name="configure">Configures the options.</param>
    /// <param name="name">The name of the options instance; the name of the client type by default.</param>
    /// <typeparam name="TClient">The client type.</typeparam>
    public static IServiceCollection AddBinanceWebSocketStreams<TClient>(this IServiceCollection services, Func<WebSocketStreamsConfig?, TClient> factory, Action<WebSocketStreamsConfig>? configure = null, string? name = null)
        where TClient : class =>
        services.AddBinanceClient(factory, configure, name);

    /// <summary>
    /// Registers a client as a singleton, which the container disposes. Its configuration is the named options instance
    /// <paramref name="name"/> of <typeparamref name="TConfig"/>: bind it with <paramref name="configure"/> or
    /// <c>services.AddOptions&lt;TConfig&gt;(name).Bind(section)</c>. The first client created routes the log (which is
    /// process-wide) to the container's <see cref="ILoggerFactory"/>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="factory">Creates the client from its configuration.</param>
    /// <param name="configure">Configures the options.</param>
    /// <param name="name">The name of the options instance; the name of the client type by default.</param>
    /// <typeparam name="TConfig">The configuration type.</typeparam>
    /// <typeparam name="TClient">The client type.</typeparam>
    public static IServiceCollection AddBinanceClient<TConfig, TClient>(this IServiceCollection services, Func<TConfig?, TClient> factory, Action<TConfig>? configure = null, string? name = null)
        where TConfig : ConnectorConfig, new()
        where TClient : class
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(factory);
        var optionsName = name ?? typeof(TClient).Name;
        var options = services.AddOptions<TConfig>(optionsName);
        if (configure is not null) options.Configure(configure);
        return services.AddSingleton(provider =>
        {
            if (provider.GetService<ILoggerFactory>() is { } loggerFactory && Interlocked.Exchange(ref _logging, 1) == 0)
                BinanceLogging.Configure(loggerFactory);
            return factory(provider.GetRequiredService<IOptionsMonitor<TConfig>>().Get(optionsName));
        });
    }
}
