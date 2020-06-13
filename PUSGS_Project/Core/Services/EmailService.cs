using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly ApplicationSettings _settings;

        public EmailService(IOptions<ApplicationSettings> appSettings)
        {
            _settings = appSettings.Value;
        }

        public async Task SendMailAsync(string to, string subject, string body, string from = "noreply@gmail.com")
        {
            var client = new SmtpClient(_settings.SmtpClientHost, _settings.SmtpClientPort)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(_settings.NetworkCredentialUsername, _settings.NetworkCredentialPassword)
            };

            using (var message = new MailMessage())
            {
                if (_settings.RedirectEmailToCredentialUsername)
                {
                    message.To.Add(_settings.NetworkCredentialUsername);
                }
                else
                {
                    message.To.Add(to);
                }
                message.From = new MailAddress(from);
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;

                await client.SendMailAsync(message);
            }
        }
    }
}