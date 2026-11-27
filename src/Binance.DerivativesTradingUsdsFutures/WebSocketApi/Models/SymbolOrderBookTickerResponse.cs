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

[JsonConverter(typeof(OneOfConverter<SymbolOrderBookTickerResponse>))]
public sealed class SymbolOrderBookTickerResponse : OneOf
{
    /// <inheritdoc/>
    protected override JsonSerializerContext Context => DerivativesTradingUsdsFuturesWebSocketApiJson.Default;

    private static readonly Type[] AlternativeList = [typeof(SymbolOrderBookTickerResponse1), typeof(SymbolOrderBookTickerResponse2)];

    /// <inheritdoc/>
    protected override IReadOnlyList<Type> Alternatives => AlternativeList;
}
