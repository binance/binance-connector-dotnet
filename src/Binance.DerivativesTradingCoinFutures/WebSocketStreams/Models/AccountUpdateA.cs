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

namespace Binance.DerivativesTradingCoinFutures.WebSocketStreams;

/// <summary>Update Data</summary>
public sealed class AccountUpdateA
{
    /// <summary>Event reason type</summary>
    [JsonPropertyName("m")]
    public string? M { get; set; }

    /// <summary>Balances</summary>
    [JsonPropertyName("B")]
    public List<AccountUpdateABInner>? BUppercase { get; set; }

    [JsonPropertyName("P")]
    public List<AccountUpdateAPInner>? PUppercase { get; set; }

    /// <summary>Symbol associated with FUNDING_FEE event</summary>
    [JsonPropertyName("S")]
    public string? SUppercase { get; set; }
}
