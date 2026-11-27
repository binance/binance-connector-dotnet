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

public sealed class OptionMarginAccountInformationResponseAssetInner
{
    /// <summary>asset</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>margin Balance</summary>
    [JsonPropertyName("marginBalance")]
    public string? MarginBalance { get; set; }

    /// <summary>equity</summary>
    [JsonPropertyName("equity")]
    public string? Equity { get; set; }

    /// <summary>available</summary>
    [JsonPropertyName("available")]
    public string? Available { get; set; }

    /// <summary>initial Margin</summary>
    [JsonPropertyName("initialMargin")]
    public string? InitialMargin { get; set; }

    /// <summary>maint Margin</summary>
    [JsonPropertyName("maintMargin")]
    public string? MaintMargin { get; set; }

    /// <summary>unrealized PNL</summary>
    [JsonPropertyName("unrealizedPNL")]
    public string? UnrealizedPNL { get; set; }

    /// <summary>adjusted Equity</summary>
    [JsonPropertyName("adjustedEquity")]
    public string? AdjustedEquity { get; set; }
}
