namespace Binance.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.WebSockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using Newtonsoft.Json;

    /// <summary>
    /// Binance WebSocket API wrapper.
    /// </summary>
    public class BinanceWebSocketApi : IDisposable
    {
        private string apiKey;
        private IBinanceWebSocketHandler handler;
        private IBinanceSignatureService signatureService;
        private List<Func<string, Task>> onMessageReceivedFunctions;
        private List<CancellationTokenRegistration> onMessageReceivedCancellationTokenRegistrations;
        private CancellationTokenSource loopCancellationTokenSource;
        private Uri url;
        private int receiveBufferSize;

        public BinanceWebSocketApi(IBinanceWebSocketHandler handler, string url, string apiKey, IBinanceSignatureService signatureService, int receiveBufferSize = 8192)
        {
            this.handler = handler;
            this.url = new Uri(url);
            this.apiKey = apiKey;
            this.signatureService = signatureService;
            this.receiveBufferSize = receiveBufferSize;
            this.onMessageReceivedFunctions = new List<Func<string, Task>>();
            this.onMessageReceivedCancellationTokenRegistrations = new List<CancellationTokenRegistration>();
        }

        public async Task ConnectAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.handler.State != WebSocketState.Open)
            {
                this.loopCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                await this.handler.ConnectAsync(this.url, cancellationToken);
                await Task.Factory.StartNew(() => this.ReceiveLoop(this.loopCancellationTokenSource.Token, this.receiveBufferSize), this.loopCancellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            }
        }

        public async Task DisconnectAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.loopCancellationTokenSource != null)
            {
                this.loopCancellationTokenSource.Cancel();
            }

            if (this.handler.State == WebSocketState.Open)
            {
                await this.handler.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, null, cancellationToken);
                await this.handler.CloseAsync(WebSocketCloseStatus.NormalClosure, null, cancellationToken);
            }
        }

        public void OnMessageReceived(Func<string, Task> onMessageReceived, CancellationToken cancellationToken = default(CancellationToken))
        {
            this.onMessageReceivedFunctions.Add(onMessageReceived);

            if (cancellationToken != CancellationToken.None)
            {
                var reg = cancellationToken.Register(() =>
                    this.onMessageReceivedFunctions.Remove(onMessageReceived));

                this.onMessageReceivedCancellationTokenRegistrations.Add(reg);
            }
        }

        public async Task SendApiAsync(string method, Dictionary<string, object> parameters = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            parameters = this.ParamsWithApiKey(parameters);
            await this.SendAsync(method, parameters, requestId, cancellationToken);
        }

        public async Task SendSignedAsync(string method, Dictionary<string, object> parameters = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.signatureService == null)
            {
                throw new ArgumentNullException("Initiate WebSocketApi with IBinanceSignatureService to perfom this request");
            }

            parameters = this.ParamsWithApiKey(parameters);
            parameters.Add("timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

            StringBuilder payloadBuilder = new StringBuilder();
            payloadBuilder = this.BuildPayload(parameters, payloadBuilder);
            string signature = this.signatureService.Sign(payloadBuilder.ToString());
            parameters.Add("signature", signature);
            await this.SendAsync(method, parameters, requestId, cancellationToken);
        }

        public async Task SendAsync(string method, Dictionary<string, object> parameters = null, object requestId = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Process requestId
            if ((requestId is string && string.IsNullOrWhiteSpace((string)requestId)) || requestId == null)
            {
                requestId = Guid.NewGuid().ToString();
            }
            else if (!(requestId is int || requestId is string || requestId == null))
            {
                throw new ArgumentException($"{requestId} must be of type int or string");
            }

            // Prepare request
            var jsonObject = new object();

            if (parameters is null)
            {
                jsonObject = new
                {
                    @id = requestId,
                    @method = method,
                };
            }
            else
            {
                jsonObject = new
                {
                    @id = requestId,
                    @method = method,
                    @params = this.ProcessRequestParams(parameters),
                };
            }

            string jsonRequest = JsonConvert.SerializeObject(jsonObject);

            byte[] byteArray = Encoding.ASCII.GetBytes(jsonRequest);

            await this.handler.SendAsync(new ArraySegment<byte>(byteArray), WebSocketMessageType.Text, true, cancellationToken);
        }

        public void Dispose()
        {
            this.DisconnectAsync(CancellationToken.None).Wait();

            this.handler.Dispose();

            this.onMessageReceivedCancellationTokenRegistrations.ForEach(ct => ct.Dispose());

            this.loopCancellationTokenSource.Dispose();
        }

        private async Task ReceiveLoop(CancellationToken cancellationToken, int receiveBufferSize = 8192)
        {
            WebSocketReceiveResult receiveResult = null;
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var buffer = new ArraySegment<byte>(new byte[receiveBufferSize]);
                    receiveResult = await this.handler.ReceiveAsync(buffer, cancellationToken);

                    if (receiveResult.MessageType == WebSocketMessageType.Close)
                    {
                        break;
                    }

                    string content = Encoding.UTF8.GetString(buffer.ToArray(), buffer.Offset, buffer.Count);
                    this.onMessageReceivedFunctions.ForEach(omrf => omrf(content));
                }
            }
            catch (TaskCanceledException)
            {
                await this.DisconnectAsync(CancellationToken.None);
            }
        }

        private StringBuilder BuildPayload(Dictionary<string, object> parameters, StringBuilder builder)
        {
            foreach (KeyValuePair<string, object> param in parameters.OrderBy(p => p.Key))
            {
                string paramValue = Convert.ToString(param.Value, CultureInfo.InvariantCulture);
                if (!string.IsNullOrWhiteSpace(paramValue))
                {
                    if (builder.Length > 0)
                    {
                        builder.Append("&");
                    }

                    builder
                        .Append(param.Key)
                        .Append("=")
                        .Append(HttpUtility.UrlEncode(paramValue));
                }
            }

            return builder;
        }

        private Dictionary<string, object> ParamsWithApiKey(Dictionary<string, object> parameters = null)
        {
            if (this.apiKey == null)
            {
                throw new ArgumentNullException("Initiate WebSocketApi with apiKey to perfom this request");
            }

            if (parameters is null)
            {
                parameters = new Dictionary<string, object> { };
            }

            parameters.Add("apiKey", this.apiKey);
            return parameters;
        }

        private Dictionary<string, object> ProcessRequestParams(Dictionary<string, object> parameters)
        {
            var reqParameters = new Dictionary<string, object>();

            foreach (KeyValuePair<string, object> param in parameters)
            {
                if (param.Value != null && (param.Value is string || param.Value.GetType().IsArray))
                {
                    reqParameters.Add(param.Key, param.Value);
                }
                else
                {
                    if (param.Value != null)
                    {
                        string paramValue = Convert.ToString(param.Value);
                        reqParameters.Add(param.Key, paramValue);
                    }
                }
            }

            return reqParameters;
        }
    }
}