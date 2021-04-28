
using BlinkCard.Forms.Droid.Overlays;
using BlinkCard.Forms.Core.Overlays;
using BlinkCard.Forms.Core.Recognizers;
using Com.Microblink.Blinkcard.Uisettings;

namespace BlinkCard.Forms.Droid.Overlays
{
    public abstract class RecognizerCollectionOverlaySettings : OverlaySettings
    {
        public IRecognizerCollection RecognizerCollection { get; }

        protected RecognizerCollectionOverlaySettings(UISettings nativeUISettings, IRecognizerCollection recognizerCollection)
            : base(nativeUISettings)
        {
            RecognizerCollection = recognizerCollection;
        }
    }
}