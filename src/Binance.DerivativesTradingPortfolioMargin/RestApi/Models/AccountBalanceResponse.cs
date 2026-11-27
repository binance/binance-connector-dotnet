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

namespace Binance.DerivativesTradingPortfolioMargin.RestApi;

[JsonConverter(typeof(OneOfConverter<AccountBalanceResponse>))]
public sealed class AccountBalanceResponse : OneOf
{
    /// <inheritdoc/>
    protected override JsonSerializerContext Context => DerivativesTradingPortfolioMarginRestApiJson.Default;

    private static readonly Type[] AlternativeList = [typeof(List<AccountBalanceResponse1Inner>), typeof(AccountBalanceResponse2)];

    /// <inheritdoc/>
    protected override IReadOnlyList<Type> Alternatives => AlternativeList;
}
