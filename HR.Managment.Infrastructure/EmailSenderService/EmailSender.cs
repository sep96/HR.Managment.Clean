using HR.Managment.Application.Contracts.Email;
using HR.Managment.Application.Model.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Infrastructure.EmailSenderService
{
    public class EmailSender : IEmailSender
    {
        public EmailSetting _emailSetting;

        public EmailSender(IOptions<EmailSetting> emailSetting)
        {
            _emailSetting = emailSetting.Value;
        }

        public async Task<bool> SendEmail(EmailMessage email)
        {
            var client = new SendGridClient(_emailSetting.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _emailSetting.FromAddress,
                Name = _emailSetting.FromName
            };
            var message = MailHelper.CreateSingleEmail(from , to , email.Subject, email.Body ,email.Body );
            var resonse = await client.SendEmailAsync(message);
            return resonse.IsSuccessStatusCode;
        }
    }
}
