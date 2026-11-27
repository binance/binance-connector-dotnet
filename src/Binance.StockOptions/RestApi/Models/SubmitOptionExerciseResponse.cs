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

namespace Binance.StockOptions.RestApi;

public sealed class SubmitOptionExerciseResponse
{
    /// <summary>Exercise transaction ID; use it to query Option Exercise Detail.</summary>
    [JsonPropertyName("tranId")]
    public long? TranId { get; set; }

    /// <summary>Echoes the supplied or server-generated client ID.</summary>
    [JsonPropertyName("clientOrderId")]
    public string? ClientOrderId { get; set; }

    /// <summary>
    /// PROCESSING on a first successful submission. When replayed with the same clientOrderId, the current
    /// status of the original exercise (PROCESSING / SUCCESS) is returned.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
