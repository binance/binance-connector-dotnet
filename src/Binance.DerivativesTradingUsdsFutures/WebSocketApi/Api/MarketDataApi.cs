//
// Binance .NET Connector
// https://github.com/binance/binance-connector-dotnet
//
// Distributed under the MIT License. See the LICENCE file.
// Documentation: https://binance.github.io/binance-connector-dotnet/
//

using System.Text.Json;
using System.Text.Json.Serialization;
using Binance.Common;

namespace Binance.DerivativesTradingUsdsFutures.WebSocketApi;

public sealed class OrderBookRequest
{
    /// <summary>Symbol.</summary>
    public required string Symbol { get; init; }

    /// <summary>Id.</summary>
    public string? Id { get; init; }

    /// <summary>Valid limits:[5, 10, 20, 50, 100, 500, 1000]</summary>
    public long? Limit { get; init; }
}

public sealed class SymbolOrderBookTickerRequest
{
    /// <summary>Id.</summary>
    public string? Id { get; init; }

    /// <summary>Symbol.</summary>
    public string? Symbol { get; init; }
}

public sealed class SymbolPriceTickerRequest
{
    /// <summary>Id.</summary>
    public string? Id { get; init; }

    /// <summary>Symbol.</summary>
    public string? Symbol { get; init; }
}

public sealed partial class DerivativesTradingUsdsFuturesWebSocketApiConnection
{

    /// <summary>Order Book</summary>
    /// <remarks>
    /// <para>Get current order book. Note that this request returns limited market depth.</para>
    /// <para>
    /// If you need to continuously monitor order book updates, please consider using Websocket Market
    /// Streams:
    /// </para>
    /// <para>- &lt;symbol&gt;@depth&lt;levels&gt;</para>
    /// <para>- &lt;symbol&gt;@depth</para>
    /// <para>You can use depth request together with &lt;symbol&gt;@depth streams to maintain a local order book.</para>
    /// <para>Note:</para>
    /// <para>- Retail Price Improvement(RPI) orders are not visible and excluded in</para>
    /// <para>the response message.</para>
    /// <para>Weight: Adjusted based on the limit:</para>
    /// <para>| Limit | Weight |</para>
    /// <para>| 5, 10, 20, 50 | 2 |</para>
    /// <para>| 100 | 5 |</para>
    /// <para>| 500 | 10 |</para>
    /// <para>| 1000 | 20 |</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<OrderBookResponseResult>> OrderBookAsync(OrderBookRequest request, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("depth", WebSocketAuth.None);
        if (request is null) return Task.FromException<WebSocketApiResponse<OrderBookResponseResult>>(new ArgumentNullException(nameof(request)));
        r.Param("symbol", request.Symbol);
        r.Param("id", request.Id);
        r.Param("limit", request.Limit);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesWebSocketApiJson.Default.OrderBookResponseResult, cancellationToken);
    }

    /// <summary>Symbol Order Book Ticker</summary>
    /// <remarks>
    /// <para>Best price/qty on the order book for a symbol or symbols.</para>
    /// <para>Note:</para>
    /// <para>- Retail Price Improvement(RPI) orders are not visible and excluded in</para>
    /// <para>the response message.</para>
    /// <para>Weight: 2 for a single symbol; 5 when the symbol parameter is omitted</para>
    /// <para>Notes:</para>
    /// <para>- If the symbol is not sent, bookTickers for all symbols will be</para>
    /// <para>returned in an array.</para>
    /// <para>- The field X-MBX-USED-WEIGHT-1M in response header is not accurate</para>
    /// <para>from this endpoint, please ignore.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<SymbolOrderBookTickerResponseResult>> SymbolOrderBookTickerAsync(SymbolOrderBookTickerRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("ticker.book", WebSocketAuth.None);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("symbol", request.Symbol);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesWebSocketApiJson.Default.SymbolOrderBookTickerResponseResult, cancellationToken);
    }

    /// <summary>Symbol Price Ticker</summary>
    /// <remarks>
    /// <para>Latest price for a symbol or symbols.</para>
    /// <para>Weight: 1 for a single symbol; 2 when the symbol parameter is omitted</para>
    /// <para>Notes:</para>
    /// <para>- If the symbol is not sent, prices for all symbols will be returned in an array.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the wait for the response; the task then ends as cancelled.</param>
    /// <returns>The decoded result, with the rate limit counters of the response.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceWebSocketResponseException"/> for an error answered by the server, or <see cref="BinanceWebSocketNotConnectedException"/> when the client is not connected).</exception>
    public Task<WebSocketApiResponse<SymbolPriceTickerResponseResult>> SymbolPriceTickerAsync(SymbolPriceTickerRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new WebSocketApiRequest("ticker.price", WebSocketAuth.None);
        request ??= new();
        r.Param("id", request.Id);
        r.Param("symbol", request.Symbol);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesWebSocketApiJson.Default.SymbolPriceTickerResponseResult, cancellationToken);
    }
}
