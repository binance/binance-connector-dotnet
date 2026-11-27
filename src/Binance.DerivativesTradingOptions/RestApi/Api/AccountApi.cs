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

[JsonConverter(typeof(ExtensibleValueConverter<AccountFundingFlowCurrency>))]
public readonly struct AccountFundingFlowCurrency : IExtensibleValue<AccountFundingFlowCurrency>, IEquatable<AccountFundingFlowCurrency>
{
    private readonly string? _value;

    public AccountFundingFlowCurrency(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static AccountFundingFlowCurrency Usdt { get; } = new("USDT");

    static AccountFundingFlowCurrency IExtensibleValue<AccountFundingFlowCurrency>.Create(string value) => new(value);

    public static bool operator ==(AccountFundingFlowCurrency left, AccountFundingFlowCurrency right) => left.Equals(right);

    public static bool operator !=(AccountFundingFlowCurrency left, AccountFundingFlowCurrency right) => !left.Equals(right);

    public static implicit operator AccountFundingFlowCurrency(string value) => new(value);

    public static AccountFundingFlowCurrency FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is AccountFundingFlowCurrency other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(AccountFundingFlowCurrency other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class AccountFundingFlowRequest
{
    /// <summary>Asset type, only support USDT as of now</summary>
    public required AccountFundingFlowCurrency Currency { get; init; }

    /// <summary>Return the recordId and subsequent data, the latest data is returned by default</summary>
    public long? RecordId { get; init; }

    /// <summary>Start Time, e.g 1593511200000</summary>
    public long? StartTime { get; init; }

    /// <summary>End Time, e.g 1593512200000</summary>
    public long? EndTime { get; init; }

    /// <summary>Number of result sets returned</summary>
    public long? Limit { get; init; }

    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed class OptionMarginAccountInformationRequest
{
    /// <summary>Recv Window.</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class DerivativesTradingOptionsRestApi
{

    /// <summary>Account Funding Flow (USER_DATA)</summary>
    /// <remarks>
    /// <para>Query account funding flows.</para>
    /// <para>Weight(IP): 1</para>
    /// <para>Security Type: USER_DATA</para>
    /// <para>Notes:</para>
    /// <para>- Only support querying data in the past 3 months</para>
    /// </remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<List<AccountFundingFlowResponseInner>>> AccountFundingFlowAsync(AccountFundingFlowRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/bill", signed: true, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<List<AccountFundingFlowResponseInner>>>(new ArgumentNullException(nameof(request)));
        r.Query("currency", request.Currency);
        r.Query("recordId", request.RecordId);
        r.Query("startTime", request.StartTime);
        r.Query("endTime", request.EndTime);
        r.Query("limit", request.Limit);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.ListAccountFundingFlowResponseInner, cancellationToken);
    }

    /// <summary>Option Margin Account Information (USER_DATA)</summary>
    /// <remarks>
    /// <para>Get current account information.</para>
    /// <para>Weight(IP): 3</para>
    /// <para>Security Type: USER_DATA</para>
    /// </remarks>
    /// <param name="request">The parameters of the request; all of them are optional.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<OptionMarginAccountInformationResponse>> OptionMarginAccountInformationAsync(OptionMarginAccountInformationRequest? request = null, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/eapi/v1/marginAccount", signed: true, hasTimeUnit: false);
        request ??= new();
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DerivativesTradingOptionsRestApiJson.Default.OptionMarginAccountInformationResponse, cancellationToken);
    }
}
