namespace Binance.Common
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Binance HMAC signature signing.
    /// </summary>
    public class BinanceHmac : IBinanceSignatureService
    {
        private byte[] secret;

        public BinanceHmac(string secret)
        {
            this.secret = secret != null ? Encoding.UTF8.GetBytes(secret) : null;
        }

        public string Sign(string payload)
        {
            using (HMACSHA256 hmacsha256 = new HMACSHA256(this.secret))
            {
                byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);

                byte[] hash = hmacsha256.ComputeHash(payloadBytes);

                return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
            }
        }
    }
}