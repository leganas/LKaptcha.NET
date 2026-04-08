using System.Drawing;

namespace LKaptchaNET.Services.Effect
{
    public interface IEffectGeneratorService
    {
        Bitmap ApplyForegroundEffects(Bitmap image);

        Bitmap ApplyBackgroundEffects(Bitmap image);
    }
}
