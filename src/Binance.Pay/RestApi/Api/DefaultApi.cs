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

namespace Binance.Pay.RestApi;

public sealed class GetPayTradeHistoryRequest
{
    /// <summary>Start time in milliseconds.</summary>
    public long? StartTime { get; init; }

    /// <summary>End time in milliseconds.</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of records to return.</summary>
    public long? Limit { get; init; }

    /// <summary>Request validity window in milliseconds.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class PayRestApi
{

    /// <summary>Get Pay Trade History</summary>
    /// <remarks>
    /// <para>Weight(UID): 3000</para>
    /// <para>Notes:</para>
    /// <para>- If startTime and endTime are not sent, the recent 90 days' data will be returned.</para>
    /// <para>- The max interval between startTime and endTime is 90 days.</para>
    /// <para>- Support for querying orders within the last 18 months.</para>
    /// <para>- payerInfo and receiverInfo return different fields in different orderType values:</para>
    /// <para>
    /// - C2C sender: payerInfo=binanceId; receiverInfo=name,
    /// binanceId/accountId/email/countryCode/phoneNumber/mobileCode (based on user input).
    /// </para>
    /// <para>- C2C receiver: payerInfo=name; receiverInfo=binanceId.</para>
    /// <para>- CRYPTO_BOX sender: payerInfo=binanceId; receiverInfo=name (always "Crypto Box").</para>
    /// <para>- CRYPTO_BOX receiver: payerInfo=name; receiverInfo=binanceId.</para>
    /// <para>- PAY sender: payerInfo=binanceId; receiverInfo=name.</para>
    /// <para>- PAY receiver: payerInfo=name; receiverInfo=binanceId, name.</para>
    /// <para>- PAY_REFUND sender: payerInfo=binanceId, name; receiverInfo=name, accountId.</para>
    /// <para>- PAY_REFUND receiver: payerInfo=name; receiverInfo=binanceId.</para>
    /// <para>- PAYOUT sender: payerInfo=binanceId, name; receiverInfo=name, accountId.</para>
    /// <para>- PAYOUT receiver: payerInfo=name; receiverInfo=binanceId.</para>
    /// <para>- CRYPTO_BOX_RF receiver: payerInfo=name (always "Crypto Box"); receiverInfo=binanceId.</para>
    /// <para>
    /// - REMITTANCE sender: payerInfo=binanceId; receiverInfo=name, institutionName, cardNumber,
    /// digitalWalletId.
    /// </para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetPayTradeHistoryResponse>> GetPayTradeHistoryAsync(GetPayTradeHistoryRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/pay/transactions", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, PayRestApiJson.Default.GetPayTradeHistoryResponse, cancellationToken);
    }
}
