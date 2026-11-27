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

namespace Binance.MarginTrading.RestApi;

public sealed class QueryLiabilityCoinLeverageBracketInCrossMarginProModeResponseInner
{
    /// <summary>asset Names list.</summary>
    [JsonPropertyName("assetNames")]
    public List<string>? AssetNames { get; set; }

    /// <summary>rank.</summary>
    [JsonPropertyName("rank")]
    public long? Rank { get; set; }

    /// <summary>brackets list.</summary>
    [JsonPropertyName("brackets")]
    public List<QueryLiabilityCoinLeverageBracketInCrossMarginProModeResponseInnerBracketsInner>? Brackets { get; set; }
}
