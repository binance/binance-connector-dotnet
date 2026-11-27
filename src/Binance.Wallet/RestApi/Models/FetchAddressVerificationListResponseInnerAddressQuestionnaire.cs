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

public sealed class FetchAddressVerificationListResponseInnerAddressQuestionnaire
{
    [JsonPropertyName("sendTo")]
    public long? SendTo { get; set; }

    [JsonPropertyName("satoshiToken")]
    public string? SatoshiToken { get; set; }

    [JsonPropertyName("isAddressOwner")]
    public long? IsAddressOwner { get; set; }

    [JsonPropertyName("verifyMethod")]
    public long? VerifyMethod { get; set; }
}
