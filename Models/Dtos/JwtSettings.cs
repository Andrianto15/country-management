namespace CountryManagement.Models.Dtos
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = "YourSuperSecureSecretKeyWithAtLeast32Characters!!";
        public string Issuer { get; set; } = "CountryManagementAPI";
        public string Audience { get; set; } = "CountryManagementClients";
    }
}
