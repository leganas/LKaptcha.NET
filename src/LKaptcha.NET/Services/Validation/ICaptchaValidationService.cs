using System.Threading.Tasks;

namespace LKaptchaNET.Services.Validation
{
    public interface ICaptchaValidationService
    {
        Task ValidateAsync(CaptchaParameters parameters, string solution);

        string ValidationMessage { get; }
    }
}
