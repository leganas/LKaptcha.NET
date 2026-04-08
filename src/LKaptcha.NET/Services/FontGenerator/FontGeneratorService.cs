using System;
using System.Drawing;
using Microsoft.Extensions.Options;

namespace LKaptchaNET.Services.FontGenerator
{
    using LKaptchaNET.Options;

    public class FontGeneratorService : IFontGeneratorService
    {
        private readonly FontOptions _fontOptions;
        private static readonly Random _rnd = new Random();

        public FontGeneratorService(IOptions<FontOptions> fontOptions)
        {
            _fontOptions = fontOptions.Value;
        }

        public Font GetFont(float scale)
        {
            int max = (int)Math.Truncate(_fontOptions.MaxSize * scale);
            int min = (int)Math.Truncate(_fontOptions.MinSize * scale);
            int size = _rnd.Next(min, max);
            return new Font(_fontOptions.FontFamily, size, _fontOptions.FontStyle);
        }

        public float GetSpacing(int width)
        {
            return width * _fontOptions.Spacing;
        }
    }
}
