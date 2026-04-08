using System;
using System.Threading.Tasks;

namespace LKaptchaNET.Services.Storage
{
    public interface ICaptchaStorageService
    {
        Guid SaveCaptcha(Captcha captcha);
        Task<Guid> SaveCaptchaAsync(Captcha captcha);

        Captcha GetCaptcha(Guid id);
        Task<Captcha> GetCaptchaAsync(Guid id);
    }
}
