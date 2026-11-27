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

namespace Binance.Stocks.RestApi;

public sealed class SignUsEquityDisclaimerRequest
{
    /// <summary>The value cannot be greater than 60000.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class StocksRestApi
{

    /// <summary>Sign US Equity Disclaimer (TRADE)</summary>
    /// <remarks>
    /// <para>
    /// Records the user's acknowledgement and acceptance of the US equity disclaimer. This must be
    /// completed before the account can access certain US equity trading features. The acceptance is tied
    /// to the account associated with the API key.
    /// </para>
    /// <para>Weight: 1</para>
    /// <para>Security Type: TRADE</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SignUsEquityDisclaimerResponse>> SignUsEquityDisclaimerAsync(SignUsEquityDisclaimerRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/equity/account/disclaimer", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, StocksRestApiJson.Default.SignUsEquityDisclaimerResponse, cancellationToken);
    }
}
