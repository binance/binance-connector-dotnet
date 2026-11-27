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

namespace Binance.DerivativesTradingOptions.RestApi;

public sealed class AutoCancelAllOpenOrdersRequest
{
    public required string Underlyings { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class GetAutoCancelAllOpenOrdersRequest
{
    /// <summary>Underlying asset.</summary>
    public string? Underlying { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class GetMarketMakerProtectionConfigRequest
{
    /// <summary>Underlying asset.</summary>
    public required string Underlying { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class ResetMarketMakerProtectionConfigRequest
{
    public required string Underlying { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class SetAutoCancelAllOpenOrdersRequest
{
    public required string Underlying { get; init; }

    /// <summary>
    /// Countdown time in milliseconds (ex. 1,000 for 1 second). 0 to disable the timer. Negative values
    /// (ex. -10000) are not accepted. Minimum acceptable value is 5,000
    /// </summary>
    public required long CountdownTime { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed class SetMarketMakerProtectionConfigRequest
{
    public required string Underlying { get; init; }

    /// <summary>MMP Interval in milliseconds</summary>
    public required long WindowTimeInMilliseconds { get; init; }

    /// <summary>MMP frozen time in milliseconds, if set to 0 manual reset is required</summary>
    public required long FrozenTimeInMilliseconds { get; init; }

    /// <summary>quantity limit</summary>
    public required decimal QtyLimit { get; init; }

    /// <summary>net delta limit</summary>
    public required decimal DeltaLimit { get; init; }

    public long? RecvWindow { get; init; }
}

public sealed partial class DerivativesTradingOptionsRestApi
{

    /// <summary>Auto-Cancel All Open Orders (Kill-Switch) Heartbeat (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// This endpoint resets the time from which the countdown will begin to the time this messaged is
    /// received. It should be called repeatedly as heartbeats. Multiple heartbeats can be updated at once
    /// by specifying the underlying symbols as a list (ex. BTCUSDT,ETHUSDT) in the underlyings parameter.
    /// </para>
    /// <para>Weight(IP): 10</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - The response will only include underlying symbols where the heartbeat has been successfully
    /// updated.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<AutoCancelAllOpenOrdersResponse>> AutoCancelAllOpenOrdersAsync(AutoCancelAllOpenOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/eapi/v1/countdownCancelAllHeartBeat", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<AutoCancelAllOpenOrdersResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("underlyings", request.Underlyings);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.AutoCancelAllOpenOrdersResponse, cancellationToken);
    }

    /// <summary>Get Auto-Cancel All Open Orders (Kill-Switch) Config (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// This endpoint returns the auto-cancel parameters for each underlying symbol. Note only active
    /// auto-cancel parameters will be returned, if countdownTime is set to 0 (ie. countdownTime has been
    /// turned off), the underlying symbol and corresponding countdownTime parameter will not be returned in
    /// the response.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>- countdownTime = 0 means the function is disabled.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetAutoCancelAllOpenOrdersResponse>> GetAutoCancelAllOpenOrdersAsync(GetAutoCancelAllOpenOrdersRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/countdownCancelAll", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("underlying", request.Underlying);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.GetAutoCancelAllOpenOrdersResponse, cancellationToken);
    }

    /// <summary>Get Market Maker Protection Config (TRADE)</summary>
    /// <remarks>
    /// <para>Get config for MMP.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetMarketMakerProtectionConfigResponse>> GetMarketMakerProtectionConfigAsync(GetMarketMakerProtectionConfigRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/mmp", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetMarketMakerProtectionConfigResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("underlying", request.Underlying);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.GetMarketMakerProtectionConfigResponse, cancellationToken);
    }

    /// <summary>Reset Market Maker Protection Config (TRADE)</summary>
    /// <remarks>
    /// <para>Reset MMP, start MMP order again.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<ResetMarketMakerProtectionConfigResponse>> ResetMarketMakerProtectionConfigAsync(ResetMarketMakerProtectionConfigRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/eapi/v1/mmpReset", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<ResetMarketMakerProtectionConfigResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("underlying", request.Underlying);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ResetMarketMakerProtectionConfigResponse, cancellationToken);
    }

    /// <summary>Set Auto-Cancel All Open Orders (Kill-Switch) Config (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// This endpoint sets the parameters of the auto-cancel feature which cancels all open orders (both
    /// market maker protection and non market maker protection order types) of the underlying symbol at the
    /// end of the specified countdown time period if no heartbeat message is sent. After the countdown time
    /// period, all open orders will be cancelled. The auto-cancel feature can be turned off by setting
    /// countdownTime to 0.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// <para>Notes:</para>
    /// <para>
    /// - This rest endpoint sets up the parameters to cancel your open orders in case of an outage or
    /// disconnection.
    /// </para>
    /// <para>
    /// - Example usage: &gt; Call this endpoint with a countdownTime value of 10000 (10 seconds) to turn on
    /// the auto-cancel feature. If the corresponding countdownCancelAllHeartBeat endpoint is not called
    /// within 10 seconds with the specified underlying symbol, all open orders of the specified symbol will
    /// be automatically canceled. If this endpoint is called with an countdownTime of 0, the countdown
    /// timer will be stopped.
    /// </para>
    /// <para>
    /// - The system will check all countdowns approximately every 100 milliseconds, please note that
    /// sufficient redundancy should be considered when using this function. We do not recommend setting the
    /// countdown time to be too precise or too small.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SetAutoCancelAllOpenOrdersResponse>> SetAutoCancelAllOpenOrdersAsync(SetAutoCancelAllOpenOrdersRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/eapi/v1/countdownCancelAll", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SetAutoCancelAllOpenOrdersResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("underlying", request.Underlying);
        r.Query("countdownTime", request.CountdownTime);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.SetAutoCancelAllOpenOrdersResponse, cancellationToken);
    }

    /// <summary>Set Market Maker Protection Config (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Set config for MMP. Market Maker Protection(MMP) is a set of protection mechanism for option market
    /// maker, this mechanism is able to prevent mass trading in short period time. Once market maker's
    /// account branches the threshold, the Market Maker Protection will be triggered. When Market Maker
    /// Protection triggers, all the current MMP orders will be canceled, new MMP orders will be rejected.
    /// Market maker can use this time to reevaluate market and modify order price.
    /// </para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SetMarketMakerProtectionConfigResponse>> SetMarketMakerProtectionConfigAsync(SetMarketMakerProtectionConfigRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/eapi/v1/mmpSet", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SetMarketMakerProtectionConfigResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("underlying", request.Underlying);
        r.Query("windowTimeInMilliseconds", request.WindowTimeInMilliseconds);
        r.Query("frozenTimeInMilliseconds", request.FrozenTimeInMilliseconds);
        r.Query("qtyLimit", request.QtyLimit);
        r.Query("deltaLimit", request.DeltaLimit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.SetMarketMakerProtectionConfigResponse, cancellationToken);
    }
}
