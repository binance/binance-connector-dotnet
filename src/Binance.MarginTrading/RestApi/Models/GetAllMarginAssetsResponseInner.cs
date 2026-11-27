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

public sealed class GetAllMarginAssetsResponseInner
{
    /// <summary>asset Full Name.</summary>
    [JsonPropertyName("assetFullName")]
    public string? AssetFullName { get; set; }

    /// <summary>asset Name.</summary>
    [JsonPropertyName("assetName")]
    public string? AssetName { get; set; }

    /// <summary>is Borrowable.</summary>
    [JsonPropertyName("isBorrowable")]
    public bool? IsBorrowable { get; set; }

    /// <summary>is Mortgageable.</summary>
    [JsonPropertyName("isMortgageable")]
    public bool? IsMortgageable { get; set; }

    /// <summary>user Min Borrow.</summary>
    [JsonPropertyName("userMinBorrow")]
    public string? UserMinBorrow { get; set; }

    /// <summary>user Min Repay.</summary>
    [JsonPropertyName("userMinRepay")]
    public string? UserMinRepay { get; set; }

    /// <summary>delist Time.</summary>
    [JsonPropertyName("delistTime")]
    public long? DelistTime { get; set; }
}
