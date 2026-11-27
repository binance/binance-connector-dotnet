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

public sealed class UserExerciseRecordResponseInner
{
    /// <summary>id</summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>currency</summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>symbol</summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>exercise Price</summary>
    [JsonPropertyName("exercisePrice")]
    public string? ExercisePrice { get; set; }

    /// <summary>quantity</summary>
    [JsonPropertyName("quantity")]
    public string? Quantity { get; set; }

    /// <summary>amount</summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>fee</summary>
    [JsonPropertyName("fee")]
    public string? Fee { get; set; }

    /// <summary>create Date</summary>
    [JsonPropertyName("createDate")]
    public long? CreateDate { get; set; }

    /// <summary>price Scale</summary>
    [JsonPropertyName("priceScale")]
    public long? PriceScale { get; set; }

    /// <summary>quantity Scale</summary>
    [JsonPropertyName("quantityScale")]
    public long? QuantityScale { get; set; }

    /// <summary>option Side</summary>
    [JsonPropertyName("optionSide")]
    public string? OptionSide { get; set; }

    /// <summary>position Side</summary>
    [JsonPropertyName("positionSide")]
    public string? PositionSide { get; set; }

    /// <summary>quote Asset</summary>
    [JsonPropertyName("quoteAsset")]
    public string? QuoteAsset { get; set; }
}
