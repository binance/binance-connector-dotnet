namespace Binance.Common.Tests
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class MockBinanceService : BinanceService
    {
        public MockBinanceService(HttpClient httpClient, string baseUrl = null, string apiKey = null, string apiSecret = null)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public new async Task<T> SendPublicAsync<T>(string requestUri, HttpMethod httpMethod, Dictionary<string, object> query = null, object content = null)
        {
            return await base.SendPublicAsync<T>(requestUri, httpMethod, query: query, content: content);
        }

        public async Task<T> SendSignedAsync<T>(string requestUri, HttpMethod httpMethod, long timestamp, Dictionary<string, object> query = null, object content = null, int? recvWindow = null)
        {
            return await base.SendSignedAsync<T>(requestUri, httpMethod, query: query, content: content);
        }

        public async Task<T> SendSignedAsync<T>(string requestUri, HttpMethod httpMethod, Dictionary<string, object> query = null, object content = null, int? recvWindow = null)
        {
            return await base.SendSignedAsync<T>(requestUri, httpMethod, query: query, content: content);
        }
    }
}