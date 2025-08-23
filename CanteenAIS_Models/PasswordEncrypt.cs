using System;
using System.Text;
using System.Security.Cryptography;

namespace CanteenAIS_Models
{
    public interface IEncryptor<ReturnType, ValueType>
    {
        ReturnType Encrypt(ValueType value);
    }

    public class Encryptor : IEncryptor<string, string>
    {
        public string Encrypt(string value)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(value);
            //byte[] hashValue = SHA256.HashData(messageBytes);
            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(messageBytes);
            return Convert.ToString(hash);
        }
    }
}
