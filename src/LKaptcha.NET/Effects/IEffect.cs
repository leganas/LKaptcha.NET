using System.Drawing;

namespace LKaptchaNET.Effects
{
    public interface IEffect
    {
        short Order { get; }

        EffectType Type { get; }

        Bitmap Apply(Bitmap image);
    }
}
