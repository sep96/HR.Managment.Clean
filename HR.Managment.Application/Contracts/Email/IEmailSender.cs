using HR.Managment.Application.Model.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailMessage email);
    }
}
