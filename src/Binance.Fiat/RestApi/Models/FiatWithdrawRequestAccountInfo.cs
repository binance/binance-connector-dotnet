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

namespace Binance.Fiat.RestApi;

/// <summary>withdraw account info</summary>
public sealed class FiatWithdrawRequestAccountInfo
{
    /// <summary>
    /// Your destination bank account number is required to receive the withdrawal. In Argentina, this will
    /// be your CBU/CVU; in Mexico, it will be your CLABE.
    /// </summary>
    [JsonPropertyName("accountNumber")]
    public string? AccountNumber { get; set; }

    /// <summary>Bank agency code. If contains a hyphen (e.g. 123-4), enter 123 only.</summary>
    [JsonPropertyName("agency")]
    public string? Agency { get; set; }

    /// <summary>Bank code used for PIX routing.</summary>
    [JsonPropertyName("bankCodeForPix")]
    public string? BankCodeForPix { get; set; }

    /// <summary>Account type, e.g. current (Checking Account), saving (Savings Account), etc.</summary>
    [JsonPropertyName("accountType")]
    public string? AccountType { get; set; }
}
