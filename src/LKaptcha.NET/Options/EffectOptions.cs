using System.Collections.Generic;

namespace LKaptchaNET.Options
{
    using LKaptchaNET.Effects;

    public class EffectOptions : Dictionary<string, bool>
    {
        public EffectOptions()
        {
            this.Add(nameof(BlobEffect), false);
            this.Add(nameof(BoxEffect), false);
            this.Add(nameof(LineEffect), true);
            this.Add(nameof(NoiseEffect), true);
            this.Add(nameof(RippleEffect), true);
            this.Add(nameof(WaveEffect), false);
        }
    }
}
