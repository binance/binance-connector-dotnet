namespace Binance.Common
{
    using System;

    /// <summary>
    /// Binance exception class for any errors throw as a result of the misuse of the API or the library.
    /// </summary>
    public class BinanceClientException : BinanceHttpException
    {
        public BinanceClientException()
        : base()
        {
        }

        public BinanceClientException(string message, int code)
        : base(message)
        {
            this.Code = code;
            this.Message = message;
        }

        public BinanceClientException(string message, int code, Exception innerException)
        : base(message, innerException)
        {
            this.Code = code;
            this.Message = message;
        }

        [Newtonsoft.Json.JsonPropertyAttribute("code")]
        public int Code { get; set; }

        [Newtonsoft.Json.JsonPropertyAttribute("msg")]
        public new string Message { get; protected set; }
    }
}