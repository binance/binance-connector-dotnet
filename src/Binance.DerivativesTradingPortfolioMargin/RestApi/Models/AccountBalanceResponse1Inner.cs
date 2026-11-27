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

namespace Binance.DerivativesTradingPortfolioMargin.RestApi;

public sealed class AccountBalanceResponse1Inner
{
    /// <summary>asset name</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>Total Wallet Balance.</summary>
    [JsonPropertyName("totalWalletBalance")]
    public string? TotalWalletBalance { get; set; }

    /// <summary>Cross Margin Asset. Equal to crossMarginFree + crossMarginLocked.</summary>
    [JsonPropertyName("crossMarginAsset")]
    public string? CrossMarginAsset { get; set; }

    /// <summary>Cross Margin Borrowed.</summary>
    [JsonPropertyName("crossMarginBorrowed")]
    public string? CrossMarginBorrowed { get; set; }

    /// <summary>Cross Margin Free.</summary>
    [JsonPropertyName("crossMarginFree")]
    public string? CrossMarginFree { get; set; }

    /// <summary>Cross Margin Interest.</summary>
    [JsonPropertyName("crossMarginInterest")]
    public string? CrossMarginInterest { get; set; }

    /// <summary>Cross Margin Locked.</summary>
    [JsonPropertyName("crossMarginLocked")]
    public string? CrossMarginLocked { get; set; }

    /// <summary>Um Wallet Balance.</summary>
    [JsonPropertyName("umWalletBalance")]
    public string? UmWalletBalance { get; set; }

    /// <summary>Um Unrealized PNL.</summary>
    [JsonPropertyName("umUnrealizedPNL")]
    public string? UmUnrealizedPNL { get; set; }

    /// <summary>Cm Wallet Balance.</summary>
    [JsonPropertyName("cmWalletBalance")]
    public string? CmWalletBalance { get; set; }

    /// <summary>Cm Unrealized PNL.</summary>
    [JsonPropertyName("cmUnrealizedPNL")]
    public string? CmUnrealizedPNL { get; set; }

    /// <summary>last update time</summary>
    [JsonPropertyName("updateTime")]
    public long? UpdateTime { get; set; }

    /// <summary>negative balance amount</summary>
    [JsonPropertyName("negativeBalance")]
    public string? NegativeBalance { get; set; }
}
