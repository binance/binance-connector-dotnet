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

public sealed class GetApiKeyPermissionResponse
{
    [JsonPropertyName("ipRestrict")]
    public bool? IpRestrict { get; set; }

    [JsonPropertyName("createTime")]
    public long? CreateTime { get; set; }

    [JsonPropertyName("enableReading")]
    public bool? EnableReading { get; set; }

    /// <summary>
    /// This option allows you to withdraw via API. You must apply the IP Access Restriction filter in order
    /// to enable withdrawals
    /// </summary>
    [JsonPropertyName("enableWithdrawals")]
    public bool? EnableWithdrawals { get; set; }

    /// <summary>
    /// This option authorizes this key to transfer funds between your master account and your sub account
    /// instantly
    /// </summary>
    [JsonPropertyName("enableInternalTransfer")]
    public bool? EnableInternalTransfer { get; set; }

    /// <summary>This option can be adjusted after the Cross Margin account transfer is completed</summary>
    [JsonPropertyName("enableMargin")]
    public bool? EnableMargin { get; set; }

    /// <summary>
    /// The Futures API cannot be used if the API key was created before the Futures account was opened, or
    /// if you have enabled portfolio margin.
    /// </summary>
    [JsonPropertyName("enableFutures")]
    public bool? EnableFutures { get; set; }

    /// <summary>
    /// Authorizes this key to be used for a dedicated universal transfer API to transfer multiple supported
    /// currencies. Each business's own transfer API rights are not affected by this authorization
    /// </summary>
    [JsonPropertyName("permitsUniversalTransfer")]
    public bool? PermitsUniversalTransfer { get; set; }

    /// <summary>Authorizes this key to Vanilla options trading</summary>
    [JsonPropertyName("enableVanillaOptions")]
    public bool? EnableVanillaOptions { get; set; }

    [JsonPropertyName("enableFixApiTrade")]
    public bool? EnableFixApiTrade { get; set; }

    [JsonPropertyName("enableFixReadOnly")]
    public bool? EnableFixReadOnly { get; set; }

    /// <summary>Spot and margin trading</summary>
    [JsonPropertyName("enableSpotAndMarginTrading")]
    public bool? EnableSpotAndMarginTrading { get; set; }

    /// <summary>
    /// API Key created before your activate portfolio margin does not support portfolio margin API service
    /// </summary>
    [JsonPropertyName("enablePortfolioMarginTrading")]
    public bool? EnablePortfolioMarginTrading { get; set; }
}
