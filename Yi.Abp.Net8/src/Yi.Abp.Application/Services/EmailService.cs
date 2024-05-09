
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

using Volo.Abp.Emailing;

namespace Yi.Abp.Application.Services

{
    public class EmailService : ApplicationService, ITransientDependency
    {
        private readonly IEmailSender _emailSender;
        public EmailService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task DoItAsync()
        {
            await _emailSender.SendAsync(
                "1179949027@qq.com",     // target email address
                "Email subject",         // subject
                "This is email body..."  // email body
            );
        }


    }
}
