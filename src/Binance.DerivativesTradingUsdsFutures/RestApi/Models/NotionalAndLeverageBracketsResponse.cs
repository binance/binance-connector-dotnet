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

namespace Binance.DerivativesTradingUsdsFutures.RestApi;

[JsonConverter(typeof(OneOfConverter<NotionalAndLeverageBracketsResponse>))]
public sealed class NotionalAndLeverageBracketsResponse : OneOf
{
    /// <inheritdoc/>
    protected override JsonSerializerContext Context => DerivativesTradingUsdsFuturesRestApiJson.Default;

    private static readonly Type[] AlternativeList = [typeof(List<NotionalAndLeverageBracketsResponse1Inner>), typeof(NotionalAndLeverageBracketsResponse2)];

    /// <inheritdoc/>
    protected override IReadOnlyList<Type> Alternatives => AlternativeList;
}
