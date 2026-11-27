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

/// <summary>quote Asset object.</summary>
public sealed class QueryIsolatedMarginAccountInfoResponseAssetsInnerQuoteAsset
{
    /// <summary>asset.</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>borrow Enabled.</summary>
    [JsonPropertyName("borrowEnabled")]
    public bool? BorrowEnabled { get; set; }

    /// <summary>borrowed.</summary>
    [JsonPropertyName("borrowed")]
    public string? Borrowed { get; set; }

    /// <summary>free.</summary>
    [JsonPropertyName("free")]
    public string? Free { get; set; }

    /// <summary>interest.</summary>
    [JsonPropertyName("interest")]
    public string? Interest { get; set; }

    /// <summary>locked.</summary>
    [JsonPropertyName("locked")]
    public string? Locked { get; set; }

    /// <summary>net Asset.</summary>
    [JsonPropertyName("netAsset")]
    public string? NetAsset { get; set; }

    /// <summary>net Asset Of Btc.</summary>
    [JsonPropertyName("netAssetOfBtc")]
    public string? NetAssetOfBtc { get; set; }

    /// <summary>repay Enabled.</summary>
    [JsonPropertyName("repayEnabled")]
    public bool? RepayEnabled { get; set; }

    /// <summary>total Asset.</summary>
    [JsonPropertyName("totalAsset")]
    public string? TotalAsset { get; set; }
}
