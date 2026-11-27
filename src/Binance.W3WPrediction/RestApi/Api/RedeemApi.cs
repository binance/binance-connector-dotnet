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

namespace Binance.W3WPrediction.RestApi;

public sealed class BatchRedeemRequest
{
    /// <summary>User's prediction wallet address</summary>
    public required string WalletAddress { get; init; }

    /// <summary>Wallet ID</summary>
    public required string WalletId { get; init; }

    /// <summary>
    /// List of prediction token IDs to redeem. Not empty. Example: tokenIds=112233&amp;tokenIds=112234
    /// </summary>
    public required List<string> TokenIds { get; init; }

    /// <summary>Chain ID. Default 56 (BSC)</summary>
    public string? ChainId { get; init; }
}

public sealed class GetRedeemStatusRequest
{
    /// <summary>User's prediction wallet address</summary>
    public required string WalletAddress { get; init; }

    /// <summary>Redeem transaction hash</summary>
    public required string TxHash { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class W3WPredictionRestApi
{

    /// <summary>Batch Redeem (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>Redeem one or more settled prediction tokens on-chain to claim winnings. Requires SAS authorization.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<BatchRedeemResponse>> BatchRedeemAsync(BatchRedeemRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/w3w/wallet/prediction/batch-redeem", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<BatchRedeemResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("walletAddress", request.WalletAddress);
        r.Query("walletId", request.WalletId);
        r.Query("tokenIds", request.TokenIds);
        r.Query("chainId", request.ChainId);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.BatchRedeemResponse, cancellationToken);
    }

    /// <summary>Get Redeem Status (PREDICTION_TRADE)</summary>
    /// <remarks>
    /// <para>Query the on-chain transaction status of a previously submitted redeem request.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: PREDICTION_TRADE</para>
    /// <para>Response Notes:</para>
    /// <para>- Status values:</para>
    /// <para>| Value | Description |</para>
    /// <para>| PENDING | Transaction submitted, awaiting confirmation |</para>
    /// <para>| CONFIRMED | Transaction confirmed on-chain |</para>
    /// <para>| FAILED | Transaction failed |</para>
    /// <para>| NOT_FOUND | Transaction hash not found |</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetRedeemStatusResponse>> GetRedeemStatusAsync(GetRedeemStatusRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/w3w/wallet/prediction/redeem/status", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetRedeemStatusResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("walletAddress", request.WalletAddress);
        r.Query("txHash", request.TxHash);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, W3WPredictionRestApiJson.Default.GetRedeemStatusResponse, cancellationToken);
    }
}
