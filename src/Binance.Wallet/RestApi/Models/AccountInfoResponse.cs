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

public sealed class AccountInfoResponse
{
    [JsonPropertyName("vipLevel")]
    public long? VipLevel { get; set; }

    /// <summary>true or false for margin.</summary>
    [JsonPropertyName("isMarginEnabled")]
    public bool? IsMarginEnabled { get; set; }

    /// <summary>true or false for futures.</summary>
    [JsonPropertyName("isFutureEnabled")]
    public bool? IsFutureEnabled { get; set; }

    /// <summary>true or false for options.</summary>
    [JsonPropertyName("isOptionsEnabled")]
    public bool? IsOptionsEnabled { get; set; }

    /// <summary>true or false for portfolio margin retail.</summary>
    [JsonPropertyName("isPortfolioMarginRetailEnabled")]
    public bool? IsPortfolioMarginRetailEnabled { get; set; }
}
