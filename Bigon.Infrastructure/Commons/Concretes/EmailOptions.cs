namespace Bigon.Infrastructure.Commons.Concretes
{
    public class EmailOptions
    {
        public string SmtpServer { get; set; }
        public short Port { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
        public string Password { get; set; }

    }
}
