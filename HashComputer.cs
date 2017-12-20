using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CricketData.HashingAndSalting
{
    public class HashComputer
    {
        public string GetPasswordHashAndSalt(string message)
        {
            
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] dataBytes = Utility.GetBytes(message);
            byte[] resultBytes = sha.ComputeHash(dataBytes);

            
            return Utility.GetString(resultBytes);
        }
    }
}
