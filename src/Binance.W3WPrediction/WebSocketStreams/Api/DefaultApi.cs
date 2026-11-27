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

namespace Binance.W3WPrediction.WebSocketStreams;

public sealed class PredictionOrderBookByMarketIdRequest
{
    /// <summary>
    /// Market ID to subscribe to — the marketId inside markets[] returned by market/list or market/detail.
    /// It is not marketTopicId and not externalId. A wrong id is never rejected: subscribing with
    /// marketTopicId, externalId, or with a closed or resolved market returns the same successful COMMAND
    /// reply as a correct id and then pushes nothing at all, so a stream that stays silent is far more
    /// likely a wrong id than a broken connection.
    /// </summary>
    public required string MarketId { get; init; }
}

public sealed partial class W3WPredictionWebSocketStreamsConnection
{

    /// <summary>Batch claim partially succeeded</summary>
    /// <remarks>
    /// <para>
    /// Pushed when only part of a batch claim succeeds. Only pushId is included — call the REST API for
    /// details.
    /// </para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<BatchClaimPartiallySucceededResponse> BatchClaimPartiallySucceeded()
    {
        return _client.Subscribe(StreamName.Build("/web3_prediction_pm_claim_partial_success"), W3WPredictionWebSocketStreamsJson.Default.BatchClaimPartiallySucceededResponse, null);
    }

    /// <summary>Fund transfer failed</summary>
    /// <remarks>
    /// <para>Pushed when a fund transfer fails.</para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<FundTransferFailedResponse> FundTransferFailed()
    {
        return _client.Subscribe(StreamName.Build("/web3_prediction_pm_transfer_fail"), W3WPredictionWebSocketStreamsJson.Default.FundTransferFailedResponse, null);
    }

    /// <summary>Fund transfer succeeded</summary>
    /// <remarks>
    /// <para>
    /// Pushed when a fund transfer into or out of the prediction wallet succeeds. The direction and the
    /// token are not included (currently USDT only).
    /// </para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<FundTransferSucceededResponse> FundTransferSucceeded()
    {
        return _client.Subscribe(StreamName.Build("/web3_prediction_pm_transfer_success"), W3WPredictionWebSocketStreamsJson.Default.FundTransferSucceededResponse, null);
    }

    /// <summary>Limit order fully filled</summary>
    /// <remarks>
    /// <para>Pushed when a limit order is fully filled.</para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<LimitOrderFullyFilledResponse> LimitOrderFullyFilled()
    {
        return _client.Subscribe(StreamName.Build("/web3_prediction_pm_limit_order_filled"), W3WPredictionWebSocketStreamsJson.Default.LimitOrderFullyFilledResponse, null);
    }

    /// <summary>Limit order partially filled</summary>
    /// <remarks>
    /// <para>
    /// Pushed on each new partial fill of a limit order. One order can be pushed several times, so always
    /// remove duplicates by pushId.
    /// </para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<LimitOrderPartiallyFilledResponse> LimitOrderPartiallyFilled()
    {
        return _client.Subscribe(StreamName.Build("/web3_prediction_pm_limit_order_partial_fill"), W3WPredictionWebSocketStreamsJson.Default.LimitOrderPartiallyFilledResponse, null);
    }

    /// <summary>Limit order submission failed</summary>
    /// <remarks>
    /// <para>Pushed when a limit order is rejected when placed. No amount is included.</para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<LimitOrderSubmissionFailedResponse> LimitOrderSubmissionFailed()
    {
        return _client.Subscribe(StreamName.Build("/web3_prediction_pm_limit_submit_fail"), W3WPredictionWebSocketStreamsJson.Default.LimitOrderSubmissionFailedResponse, null);
    }

    /// <summary>Limit order submitted successfully</summary>
    /// <remarks>
    /// <para>Pushed when the user's limit order is successfully placed on the order book.</para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<LimitOrderSubmittedSuccessfullyResponse> LimitOrderSubmittedSuccessfully()
    {
        return _client.Subscribe(StreamName.Build("/web3_prediction_pm_limit_submit_success"), W3WPredictionWebSocketStreamsJson.Default.LimitOrderSubmittedSuccessfullyResponse, null);
    }

