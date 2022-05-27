namespace Binance.Spot
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Binance.Spot.Models;

    public class Mining : SpotService
    {
        public Mining(string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : this(new HttpClient(), baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        public Mining(HttpClient httpClient, string baseUrl = DEFAULT_SPOT_BASE_URL, string apiKey = null, string apiSecret = null)
        : base(httpClient, baseUrl: baseUrl, apiKey: apiKey, apiSecret: apiSecret)
        {
        }

        private const string ACQUIRING_ALGORITHM = "/sapi/v1/mining/pub/algoList";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <returns>Algorithm information.</returns>
        public async Task<string> AcquiringAlgorithm()
        {
            var result = await this.SendPublicAsync<string>(
                ACQUIRING_ALGORITHM,
                HttpMethod.Get);

            return result;
        }

        private const string ACQUIRING_COINNAME = "/sapi/v1/mining/pub/coinList";

        /// <summary>
        /// Weight(IP): 1.
        /// </summary>
        /// <returns>Coin information.</returns>
        public async Task<string> AcquiringCoinname()
        {
            var result = await this.SendPublicAsync<string>(
                ACQUIRING_COINNAME,
                HttpMethod.Get);

            return result;
        }

        private const string REQUEST_FOR_DETAIL_MINER_LIST = "/sapi/v1/mining/worker/detail";

        /// <summary>
        /// Weight(IP): 5.
        /// </summary>
        /// <param name="algo">Algorithm(sha256).</param>
        /// <param name="userName">Mining Account.</param>
        /// <param name="workerName">Miner’s name.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of workers' hashrates'.</returns>
        public async Task<string> RequestForDetailMinerList(string algo, string userName, string workerName, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                REQUEST_FOR_DETAIL_MINER_LIST,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "algo", algo },
                    { "userName", userName },
                    { "workerName", workerName },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string REQUEST_FOR_MINER_LIST = "/sapi/v1/mining/worker/list";

        /// <summary>
        /// Weight(IP): 5.
        /// </summary>
        /// <param name="algo">Algorithm(sha256).</param>
        /// <param name="userName">Mining Account.</param>
        /// <param name="pageIndex">Page number, default is first page, start form 1.</param>
        /// <param name="sort">sort sequence（default=0）0 positive sequence, 1 negative sequence.</param>
        /// <param name="sortColumn">Sort by( default 1): 1: miner name, 2: real-time computing power, 3: daily average computing power, 4: real-time rejection rate, 5: last submission time.</param>
        /// <param name="workerStatus">miners status（default=0）0 all, 1 valid, 2 invalid, 3 failure.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of workers.</returns>
        public async Task<string> RequestForMinerList(string algo, string userName, int? pageIndex = null, int? sort = null, int? sortColumn = null, int? workerStatus = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                REQUEST_FOR_MINER_LIST,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "algo", algo },
                    { "userName", userName },
                    { "pageIndex", pageIndex },
                    { "sort", sort },
                    { "sortColumn", sortColumn },
                    { "workerStatus", workerStatus },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string EARNINGS_LIST = "/sapi/v1/mining/payment/list";

        /// <summary>
        /// Weight(IP): 5.
        /// </summary>
        /// <param name="algo">Algorithm(sha256).</param>
        /// <param name="userName">Mining Account.</param>
        /// <param name="coin">Coin name.</param>
        /// <param name="startDate">Search date, millisecond timestamp, while empty query all.</param>
        /// <param name="endDate">Search date, millisecond timestamp, while empty query all.</param>
        /// <param name="pageIndex">Page number, default is first page, start form 1.</param>
        /// <param name="pageSize">Number of pages, minimum 10, maximum 200.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of earnings.</returns>
        public async Task<string> EarningsList(string algo, string userName, string coin = null, long? startDate = null, long? endDate = null, int? pageIndex = null, int? pageSize = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                EARNINGS_LIST,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "algo", algo },
                    { "userName", userName },
                    { "coin", coin },
                    { "startDate", startDate },
                    { "endDate", endDate },
                    { "pageIndex", pageIndex },
                    { "pageSize", pageSize },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string EXTRA_BONUS_LIST = "/sapi/v1/mining/payment/other";

        /// <summary>
        /// Weight(IP): 5.
        /// </summary>
        /// <param name="algo">Algorithm(sha256).</param>
        /// <param name="userName">Mining Account.</param>
        /// <param name="coin">Coin name.</param>
        /// <param name="startDate">Search date, millisecond timestamp, while empty query all.</param>
        /// <param name="endDate">Search date, millisecond timestamp, while empty query all.</param>
        /// <param name="pageIndex">Page number, default is first page, start form 1.</param>
        /// <param name="pageSize">Number of pages, minimum 10, maximum 200.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of extra bonuses.</returns>
        public async Task<string> ExtraBonusList(string algo, string userName, string coin = null, long? startDate = null, long? endDate = null, int? pageIndex = null, int? pageSize = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                EXTRA_BONUS_LIST,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "algo", algo },
                    { "userName", userName },
                    { "coin", coin },
                    { "startDate", startDate },
                    { "endDate", endDate },
                    { "pageIndex", pageIndex },
                    { "pageSize", pageSize },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string HASHRATE_RESALE_LIST = "/sapi/v1/mining/hash-transfer/config/details/list";

        /// <summary>
        /// Weight(IP): 5.
        /// </summary>
        /// <param name="pageIndex">Page number, default is first page, start form 1.</param>
        /// <param name="pageSize">Number of pages, minimum 10, maximum 200.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of hashrate resales.</returns>
        public async Task<string> HashrateResaleList(int? pageIndex = null, int? pageSize = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                HASHRATE_RESALE_LIST,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "pageIndex", pageIndex },
                    { "pageSize", pageSize },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string HASHRATE_RESALE_DETAIL = "/sapi/v1/mining/hash-transfer/profit/details";

        /// <summary>
        /// Weight(IP): 5.
        /// </summary>
        /// <param name="configId">Mining ID.</param>
        /// <param name="userName">Mining Account.</param>
        /// <param name="pageIndex">Page number, default is first page, start form 1.</param>
        /// <param name="pageSize">Number of pages, minimum 10, maximum 200.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of hashrate resale details.</returns>
        public async Task<string> HashrateResaleDetail(string configId, string userName, int? pageIndex = null, int? pageSize = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                HASHRATE_RESALE_DETAIL,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "configId", configId },
                    { "userName", userName },
                    { "pageIndex", pageIndex },
                    { "pageSize", pageSize },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string HASHRATE_RESALE_REQUEST = "/sapi/v1/mining/hash-transfer/config";

        /// <summary>
        /// Weight(IP): 5.
        /// </summary>
        /// <param name="userName">Mining Account.</param>
        /// <param name="algo">Algorithm(sha256).</param>
        /// <param name="toPoolUser">Mining Account.</param>
        /// <param name="hashRate">Resale hashrate h/s must be transferred (BTC is greater than 500000000000 ETH is greater than 500000).</param>
        /// <param name="startDate">Search date, millisecond timestamp, while empty query all.</param>
        /// <param name="endDate">Search date, millisecond timestamp, while empty query all.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Mining Account Id.</returns>
        public async Task<string> HashrateResaleRequest(string userName, string algo, string toPoolUser, long hashRate, long? startDate = null, long? endDate = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                HASHRATE_RESALE_REQUEST,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "userName", userName },
                    { "algo", algo },
                    { "startDate", startDate },
                    { "endDate", endDate },
                    { "toPoolUser", toPoolUser },
                    { "hashRate", hashRate },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string CANCEL_HASHRATE_RESALE_CONFIGURATION = "/sapi/v1/mining/hash-transfer/config/cancel";

        /// <summary>
        /// Weight(IP): 5.
        /// </summary>
        /// <param name="configId">Mining ID.</param>
        /// <param name="userName">Mining Account.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Success flag.</returns>
        public async Task<string> CancelHashrateResaleConfiguration(int configId, string userName, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                CANCEL_HASHRATE_RESALE_CONFIGURATION,
                HttpMethod.Post,
                query: new Dictionary<string, object>
                {
                    { "configId", configId },
                    { "userName", userName },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string STATISTIC_LIST = "/sapi/v1/mining/statistics/user/status";

        /// <summary>
        /// Weight(IP): 5.
        /// </summary>
        /// <param name="algo">Algorithm(sha256).</param>
        /// <param name="userName">Mining Account.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Mining account statistics.</returns>
        public async Task<string> StatisticList(string algo, string userName, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                STATISTIC_LIST,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "algo", algo },
                    { "userName", userName },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string ACCOUNT_LIST = "/sapi/v1/mining/statistics/user/list";

        /// <summary>
        /// Weight(IP): 5.
        /// </summary>
        /// <param name="algo">Algorithm(sha256).</param>
        /// <param name="userName">Mining Account.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>List of mining accounts.</returns>
        public async Task<string> AccountList(string algo, string userName, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                ACCOUNT_LIST,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "algo", algo },
                    { "userName", userName },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }

        private const string MINING_ACCOUNT_EARNING = "/sapi/v1/mining/payment/uid";

        /// <summary>
        /// Weight(IP): 5.
        /// </summary>
        /// <param name="algo">Algorithm(sha256).</param>
        /// <param name="startDate">Search date, millisecond timestamp, while empty query all.</param>
        /// <param name="endDate">Search date, millisecond timestamp, while empty query all.</param>
        /// <param name="pageIndex">Page number, default is first page, start form 1.</param>
        /// <param name="pageSize">Number of pages, minimum 10, maximum 200.</param>
        /// <param name="recvWindow">The value cannot be greater than 60000.</param>
        /// <returns>Mining account earnings.</returns>
        public async Task<string> MiningAccountEarning(string algo, long? startDate = null, long? endDate = null, int? pageIndex = null, int? pageSize = null, long? recvWindow = null)
        {
            var result = await this.SendSignedAsync<string>(
                MINING_ACCOUNT_EARNING,
                HttpMethod.Get,
                query: new Dictionary<string, object>
                {
                    { "algo", algo },
                    { "startDate", startDate },
                    { "endDate", endDate },
                    { "pageIndex", pageIndex },
                    { "pageSize", pageSize },
                    { "recvWindow", recvWindow },
                    { "timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() },
                });

            return result;
        }
    }
}