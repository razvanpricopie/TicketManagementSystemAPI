using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Contracts.Infrastructure;
using TicketManagementSystemAPI.Application.Models.Mail;

namespace TicketManagementSystemAPI.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        private EmailSettings _mailSettings { get; }

        public EmailService(IOptions<EmailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            SendGridClient client = new SendGridClient(_mailSettings.ApiKey);

            string subject = email.Subject;
            EmailAddress to = new EmailAddress(email.To);
            string emailBody = email.Body;

            EmailAddress from = new EmailAddress
            {
                Email = _mailSettings.FromAddress,
                Name = _mailSettings.FromName
            };

            SendGridMessage sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            Response response = await client.SendEmailAsync(sendGridMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;

            return false;
        }
    }
}
