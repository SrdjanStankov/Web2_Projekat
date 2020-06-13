namespace Core.Entities
{
    public class ApplicationSettings
    {
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
        public bool RequireEmailVerification { get; set; } = true;
        public string NetworkCredentialUsername { get; set; }
        public string NetworkCredentialPassword { get; set; }
        public bool RedirectEmailToCredentialUsername { get; set; } = true;
        public string SmtpClientHost { get; set; }
        public int SmtpClientPort { get; set; }
    }
}