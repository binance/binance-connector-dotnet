namespace Binance.Spot
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class WebSocketApiUserDataStream
    {
        private WebSocketApi wsApi;

        public WebSocketApiUserDataStream(WebSocketApi wsApi)
        {
            this.wsApi = wsApi;
        }

        /// <summary>
        /// Start a new user data stream.<para />
        /// The stream will close after 60 minutes unless a keepalive is sent. If the account has an active `listenKey`, that `listenKey` will be returned and its validity will be extended for 60 minutes.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Listen key.</returns>
        public async Task CreateListenKeyAsync(object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.wsApi.SendApiAsync("userDataStream.start", null, requestId, cancellationToken);
        }

        /// <summary>
        /// Keepalive a user data stream to prevent a time out. User data streams will close after 60 minutes. It's recommended to send a ping about every 30 minutes.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="listenKey">User websocket listen key.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>OK.</returns>
        public async Task PingListenKeyAsync(string listenKey, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "listenKey", listenKey },
            };
            await this.wsApi.SendApiAsync("userDataStream.ping", parameters, requestId, cancellationToken);
        }

        /// <summary>
        /// Explicitly stop and close the user data stream.<para />
        /// Weight(IP): 1.
        /// </summary>
        /// <param name="listenKey">User websocket listen key.</param>
        /// <param name="requestId">Request ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>OK.</returns>
        public async Task CloseListenKeyAsync(string listenKey, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "listenKey", listenKey },
            };
            await this.wsApi.SendApiAsync("userDataStream.stop", parameters, requestId, cancellationToken);
        }
    }
}