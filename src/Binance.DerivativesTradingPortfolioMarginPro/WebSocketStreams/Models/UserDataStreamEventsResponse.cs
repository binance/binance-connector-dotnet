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

namespace Binance.DerivativesTradingPortfolioMarginPro.WebSocketStreams;

[JsonConverter(typeof(OneOfConverter<UserDataStreamEventsResponse>))]
public sealed class UserDataStreamEventsResponse : OneOf
{
    /// <inheritdoc/>
    protected override JsonSerializerContext Context => DerivativesTradingPortfolioMarginProWebSocketStreamsJson.Default;

    private static readonly Type[] AlternativeList = [typeof(PmProAccountUpdate), typeof(Risklevelchange)];

    /// <inheritdoc/>
    protected override IReadOnlyList<Type> Alternatives => AlternativeList;

    /// <summary>The alternative the tag e selects, or null when the tag is missing or unknown.</summary>
    public object? Value => Json.ValueKind == JsonValueKind.Object && Json.TryGetProperty("e", out var tag)
        ? tag.GetString() switch
        {
            "PM_PRO_ACCOUNT_UPDATE" => As<PmProAccountUpdate>(),
            "riskLevelChange" => As<Risklevelchange>(),
            _ => null,
        }
        : null;
}
