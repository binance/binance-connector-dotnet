namespace Binance.Futures
{
    using System.Net.Http;
    using Binance.Common;

    public abstract class FuturesService : BinanceService
    {
        protected const string DEFAULT_FUTURES_BASE_URL = "https://fapi.binance.com";

        public FuturesService(HttpClient httpClient, string apiKey, string apiSecret, string baseUrl = DEFAULT_FUTURES_BASE_URL)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public FuturesService(HttpClient httpClient, string apiKey, IBinanceSignatureService signatureService, string baseUrl = DEFAULT_FUTURES_BASE_URL)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, signatureService: signatureService)
        {
        }
    }
}