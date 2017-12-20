using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CricketData.HashingAndSalting
{
    public static class SaltGenerator
    {
        private static RNGCryptoServiceProvider m_cryptoServiceProvider = null;
        private const int SALT_SIZE = 24;

        static SaltGenerator()
        {
            m_cryptoServiceProvider = new RNGCryptoServiceProvider();
        }

        public static string GetSaltString()
        {
          
            byte[] saltBytes = new byte[SALT_SIZE];
            m_cryptoServiceProvider.GetNonZeroBytes(saltBytes);
            string saltString = Utility.GetString(saltBytes);
            return saltString;
        }

    }
}
