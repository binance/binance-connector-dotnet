namespace Binance.Spot
{
    using System.Net.Http;
    using Binance.Common;

    public abstract class SpotService : BinanceService
    {
        protected const string DEFAULT_SPOT_BASE_URL = "https://api.binance.com";

        public SpotService(HttpClient httpClient, string apiKey, string apiSecret, string baseUrl = DEFAULT_SPOT_BASE_URL)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }
    }
}