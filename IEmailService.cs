using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using DotNetEnv;

namespace SalesApp
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string body);
    }

    public class EmailService : IEmailService
    {
        public EmailService()
        {
            // Загрузка переменных из .env файла
            DotNetEnv.Env.Load();
        }

        public async Task SendEmailAsync(string email, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Your Name", "your-email@example.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;

            message.Body = new TextPart("html")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                string smtpServer = Env.GetString("SMTP_SERVER");
                int smtpPort = Env.GetInt("SMTP_PORT");
                string smtpUsername = Env.GetString("SMTP_USERNAME");
                string smtpPassword = Env.GetString("SMTP_PASSWORD");

                await client.ConnectAsync(smtpServer, smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(smtpUsername, smtpPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
