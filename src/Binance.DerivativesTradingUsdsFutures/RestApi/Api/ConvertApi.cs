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

namespace Binance.DerivativesTradingUsdsFutures.RestApi;

public sealed class AcceptTheOfferedQuoteRequest
{
    public required string QuoteId { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class ListAllConvertPairsRequest
{
    /// <summary>User spends coin</summary>
    public string? FromAsset { get; init; }

    /// <summary>User receives coin</summary>
    public string? ToAsset { get; init; }
}

public sealed class OrderStatusRequest
{
    /// <summary>Either orderId or quoteId is required</summary>
    public string? OrderId { get; init; }

    /// <summary>Either orderId or quoteId is required</summary>
    public string? QuoteId { get; init; }
}

public sealed class SendQuoteRequestRequest
{
    public required string FromAsset { get; init; }

    public required string ToAsset { get; init; }

    /// <summary>When specified, it is the amount you will be debited after the conversion</summary>
    public decimal? FromAmount { get; init; }

    /// <summary>When specified, it is the amount you will be credited after the conversion</summary>
    public decimal? ToAmount { get; init; }

    /// <summary>10s, default 10s</summary>
    public string? ValidTime { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class DerivativesTradingUsdsFuturesRestApi
{

    /// <summary>Accept the offered quote (USER_DATA)</summary>
    /// <remarks>
    /// <para>Accept the offered quote by quote ID.</para>
    /// <para>Weight(IP): 200</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AcceptTheOfferedQuoteResponse>> AcceptTheOfferedQuoteAsync(AcceptTheOfferedQuoteRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/fapi/v1/convert/acceptQuote", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<AcceptTheOfferedQuoteResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("quoteId", request.QuoteId);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.AcceptTheOfferedQuoteResponse, cancellationToken);
    }

    /// <summary>List All Convert Pairs</summary>
    /// <remarks>
    /// <para>Query for all convertible token pairs and the tokens’ respective upper/lower limits</para>
    /// <para>Weight(IP): 20</para>
    /// <para>Notes:</para>
    /// <para>- User needs to supply either or both of the input parameter</para>
    /// <para>- If not defined for both fromAsset and toAsset, only partial token pairs will be returned</para>
    /// <para>- Asset BNFCR is only available to convert for MICA region users.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<ListAllConvertPairsResponseInner>>> ListAllConvertPairsAsync(ListAllConvertPairsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/convert/exchangeInfo", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("fromAsset", request.FromAsset);
        r.Query("toAsset", request.ToAsset);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.ListListAllConvertPairsResponseInner, cancellationToken);
    }

    /// <summary>Order status (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query order status by order ID.</para>
    /// <para>Weight(IP): 50</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<OrderStatusResponse>> OrderStatusAsync(OrderStatusRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/fapi/v1/convert/orderStatus", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("orderId", request.OrderId);
        r.Query("quoteId", request.QuoteId);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.OrderStatusResponse, cancellationToken);
    }

    /// <summary>Send Quote Request (USER_DATA)</summary>
    /// <remarks>
    /// <para>Request a quote for the requested token pairs</para>
    /// <para>Weight: 50(IP) 360/hour, 500/day</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Either fromAmount or toAmount should be sent</para>
    /// <para>- quoteId will be returned only if you have enough funds to convert</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SendQuoteRequestResponse>> SendQuoteRequestAsync(SendQuoteRequestRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/fapi/v1/convert/getQuote", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SendQuoteRequestResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("fromAsset", request.FromAsset);
        r.Query("toAsset", request.ToAsset);
        r.Query("fromAmount", request.FromAmount);
        r.Query("toAmount", request.ToAmount);
        r.Query("validTime", request.ValidTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingUsdsFuturesRestApiJson.Default.SendQuoteRequestResponse, cancellationToken);
    }
}
