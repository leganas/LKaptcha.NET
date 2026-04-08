using System.Threading.Tasks;

namespace LKaptchaNET.Services.CaptchaGenerator
{
    using LKaptchaNET.Options;

    public interface ICaptchaGeneratorService
    {
        CaptchaOptions Options { get; }

        Task<Captcha> CreateCaptchaAsync();
    }
}
