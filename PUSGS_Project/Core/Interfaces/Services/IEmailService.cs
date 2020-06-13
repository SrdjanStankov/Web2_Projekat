using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IEmailService
    {
        /// <summary>
        /// Sends Email to destination
        /// </summary>
        /// <param name="to">destination email address</param>
        /// <param name="subject">mail subject</param>
        /// <param name="body">content of the mail (html supported)</param>
        Task SendMailAsync(string to, string subject, string body, string from = "noreply@gmail.com");
    }
}