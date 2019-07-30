using System.Security.Cryptography;
using System.Text;

namespace PetOmetro.Common.Helpers
{
    public static class CryptoHelper
    {
        public static string Encrypt(string term)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(term);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] passbyte = sha.ComputeHash(bytes);
            string result = Encoding.UTF8.GetString(passbyte);

            return result;
        }
    }
}
