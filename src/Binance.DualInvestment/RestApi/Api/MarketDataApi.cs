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

[JsonConverter(typeof(ExtensibleValueConverter<GetDualInvestmentProductListOptionType>))]
public readonly struct GetDualInvestmentProductListOptionType : IExtensibleValue<GetDualInvestmentProductListOptionType>, IEquatable<GetDualInvestmentProductListOptionType>
{
    private readonly string? _value;

    public GetDualInvestmentProductListOptionType(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        _value = value;
    }

    public string Value => _value ?? string.Empty;

    public static GetDualInvestmentProductListOptionType Call { get; } = new("CALL");

    public static GetDualInvestmentProductListOptionType Put { get; } = new("PUT");

    static GetDualInvestmentProductListOptionType IExtensibleValue<GetDualInvestmentProductListOptionType>.Create(string value) => new(value);

    public static bool operator ==(GetDualInvestmentProductListOptionType left, GetDualInvestmentProductListOptionType right) => left.Equals(right);

    public static bool operator !=(GetDualInvestmentProductListOptionType left, GetDualInvestmentProductListOptionType right) => !left.Equals(right);

    public static implicit operator GetDualInvestmentProductListOptionType(string value) => new(value);

    public static GetDualInvestmentProductListOptionType FromString(string value) => new(value);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is GetDualInvestmentProductListOptionType other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(GetDualInvestmentProductListOptionType other) => string.Equals(Value, other.Value, StringComparison.Ordinal);

    /// <inheritdoc/>
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);

    /// <inheritdoc/>
    public override string ToString() => Value;
}

public sealed class GetDualInvestmentProductListRequest
{
    /// <summary>Input CALL or PUT</summary>
    public required GetDualInvestmentProductListOptionType OptionType { get; init; }

    /// <summary>
    /// Target exercised asset, e.g.: if you subscribe to a high sell product (call option), you should
    /// input: optionType: CALL, exercisedCoin: USDT, investCoin: BNB; if you subscribe to a low buy product
    /// (put option), you should input: optionType: PUT, exercisedCoin: BNB, investCoin: USDT
    /// </summary>
    public required string ExercisedCoin { get; init; }

    /// <summary>
    /// Asset used for subscribing, e.g.: if you subscribe to a high sell product (call option), you should
    /// input: optionType: CALL, exercisedCoin: USDT, investCoin: BNB; if you subscribe to a low buy product
    /// (put option), you should input: optionType: PUT, exercisedCoin: BNB, investCoin: USDT
    /// </summary>
    public required string InvestCoin { get; init; }

    /// <summary>Number of records per page</summary>
    public long? PageSize { get; init; }

    /// <summary>Page index</summary>
    public long? PageIndex { get; init; }

    /// <summary>Request validity window in milliseconds</summary>
    public long? RecvWindow { get; init; }
}

public sealed partial class DualInvestmentRestApi
{

    /// <summary>Get Dual Investment product list</summary>
    /// <remarks>Weight(IP): 1</remarks>
    /// <param name="request">The parameters of the request.</param>
    /// <param name="cancellationToken">Cancels the request in flight; the task then ends as cancelled.</param>
    /// <returns>The decoded response, with the rate limit counters and the headers that came with it.</returns>
    /// <exception cref="BinanceException">The request failed; the task faults with the exception (for example <see cref="BinanceBadRequestException"/> for an error answered by the server).</exception>
    public Task<RestApiResponse<GetDualInvestmentProductListResponse>> GetDualInvestmentProductListAsync(GetDualInvestmentProductListRequest request, CancellationToken cancellationToken = default)
    {
        var r = new RestRequest("GET", "/sapi/v1/dci/product/list", signed: false, hasTimeUnit: false);
        if (request is null) return Task.FromException<RestApiResponse<GetDualInvestmentProductListResponse>>(new ArgumentNullException(nameof(request)));
        r.Query("optionType", request.OptionType);
        r.Query("exercisedCoin", request.ExercisedCoin);
        r.Query("investCoin", request.InvestCoin);
        r.Query("pageSize", request.PageSize);
        r.Query("pageIndex", request.PageIndex);
        r.Query("recvWindow", request.RecvWindow);
        return _client.SendAsync(r, DualInvestmentRestApiJson.Default.GetDualInvestmentProductListResponse, cancellationToken);
    }
}
