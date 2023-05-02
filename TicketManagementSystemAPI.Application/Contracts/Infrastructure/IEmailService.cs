using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystemAPI.Application.Models.Mail;

namespace TicketManagementSystemAPI.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
