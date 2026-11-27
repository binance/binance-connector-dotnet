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

public sealed class GetMarginBorrowLoanInterestHistoryResponseRowsInner
{
    /// <summary>Tx ID.</summary>
    [JsonPropertyName("txId")]
    public long? TxId { get; set; }

    /// <summary>Interest Accured Time.</summary>
    [JsonPropertyName("interestAccuredTime")]
    public long? InterestAccuredTime { get; set; }

    /// <summary>asset name</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>Raw Asset.</summary>
    [JsonPropertyName("rawAsset")]
    public string? RawAsset { get; set; }

    /// <summary>Principal repaid</summary>
    [JsonPropertyName("principal")]
    public string? Principal { get; set; }

    /// <summary>Interest repaid</summary>
    [JsonPropertyName("interest")]
    public string? Interest { get; set; }

    /// <summary>daily interest rate</summary>
    [JsonPropertyName("interestRate")]
    public string? InterestRate { get; set; }

    /// <summary>Normal order type after trigger if appliable</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
