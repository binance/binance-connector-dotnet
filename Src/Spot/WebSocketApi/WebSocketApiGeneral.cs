namespace Binance.Spot
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Binance.Common;

    public class WebSocketApiGeneral
    {
        private WebSocketApi wsApi;

        public WebSocketApiGeneral(WebSocketApi wsApi)
        {
            this.wsApi = wsApi;
        }

        /// <summary>
        /// Test connectivity to the WebSocket API.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>OK.</returns>
        public async Task PingAsync(object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.wsApi.SendAsync("ping", null, requestId, cancellationToken);
        }

        /// <summary>
        /// Test connectivity to the WebSocket API and get the current server time.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Binance server UTC timestamp.</returns>
        public async Task TimeAsync(object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.wsApi.SendAsync("time", null, requestId, cancellationToken);
        }

        /// <summary>
        /// Query current exchange trading rules, rate limits, and symbol information.<para />
        /// Weight(IP): 10.
        /// </summary>
        /// <param name="symbol">Trading symbol, e.g. BNBUSDT.</param>
        /// <param name="symbols">Describe multiple symbols.</param>
        /// <param name="permissions">Filter symbols by permissions.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Current exchange trading rules and symbol information.</returns>
        public async Task ExchangeInfoAsync(string symbol = null, string[] symbols = null, string[] permissions = null, long? recvWindow = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "symbol", symbol },
                { "symbols", symbols },
                { "permissions", permissions },
                { "recvWindow", recvWindow },
            };
            BinanceParametersUtils.EnsureOnlyOneValidKey(parameters, new string[] { "symbol", "symbols", "permissions" });

            await this.wsApi.SendAsync("exchangeInfo", parameters, requestId, cancellationToken);
        }
    }
}