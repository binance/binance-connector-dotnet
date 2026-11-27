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

namespace Binance.Stocks.RestApi;

public sealed class TokenizedAssetsResponseInner
{
    /// <summary>Tokenized asset code, e.g. AAPLB.</summary>
    [JsonPropertyName("assetCode")]
    public string? AssetCode { get; set; }

    /// <summary>Human-readable display name of the tokenized asset.</summary>
    [JsonPropertyName("assetName")]
    public string? AssetName { get; set; }

    /// <summary>
    /// Underlying US-equity ticker, e.g. AAPL. Use this when calling /tokenized/mint or /tokenized/redeem.
    /// </summary>
    [JsonPropertyName("underlyingEquitySymbol")]
    public string? UnderlyingEquitySymbol { get; set; }

    /// <summary>Conversion multiplier between the underlying equity and the tokenized asset.</summary>
    [JsonPropertyName("multiplier")]
    public string? Multiplier { get; set; }

    /// <summary>Whether the multiplier is currently valid and applicable.</summary>
    [JsonPropertyName("multiplierValid")]
    public bool? MultiplierValid { get; set; }
}
