using System;
using System.Text;
using Microsoft.Extensions.Options;

namespace LKaptchaNET.Services.KeyGenerator
{
    using LKaptchaNET.Options;

    public class KeyGeneratorService : IKeyGeneratorService
    {
        private static readonly Random _rnd = new Random();
        private readonly CaptchaOptions _captchaOptions;

        public KeyGeneratorService(IOptions<CaptchaOptions> captchaOptions)
        {
            _captchaOptions = captchaOptions?.Value;
        }
        public string GenerateKey()
        {
            var sb = new StringBuilder();
            int wordLength = _rnd.Next(_captchaOptions.MinWordLength, _captchaOptions.MaxWordLength);
            for (int i = 0; i < wordLength; i++)
            {
                sb.Append(_captchaOptions.Charset[_rnd.Next(0, _captchaOptions.Charset.Length)]);
            }
            return sb.ToString();
        }
    }
}
