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

namespace Binance.Convert.RestApi;

public sealed class ListAllConvertPairsRequest
{
    /// <summary>User spends coin</summary>
    public string? FromAsset { get; init; }

    /// <summary>User receives coin</summary>
    public string? ToAsset { get; init; }
}

public sealed class QueryOrderQuantityPrecisionPerAssetRequest
{
    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class ConvertRestApi
{

    /// <summary>List All Convert Pairs</summary>
    /// <remarks>
    /// <para>Query for all convertible token pairs and the tokens’ respective upper/lower limits</para>
    /// <para>Weight(IP): 3000</para>
    /// <para>Notes:</para>
    /// <para>- User needs to supply either or both input parameters.</para>
    /// <para>- If only one of fromAsset and toAsset is provided, only partial token pairs are returned.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<ListAllConvertPairsResponseInner>>> ListAllConvertPairsAsync(ListAllConvertPairsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/convert/exchangeInfo", signed: false, hasTimeUnit: false);
        request ??= new();
        r.Query("fromAsset", request.FromAsset);
        r.Query("toAsset", request.ToAsset);
        return _client.SendAsync(r, ConvertRestApiJson.Default.ListListAllConvertPairsResponseInner, cancellationToken);
    }

    /// <summary>Query order quantity precision per asset (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query for supported asset’s precision information</para>
    /// <para>Weight(IP): 100</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<QueryOrderQuantityPrecisionPerAssetResponseInner>>> QueryOrderQuantityPrecisionPerAssetAsync(QueryOrderQuantityPrecisionPerAssetRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/convert/assetInfo", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, ConvertRestApiJson.Default.ListQueryOrderQuantityPrecisionPerAssetResponseInner, cancellationToken);
    }
}
