using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace MyFirstServerSideBlazor.Servises
{
    public class EmailServise : IEmailServise
    {   

        public async Task SendMail(string[] emails, string subject, string message)
        {
            using var mailMessage = new MimeMessage();

            mailMessage.From.Add(new MailboxAddress("Emilis","Emeilaszx@gmail.com"));

            foreach (var email in emails)
            {
                mailMessage.To.Add(new MailboxAddress(email,email));
            }

            mailMessage.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                TextBody = message,
                HtmlBody = message
            };

            mailMessage.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();

            await client.ConnectAsync("smtp.sendgrid.net", 587, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(
                userName: "apikey", 
                password: "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" 
            );

            await client.SendAsync(mailMessage);

            await client.DisconnectAsync(true);
        }
    }
}
