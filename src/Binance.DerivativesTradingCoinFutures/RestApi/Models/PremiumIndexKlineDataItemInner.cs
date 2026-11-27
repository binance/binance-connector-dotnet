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

namespace Binance.DerivativesTradingCoinFutures.RestApi;

[JsonConverter(typeof(OneOfConverter<PremiumIndexKlineDataItemInner>))]
public sealed class PremiumIndexKlineDataItemInner : OneOf
{
    /// <inheritdoc/>
    protected override JsonSerializerContext Context => DerivativesTradingCoinFuturesRestApiJson.Default;

    private static readonly Type[] AlternativeList = [typeof(long), typeof(string)];

    /// <inheritdoc/>
    protected override IReadOnlyList<Type> Alternatives => AlternativeList;
}
