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

namespace Binance.Wallet.RestApi;

public sealed class AssetDetailResponseSKY
{
    /// <summary>min withdraw amount</summary>
    [JsonPropertyName("minWithdrawAmount")]
    public string? MinWithdrawAmount { get; set; }

    /// <summary>deposit status (false if ALL of networks' are false)</summary>
    [JsonPropertyName("depositStatus")]
    public bool? DepositStatus { get; set; }

    /// <summary>withdraw fee</summary>
    [JsonPropertyName("withdrawFee")]
    public decimal? WithdrawFee { get; set; }

    /// <summary>withdraw status (false if ALL of networks' are false)</summary>
    [JsonPropertyName("withdrawStatus")]
    public bool? WithdrawStatus { get; set; }
}
