namespace PetOmetro.Application.Settings.Models
{
    public class JwtSettings
    {
        public int Expiration { get; set; }
        public bool ValidateIssuerSigningKey { get; set; }
        public bool ValidateIssuer { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateLifetime { get; set; }
    }
}