
using BlinkCard.Forms.iOS.Overlays;
using BlinkCard.Forms.Core.Overlays;
using BlinkCard.Forms.Core.Recognizers;
using BlinkCard;

namespace BlinkCard.Forms.iOS.Overlays
{
	public abstract class RecognizerCollectionOverlaySettings : BaseOverlaySettings
    {
        public IRecognizerCollection RecognizerCollection { get; }

        protected RecognizerCollectionOverlaySettings(MBCBaseOverlaySettings nativeOverlaySettings, IRecognizerCollection recognizerCollection) : base(nativeOverlaySettings)
        {
            RecognizerCollection = recognizerCollection;
        }
    }
}