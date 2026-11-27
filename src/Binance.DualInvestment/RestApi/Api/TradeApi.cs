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

namespace Binance.DualInvestment.RestApi;

public sealed class CheckDualInvestmentAccountsRequest
{
    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

[JsonConverter(typeof(ExtensibleValueConverter<GetDualInvestmentPositionsStatus>))]
public readonly struct GetDualInvestmentPositionsStatus : IExtensibleValue<GetDualInvestmentPositionsStatus>, IEquatable<GetDualInvestmentPositionsStatus>
{
    private readonly string? _value;

    public GetDualInvestmentPositionsStatus(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetDualInvestmentPositionsStatus Pending { get; } = new("PENDING");

    public static GetDualInvestmentPositionsStatus PurchaseSuccess { get; } = new("PURCHASE_SUCCESS");

    public static GetDualInvestmentPositionsStatus Settled { get; } = new("SETTLED");

    public static GetDualInvestmentPositionsStatus PurchaseFail { get; } = new("PURCHASE_FAIL");

    public static GetDualInvestmentPositionsStatus Refunding { get; } = new("REFUNDING");

    public static GetDualInvestmentPositionsStatus RefundSuccess { get; } = new("REFUND_SUCCESS");

    public static GetDualInvestmentPositionsStatus Settling { get; } = new("SETTLING");

    static GetDualInvestmentPositionsStatus IExtensibleValue<GetDualInvestmentPositionsStatus>.Create(string value) => new(value);

    public static bool operator ==(GetDualInvestmentPositionsStatus left, GetDualInvestmentPositionsStatus right) => left.Equals(right);

    public static bool operator !=(GetDualInvestmentPositionsStatus left, GetDualInvestmentPositionsStatus right) => !left.Equals(right);

    public static implicit operator GetDualInvestmentPositionsStatus(string value) => new(value);

    public static GetDualInvestmentPositionsStatus FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetDualInvestmentPositionsStatus other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetDualInvestmentPositionsStatus other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class GetDualInvestmentPositionsRequest
{
    /// <summary>
    /// PENDING: Products are purchasing, will give results later; PURCHASE_SUCCESS: purchase successfully;
    /// SETTLED: Products are finish settling; PURCHASE_FAIL: fail to purchase; REFUNDING: refund ongoing;
    /// REFUND_SUCCESS: refund to spot account successfully; SETTLING: Products are settling. If don't fill
    /// this field, will response all the position status.
    /// </summary>
    public GetDualInvestmentPositionsStatus? Status { get; init; }

    /// <summary>Number of records per page</summary>
    public long? PageSize { get; init; }

    /// <summary>Page index</summary>
    public long? PageIndex { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed class SubscribeDualInvestmentProductsRequest
{
    /// <summary>get id from /sapi/v1/dci/product/list</summary>
    public required string Id { get; init; }

    /// <summary>get orderId from /sapi/v1/dci/product/list</summary>
    public required string OrderId { get; init; }

    /// <summary>the amount for subscribing</summary>
    public required decimal DepositAmount { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class DualInvestmentRestApi
{

    /// <summary>Check Dual Investment accounts (USER_DATA)</summary>
    /// <remarks>
    /// <para>Check Dual Investment accounts</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<CheckDualInvestmentAccountsResponse>> CheckDualInvestmentAccountsAsync(CheckDualInvestmentAccountsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/dci/product/accounts", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DualInvestmentRestApiJson.Default.CheckDualInvestmentAccountsResponse, cancellationToken);
    }

    /// <summary>Get Dual Investment positions (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get Dual Investment positions (batch)</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetDualInvestmentPositionsResponse>> GetDualInvestmentPositionsAsync(GetDualInvestmentPositionsRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/dci/product/positions", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("status", request.Status);
        r.Query("pageSize", request.PageSize);
        r.Query("pageIndex", request.PageIndex);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DualInvestmentRestApiJson.Default.GetDualInvestmentPositionsResponse, cancellationToken);
    }

    /// <summary>Subscribe Dual Investment products (USER_DATA)</summary>
    /// <remarks>
    /// <para>Subscribe Dual Investment products</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Failed messages:</para>
    /// <para>- Products are not available. This means APR changed to a lower value, or the order is unavailable.</para>
    /// <para>- Failed. This means system or network errors.</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<SubscribeDualInvestmentProductsResponse>> SubscribeDualInvestmentProductsAsync(SubscribeDualInvestmentProductsRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("POST", "/sapi/v1/dci/product/subscribe", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<SubscribeDualInvestmentProductsResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("id", request.Id);
        r.Query("orderId", request.OrderId);
        r.Query("depositAmount", request.DepositAmount);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DualInvestmentRestApiJson.Default.SubscribeDualInvestmentProductsResponse, cancellationToken);
    }
}
