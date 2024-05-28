namespace BigonApp.Helpers.Services
{
    public interface IEmailService
    {
       Task<bool> SendEmailAsync(string email, string subject, string Bodymessage);
    }
}
