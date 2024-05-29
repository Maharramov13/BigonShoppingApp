using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace BigonShoppingApp.Servicers.email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> SendAsync(string to, string title, string body, bool isHTML = true)
        {
            try
            {
                var message = new MailMessage();
                message.IsBodyHtml = isHTML;
                message.Body = body;
                message.Subject = title;
                message.To.Add(to);

                Console.WriteLine(_configuration["Mail:Email"]);
                message.From = new MailAddress(_configuration["Mail:Email"], "Bigon", System.Text.Encoding.UTF8);
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Credentials = new NetworkCredential(_configuration["Mail:Email"], _configuration["Mail:Password"]);
                smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                smtpClient.Host = _configuration["Mail:Host"];
                await smtpClient.SendMailAsync(message);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
