
namespace Aplication.Utilities.Interface
{
    public interface IHashUtilService
    {
        public string GetHashFirst(string Contrasenia);

        public string GenerateRandomToken(int lengthToken);

        public string DecryptHashFirst(string encryptedString);

        public string GenerateSign2(Dictionary<string, string> parameters, string secretKey);
    }
}
