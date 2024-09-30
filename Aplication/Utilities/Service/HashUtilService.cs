using Aplication.Utilities.Interface;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace Aplication.Utilities.Service
{
    public class HashUtilService : IHashUtilService
    {
        private readonly int KeySize;
        private readonly int BlockSize;
        private readonly string Clave;
        private readonly string Vector;

        public HashUtilService()
        {
            KeySize = int.Parse(Environment.GetEnvironmentVariable("KEY_SIZE")!);
            BlockSize = int.Parse(Environment.GetEnvironmentVariable("BLOCK_SIZE")!);
            Clave = Environment.GetEnvironmentVariable("CLAVE")!;
            Vector = Environment.GetEnvironmentVariable("VECTOR")!;
        }

        public string GetHashFirst(string Contrasenia)
        {
            //var KeySize =  Environment.GetEnvironmentVariable("KEY_SIZE");

            byte[] keyBytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(Clave));
            byte[] ivBytes = Convert.FromBase64String(Vector);

            Array.Resize(ref keyBytes, KeySize / 8);
            Array.Resize(ref ivBytes, BlockSize / 8);

            using (Aes rijAlg = Aes.Create())
            {
                rijAlg.Key = keyBytes;
                rijAlg.IV = ivBytes;

                // Cifrar la contraseña
                byte[] encryptedBytes;
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, rijAlg.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] plainTextBytes = Encoding.UTF8.GetBytes(Contrasenia);
                        csEncrypt.Write(plainTextBytes, 0, plainTextBytes.Length);
                        csEncrypt.FlushFinalBlock();
                        encryptedBytes = msEncrypt.ToArray();
                    }
                }
                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public string GenerateRandomToken(int lengthToken)
        {
            int passLength = lengthToken;
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, passLength)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string DecryptHashFirst(string encryptedString)
        {

            byte[] keyBytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(Clave));
            byte[] ivBytes = Convert.FromBase64String(Vector);

            Array.Resize(ref keyBytes, KeySize / 8);
            Array.Resize(ref ivBytes, BlockSize / 8);

            using (Aes rijAlg = Aes.Create())
            {
                rijAlg.Key = keyBytes;
                rijAlg.IV = ivBytes;

                // Descifrar la contraseña
                byte[] cipherTextBytes = Convert.FromBase64String(encryptedString);
                using (MemoryStream msDecrypt = new MemoryStream(cipherTextBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, rijAlg.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        public string GenerateSign2(Dictionary<string, string> parameters, string secretKey)
        {
            var orderedParameters = parameters.OrderBy(p => p.Key).ToList();

            var stringToSign = new StringBuilder();
            foreach (var param in orderedParameters)
            {
                stringToSign.Append(param.Key);
                stringToSign.Append(param.Value);
            }

            var stringToSignValue = stringToSign.ToString();

            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
            {
                var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSignValue));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

    }
}
