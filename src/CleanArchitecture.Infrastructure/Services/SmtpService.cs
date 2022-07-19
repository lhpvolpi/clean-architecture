using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Services;
using CleanArchitecture.Infrastructure.Common;
using MailKit.Net.Smtp;
using MimeKit;

namespace CleanArchitecture.Infrastructure.Services
{
    public class SmtpService : ISmtpService
    {
        private readonly ISmtpSettings _smtpSettings;

        public SmtpService(ISmtpSettings smtpSettings)
            => this._smtpSettings = smtpSettings;

        public async Task SendAsync(Mail mail)
        {
            var message = CreateMailMessage(mail);

            using var smtp = new SmtpClient();

            smtp.Connect(this._smtpSettings.Host, this._smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(this._smtpSettings.From, this._smtpSettings.Password);

            await smtp.SendAsync(message);

            smtp.Disconnect(true);
        }

        private MimeMessage CreateMailMessage(Mail mail)
        {
            var message = new MimeMessage
            {
                Subject = mail.Subject,
                Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = mail.Body }
            };

            message.From.Add(MailboxAddress.Parse(this._smtpSettings.From));
            message.To.Add(MailboxAddress.Parse(mail.To));

            return message;
        }
    }
}

