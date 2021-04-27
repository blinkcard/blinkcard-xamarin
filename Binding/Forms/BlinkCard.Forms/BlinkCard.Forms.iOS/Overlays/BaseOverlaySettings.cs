
using BlinkCard.Forms.iOS.Overlays;
using BlinkCard.Forms.Core.Overlays;
using BlinkCard.Forms.Core.Recognizers;
using BlinkCard;

namespace BlinkCard.Forms.iOS.Overlays
{
	public abstract class BaseOverlaySettings : OverlaySettings, IScanSoundOverlaySettings
    {
        public MBCBaseOverlaySettings baseOverlaySettings { get; }

        protected BaseOverlaySettings(MBCBaseOverlaySettings baseOverlaySettings): base(baseOverlaySettings)
        {
            this.baseOverlaySettings = baseOverlaySettings;
        }

        public bool EnableBeep
        {
            get
            {
                return baseOverlaySettings.SoundFilePath == "";
            }
            set
            {
                if (value)
                {
                    string path = MBCMicroblinkApp.SharedInstance().ResourcesBundle.PathForResource("PPbeep", "wav");
                    baseOverlaySettings.SoundFilePath = path;
                }
                else
                {
                    baseOverlaySettings.SoundFilePath = "";
                }
            }
        }
    }
}