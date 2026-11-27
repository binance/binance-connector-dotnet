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

public sealed class QueryManagedSubAccountTransferLogSubAccountTradingResponse
{
    [JsonPropertyName("managerSubTransferHistoryVos")]
    public List<QueryManagedSubAccountTransferLogMasterAccountInvestorResponseManagerSubTransferHistoryVosInner>? ManagerSubTransferHistoryVos { get; set; }

    [JsonPropertyName("count")]
    public long? Count { get; set; }
}
