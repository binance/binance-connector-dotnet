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

public sealed class AllCoinsInformationResponseInner
{
    [JsonPropertyName("coin")]
    public string? Coin { get; set; }

    [JsonPropertyName("depositAllEnable")]
    public bool? DepositAllEnable { get; set; }

    [JsonPropertyName("withdrawAllEnable")]
    public bool? WithdrawAllEnable { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("free")]
    public string? Free { get; set; }

    [JsonPropertyName("locked")]
    public string? Locked { get; set; }

    [JsonPropertyName("freeze")]
    public string? Freeze { get; set; }

    [JsonPropertyName("withdrawing")]
    public string? Withdrawing { get; set; }

    [JsonPropertyName("ipoing")]
    public string? Ipoing { get; set; }

    [JsonPropertyName("ipoable")]
    public string? Ipoable { get; set; }

    [JsonPropertyName("storage")]
    public string? Storage { get; set; }

    [JsonPropertyName("isLegalMoney")]
    public bool? IsLegalMoney { get; set; }

    [JsonPropertyName("trading")]
    public bool? Trading { get; set; }

    [JsonPropertyName("networkList")]
    public List<AllCoinsInformationResponseInnerNetworkListInner>? NetworkList { get; set; }
}
