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

public sealed class VaspListResponseInner
{
    [JsonPropertyName("vaspName")]
    public string? VaspName { get; set; }

    [JsonPropertyName("vaspCode")]
    public string? VaspCode { get; set; }

    /// <summary>For populating the vasp field in the deposit/withdrawal questionnaire</summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }
}
