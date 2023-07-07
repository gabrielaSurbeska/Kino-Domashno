using Kino.Domain.DomainModels;
using Kino.Repository.Interface;
using Kino.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Kino.Services.Implementation
{
    public class EmailSender:IEmailSender
    {
        private readonly IEmailService _emailService;
        private readonly IRepository<EmailMessage> _messageRepository;

        public EmailSender(IEmailService emailService, IRepository<EmailMessage> messageRepository)
        {
            _emailService = emailService;
            _messageRepository = messageRepository;
        }

        public async Task SendEmail()
        {
           await _emailService.SendEmailAsync(_messageRepository.GetAll().Where(e=>!e.Status).ToList());
        }
    }
}
