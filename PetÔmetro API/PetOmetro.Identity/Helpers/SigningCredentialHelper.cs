using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace PetOmetro.Identity.Helpers
{
    public static class SigningCredentialHelper
    {
        public static SigningCredentials CreateSigningCredential()
        {
            var credentials = new SigningCredentials(GetSecurityKey(), SecurityAlgorithms.RsaSha256Signature);

            return credentials;
        }

        private static RSACryptoServiceProvider GetRSACryptoServiceProvider()
        {
            return new RSACryptoServiceProvider(2048);
        }

        private static SecurityKey GetSecurityKey()
        {
            return new RsaSecurityKey(GetRSACryptoServiceProvider());
        }
    }
}
