namespace Bigon.Infrastructure.Services.Abstracts
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string email, string subject, string Bodymessage);
    }
}
