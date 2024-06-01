using TheHandymanOfCapeCod.Core.Models.MailService;

namespace TheHandymanOfCapeCod.Core.Contracts
{
    public interface IMailService
    {
        Task<bool> SendMailAsync(MailData mailData);
    }
}
