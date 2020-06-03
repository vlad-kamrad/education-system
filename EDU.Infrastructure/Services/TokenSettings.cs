namespace EDU.Infrastructure.Services
{
    public class TokenSettings
    {
        public string IssuerSigningKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int LifeTimeAccess { get; set; }     // Access token lifetime
        public int LifeTimeRefresh { get; set; }    // Refresh token lifetime
    }
}
