using System.Security.Cryptography;

namespace Task3
{
    internal static class CryptoKeyGenerator
    {
        internal static byte[] GenSalt(int length)
        {
            RNGCryptoServiceProvider p = new RNGCryptoServiceProvider();
            var salt = new byte[length];
            p.GetBytes(salt);
            return salt;
        }

        internal static byte[] ComputeHmacsha1(byte[] data, byte[] key)
        {
            using (var hmac = new HMACSHA256(key))
            {
                return hmac.ComputeHash(data);
            }
        }
    }
}