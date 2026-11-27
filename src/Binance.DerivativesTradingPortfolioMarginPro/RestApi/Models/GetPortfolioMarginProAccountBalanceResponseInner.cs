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

namespace Binance.DerivativesTradingPortfolioMarginPro.RestApi;

public sealed class GetPortfolioMarginProAccountBalanceResponseInner
{
    /// <summary>asset.</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>total Wallet Balance.</summary>
    [JsonPropertyName("totalWalletBalance")]
    public string? TotalWalletBalance { get; set; }

    /// <summary>cross Margin Asset.</summary>
    [JsonPropertyName("crossMarginAsset")]
    public string? CrossMarginAsset { get; set; }

    /// <summary>cross Margin Borrowed.</summary>
    [JsonPropertyName("crossMarginBorrowed")]
    public string? CrossMarginBorrowed { get; set; }

    /// <summary>cross Margin Free.</summary>
    [JsonPropertyName("crossMarginFree")]
    public string? CrossMarginFree { get; set; }

    /// <summary>cross Margin Interest.</summary>
    [JsonPropertyName("crossMarginInterest")]
    public string? CrossMarginInterest { get; set; }

    /// <summary>cross Margin Locked.</summary>
    [JsonPropertyName("crossMarginLocked")]
    public string? CrossMarginLocked { get; set; }

    /// <summary>um Wallet Balance.</summary>
    [JsonPropertyName("umWalletBalance")]
    public string? UmWalletBalance { get; set; }

    /// <summary>um Unrealized PNL.</summary>
    [JsonPropertyName("umUnrealizedPNL")]
    public string? UmUnrealizedPNL { get; set; }

    /// <summary>cm Wallet Balance.</summary>
    [JsonPropertyName("cmWalletBalance")]
    public string? CmWalletBalance { get; set; }

    /// <summary>cm Unrealized PNL.</summary>
    [JsonPropertyName("cmUnrealizedPNL")]
    public string? CmUnrealizedPNL { get; set; }

    /// <summary>update Time.</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    /// <summary>negative Balance.</summary>
    [JsonPropertyName("negativeBalance")]
    public string? NegativeBalance { get; set; }

    /// <summary>option Wallet Balance.</summary>
    [JsonPropertyName("optionWalletBalance")]
    public string? OptionWalletBalance { get; set; }

    /// <summary>option Equity.</summary>
    [JsonPropertyName("optionEquity")]
    public string? OptionEquity { get; set; }
}
