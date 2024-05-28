using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;

namespace BigonApp.Helpers.Services
{
    public class EmailService:SmtpClient,IEmailService
    {
        private readonly EmailOptions _options;
        public EmailService(IOptions<EmailOptions> options)
        {
            _options = options.Value;
            Host = _options.SmtpServer;
            Port=_options.Port;
            EnableSsl = true;
            Credentials = new NetworkCredential(_options.FromAddress, _options.Password);
        }
        public async Task<bool> SendEmailAsync(string email, string subject, string Bodymessage)
        {
            try
            {
                using MailMessage message = new();
                message.Subject = subject;
                message.To.Add(email);
                message.IsBodyHtml = true;
                message.From = new MailAddress(_options.FromAddress, _options.FromName);
                message.Body = Bodymessage;
                await base.SendMailAsync(message);
            }
            catch(Exception)
            {
                return false;
            }
            return true;    
        }
    }
}
