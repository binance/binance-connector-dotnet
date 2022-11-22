namespace Binance.Common
{
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.OpenSsl;
    using Org.BouncyCastle.Security;

    /// <summary>
    /// Binance RSA signature signing.
    /// </summary>
    public class BinanceRsa : IBinanceSignatureService
    {
        private RSACryptoServiceProvider rsaService;

        public BinanceRsa(string pem)
            : this(pem, null)
        {
        }

        public BinanceRsa(string pem, string password)
        {
            PemReader pr;
            if (password != null)
            {
                pr = new PemReader(new StringReader(pem), new PasswordFinder(password));
            }
            else
            {
                pr = new PemReader(new StringReader(pem));
            }

            RsaPrivateCrtKeyParameters privateKeyObject = (RsaPrivateCrtKeyParameters)pr.ReadObject();
            RsaPrivateCrtKeyParameters rsaPrivatekey = (RsaPrivateCrtKeyParameters)privateKeyObject;
            RsaKeyParameters rsaPublicKey = new RsaKeyParameters(false, rsaPrivatekey.Modulus, rsaPrivatekey.PublicExponent);
            AsymmetricCipherKeyPair keyPair = new AsymmetricCipherKeyPair(rsaPublicKey, rsaPrivatekey);
            RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)keyPair.Private);
            this.rsaService = new RSACryptoServiceProvider();
            this.rsaService.ImportParameters(rsaParams);
        }

        public string Sign(string payload)
        {
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(payload);
            byte[] encryptedData = this.rsaService.SignData(dataToEncrypt, SHA256.Create());

            return System.Convert.ToBase64String(encryptedData);
        }

        private class PasswordFinder : IPasswordFinder
        {
            private string password;

            public PasswordFinder(string password)
            {
                this.password = password;
            }

            public char[] GetPassword()
            {
                return this.password.ToCharArray();
            }
        }
    }
}