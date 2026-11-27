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

namespace Binance.SubAccount.RestApi;

public sealed class GetDetailOnSubAccountsFuturesAccountV2ResponseDeliveryAccountRespAssetsInner
{
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("initialMargin")]
    public string? InitialMargin { get; set; }

    [JsonPropertyName("maintenanceMargin")]
    public string? MaintenanceMargin { get; set; }

    [JsonPropertyName("marginBalance")]
    public string? MarginBalance { get; set; }

    [JsonPropertyName("maxWithdrawAmount")]
    public string? MaxWithdrawAmount { get; set; }

    [JsonPropertyName("openOrderInitialMargin")]
    public string? OpenOrderInitialMargin { get; set; }

    [JsonPropertyName("positionInitialMargin")]
    public string? PositionInitialMargin { get; set; }

    [JsonPropertyName("unrealizedProfit")]
    public string? UnrealizedProfit { get; set; }

    [JsonPropertyName("walletBalance")]
    public string? WalletBalance { get; set; }
}
