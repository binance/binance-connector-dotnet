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

public sealed class GetInterestHistoryResponseRowsInner
{
    /// <summary>tx Id.</summary>
    [JsonPropertyName("txId")]
    public long? TxId { get; set; }

    /// <summary>interest Accured Time.</summary>
    [JsonPropertyName("interestAccuredTime")]
    public long? InterestAccuredTime { get; set; }

    /// <summary>asset.</summary>
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    /// <summary>will not be returned for isolated margin</summary>
    [JsonPropertyName("rawAsset")]
    public string? RawAsset { get; set; }

    /// <summary>principal.</summary>
    [JsonPropertyName("principal")]
    public string? Principal { get; set; }

    /// <summary>interest.</summary>
    [JsonPropertyName("interest")]
    public string? Interest { get; set; }

    /// <summary>interest Rate.</summary>
    [JsonPropertyName("interestRate")]
    public string? InterestRate { get; set; }

    /// <summary>type.</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>isolated symbol, will not be returned for crossed margin</summary>
    [JsonPropertyName("isolatedSymbol")]
    public string? IsolatedSymbol { get; set; }
}
