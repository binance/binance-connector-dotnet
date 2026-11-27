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

public sealed class FetchWithdrawQuotaResponse
{
    /// <summary>
    /// User's total withdrawal quota in the past 24 hours (including on-chain withdrawal and internal
    /// transfer), unit in USD
    /// </summary>
    [JsonPropertyName("wdQuota")]
    public string? WdQuota { get; set; }

    /// <summary>User withdrawal quota usage in the past 24 hours, unit in USD</summary>
    [JsonPropertyName("usedWdQuota")]
    public string? UsedWdQuota { get; set; }
}
