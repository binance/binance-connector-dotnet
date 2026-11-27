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

namespace Binance.DerivativesTradingUsdsFutures.WebSocketApi;

[JsonConverter(typeof(OneOfConverter<SymbolPriceTickerResponse>))]
public sealed class SymbolPriceTickerResponse : OneOf
{
    /// <inheritdoc/>
    protected override JsonSerializerContext Context => DerivativesTradingUsdsFuturesWebSocketApiJson.Default;

    private static readonly Type[] AlternativeList = [typeof(SymbolPriceTickerResponse1), typeof(SymbolPriceTickerResponse2)];

    /// <inheritdoc/>
    protected override IReadOnlyList<Type> Alternatives => AlternativeList;
}
