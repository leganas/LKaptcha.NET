using System.Drawing;

namespace LKaptchaNET.Services.FontGenerator
{
    public interface IFontGeneratorService
    {
        Font GetFont(float scale);
        float GetSpacing(int width);
    }
}
