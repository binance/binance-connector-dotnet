namespace Binance.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using Newtonsoft.Json;

    /// <summary>
    /// Binance base class for REST sections of the API.
    /// </summary>
    public abstract class BinanceService
    {
        private string apiKey;
        private string apiSecret;
        private string baseUrl;
        private HttpClient httpClient;

        public BinanceService(HttpClient httpClient, string baseUrl, string apiKey, string apiSecret)
        {
            this.httpClient = httpClient;
            this.baseUrl = baseUrl;
            this.apiKey = apiKey;
            this.apiSecret = apiSecret;
        }

        protected async Task<T> SendPublicAsync<T>(string requestUri, HttpMethod httpMethod, Dictionary<string, object> query = null, object content = null)
        {
            if (!(query is null))
            {
                StringBuilder queryStringBuilder = this.BuildQueryString(query, new StringBuilder());

                if (queryStringBuilder.Length > 0)
                {
                    requestUri += "?" + queryStringBuilder.ToString();
                }
            }

            return await this.SendAsync<T>(requestUri, httpMethod, content);
        }

        protected async Task<T> SendSignedAsync<T>(string requestUri, HttpMethod httpMethod, Dictionary<string, object> query = null, object content = null)
        {
            StringBuilder queryStringBuilder = new StringBuilder();

            if (!(query is null))
            {
                queryStringBuilder = this.BuildQueryString(query, queryStringBuilder);
            }

            string signature = Sign(queryStringBuilder.ToString(), this.apiSecret);

            if (queryStringBuilder.Length > 0)
            {
                queryStringBuilder.Append("&");
            }

            queryStringBuilder.Append("signature=").Append(signature);

            requestUri += "?" + queryStringBuilder.ToString();

            return await this.SendAsync<T>(requestUri, httpMethod, content);
        }

        private static string Sign(string source, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            using (HMACSHA256 hmacsha256 = new HMACSHA256(keyBytes))
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);

                byte[] hash = hmacsha256.ComputeHash(sourceBytes);

                return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
            }
        }

        private StringBuilder BuildQueryString(Dictionary<string, object> queryParameters, StringBuilder builder)
        {
            foreach (KeyValuePair<string, object> queryParameter in queryParameters)
            {
                string queryParameterValue = Convert.ToString(queryParameter.Value, CultureInfo.InvariantCulture);
                if (!string.IsNullOrWhiteSpace(queryParameterValue))
                {
                    if (builder.Length > 0)
                    {
                        builder.Append("&");
                    }

                    builder
                        .Append(queryParameter.Key)
                        .Append("=")
                        .Append(HttpUtility.UrlEncode(queryParameterValue));
                }
            }

            return builder;
        }

        private async Task<T> SendAsync<T>(string requestUri, HttpMethod httpMethod, object content = null)
        {
            using (var request = new HttpRequestMessage(httpMethod, this.baseUrl + requestUri))
            {
                if (!(content is null))
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                }

                if (!(this.apiKey is null))
                {
                    request.Headers.Add("X-MBX-APIKEY", this.apiKey);
                }

                HttpResponseMessage response = await this.httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    using (HttpContent responseContent = response.Content)
                    {
                        string jsonString = await responseContent.ReadAsStringAsync();

                        if (typeof(T) == typeof(string))
                        {
                            return (T)(object)jsonString;
                        }
                        else
                        {
                            try
                            {
                                T data = JsonConvert.DeserializeObject<T>(jsonString);

                                return data;
                            }
                            catch (JsonReaderException ex)
                            {
                                var clientException = new BinanceClientException($"Failed to map server response from '${requestUri}' to given type", -1, ex);

                                clientException.StatusCode = (int)response.StatusCode;
                                clientException.Headers = response.Headers.ToDictionary(a => a.Key, a => a.Value);

                                throw clientException;
                            }
                        }
                    }
                }
                else
                {
                    using (HttpContent responseContent = response.Content)
                    {
                        BinanceHttpException httpException = null;
                        string contentString = await responseContent.ReadAsStringAsync();
                        int statusCode = (int)response.StatusCode;
                        if (400 <= statusCode && statusCode < 500)
                        {
                            if (string.IsNullOrWhiteSpace(contentString))
                            {
                                httpException = new BinanceClientException("Unsuccessful response with no content", -1);
                            }
                            else
                            {
                                try
                                {
                                    httpException = JsonConvert.DeserializeObject<BinanceClientException>(contentString);
                                }
                                catch (JsonReaderException ex)
                                {
                                    httpException = new BinanceClientException(contentString, -1, ex);
                                }
                            }
                        }
                        else
                        {
                            httpException = new BinanceServerException(contentString);
                        }

                        httpException.StatusCode = statusCode;
                        httpException.Headers = response.Headers.ToDictionary(a => a.Key, a => a.Value);

                        throw httpException;
                    }
                }
            }
        }
    }
}