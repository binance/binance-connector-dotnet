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

public sealed class QueryCrossMarginAccountDetailsResponse
{
    /// <summary>True means margin account created , false means margin account not created.</summary>
    [JsonPropertyName("created")]
    public bool? Created { get; set; }

    /// <summary>borrow Enabled.</summary>
    [JsonPropertyName("borrowEnabled")]
    public bool? BorrowEnabled { get; set; }

    /// <summary>margin Level.</summary>
    [JsonPropertyName("marginLevel")]
    public string? MarginLevel { get; set; }

    /// <summary>collateral Margin Level.</summary>
    [JsonPropertyName("collateralMarginLevel")]
    public string? CollateralMarginLevel { get; set; }

    /// <summary>total Asset Of Btc.</summary>
    [JsonPropertyName("totalAssetOfBtc")]
    public string? TotalAssetOfBtc { get; set; }

    /// <summary>total Liability Of Btc.</summary>
    [JsonPropertyName("totalLiabilityOfBtc")]
    public string? TotalLiabilityOfBtc { get; set; }

    /// <summary>total Net Asset Of Btc.</summary>
    [JsonPropertyName("totalNetAssetOfBtc")]
    public string? TotalNetAssetOfBtc { get; set; }

    /// <summary>Total Collateral Value In USDT.</summary>
    [JsonPropertyName("TotalCollateralValueInUSDT")]
    public string? TotalCollateralValueInUSDT { get; set; }

    /// <summary>trade Enabled.</summary>
    [JsonPropertyName("tradeEnabled")]
    public bool? TradeEnabled { get; set; }

    /// <summary>transfer In Enabled.</summary>
    [JsonPropertyName("transferInEnabled")]
    public bool? TransferInEnabled { get; set; }

    /// <summary>transfer Out Enabled.</summary>
    [JsonPropertyName("transferOutEnabled")]
    public bool? TransferOutEnabled { get; set; }

    /// <summary>// MARGIN_1 for Cross Margin Classic, MARGIN_2 for Cross Margin Pro</summary>
    [JsonPropertyName("accountType")]
    public string? AccountType { get; set; }

    /// <summary>user Assets list.</summary>
    [JsonPropertyName("userAssets")]
    public List<QueryCrossMarginAccountDetailsResponseUserAssetsInner>? UserAssets { get; set; }
}