    /// <summary>Market buy order failed / expired</summary>
    /// <remarks>
    /// <para>Pushed when the user's market buy order fails or expires.</para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<MarketBuyOrderFailedResponse> MarketBuyOrderFailed()
    {
        return _client.Subscribe(StreamName.Build("/web3_prediction_pm_market_buy_fail"), W3WPredictionWebSocketStreamsJson.Default.MarketBuyOrderFailedResponse, null);
    }

    /// <summary>Market buy order fully filled</summary>
    /// <remarks>
    /// <para>Pushed when the user's market buy order is fully filled.</para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<MarketBuyOrderFullyFilledResponse> MarketBuyOrderFullyFilled()
    {
        return _client.Subscribe(StreamName.Build("/web3_prediction_pm_market_buy_success"), W3WPredictionWebSocketStreamsJson.Default.MarketBuyOrderFullyFilledResponse, null);
    }

    /// <summary>Market resolution notification</summary>
    /// <remarks>
    /// <para>
    /// Pushed when a market is resolved, to every user holding a position in it, win or lose. No amount or
    /// outcome is included — call the REST API for the user's profit and loss.
    /// </para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<MarketResolutionNotificationResponse> MarketResolutionNotification()
    {
        return _client.Subscribe(StreamName.Build("/web3_prediction_pm_market_close"), W3WPredictionWebSocketStreamsJson.Default.MarketResolutionNotificationResponse, null);
    }

    /// <summary>Market sell order failed / expired</summary>
    /// <remarks>
    /// <para>Pushed when the user's market sell order fails or expires.</para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<MarketSellOrderFailedExpiredResponse> MarketSellOrderFailedExpired()
    {
        return _client.Subscribe(StreamName.Build("/web3_prediction_pm_market_sell_fail"), W3WPredictionWebSocketStreamsJson.Default.MarketSellOrderFailedExpiredResponse, null);
    }

    /// <summary>Market sell order fully filled</summary>
    /// <remarks>
    /// <para>Pushed when the user's market sell order is fully filled.</para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<MarketSellOrderFullyFilledResponse> MarketSellOrderFullyFilled()
    {
        return _client.Subscribe(StreamName.Build("/web3_prediction_pm_market_sell_success"), W3WPredictionWebSocketStreamsJson.Default.MarketSellOrderFullyFilledResponse, null);
    }

    /// <summary>Prediction Order Book by marketId</summary>
    /// <remarks>
    /// <para>Order book (bid/ask) updates for one market. Only active markets are pushed.</para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<PredictionOrderBookByMarketIdResponse> PredictionOrderBookByMarketId(PredictionOrderBookByMarketIdRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        return _client.Subscribe(StreamName.Build("/web3_prediction_orderbook_<marketId>", ("marketId", request.MarketId)), W3WPredictionWebSocketStreamsJson.Default.PredictionOrderBookByMarketIdResponse, null);
    }

    /// <summary>Reward claim failed</summary>
    /// <remarks>
    /// <para>
    /// Pushed when a claim fails completely — a single claim, or every item of a batch. For a batch, only
    /// the first failed item's amount and outcome are included.
    /// </para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<RewardClaimFailedResponse> RewardClaimFailed()
    {
        return _client.Subscribe(StreamName.Build("/web3_prediction_pm_claim_fail"), W3WPredictionWebSocketStreamsJson.Default.RewardClaimFailedResponse, null);
    }

    /// <summary>Reward claim succeeded</summary>
    /// <remarks>
    /// <para>
    /// Pushed when a claim fully succeeds — a single claim, or every item of a batch. Only the total is
    /// reported; no market title or outcome is included.
    /// </para>
    /// <para>Update Speed: Real-time</para>
    /// </remarks>
    /// <returns>The subscription: read its events from <c>Events</c> (or add <c>OnMessage</c> callbacks), wait for the server's acknowledgement with <c>WaitSubscribedAsync()</c>, and dispose it to unsubscribe. While the connection reconnects, the stream is subscribed once it opens again.</returns>
    public EventSubscription<RewardClaimSucceededResponse> RewardClaimSucceeded()
    {
        return _client.Subscribe(StreamName.Build("/web3_prediction_pm_claim_success"), W3WPredictionWebSocketStreamsJson.Default.RewardClaimSucceededResponse, null);
    }
}
