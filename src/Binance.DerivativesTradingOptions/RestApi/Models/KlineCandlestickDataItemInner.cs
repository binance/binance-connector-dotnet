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

[JsonConverter(typeof(OneOfConverter<KlineCandlestickDataItemInner>))]
public sealed class KlineCandlestickDataItemInner : OneOf
{
    /// <inheritdoc/>
    protected override JsonSerializerContext Context => DerivativesTradingOptionsRestApiJson.Default;

    private static readonly Type[] AlternativeList = [typeof(long), typeof(string)];

    /// <inheritdoc/>
    protected override IReadOnlyList<Type> Alternatives => AlternativeList;
}
