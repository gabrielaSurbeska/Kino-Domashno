using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Services.Interface
{
    public interface IEmailSender
    {
        Task SendEmail();
    }
}
