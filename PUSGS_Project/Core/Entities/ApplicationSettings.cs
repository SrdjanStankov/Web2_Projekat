namespace Core.Entities
{
    public class ApplicationSettings
    {
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
        public bool RequireEmailVerification { get; set; } = true;
    }
}