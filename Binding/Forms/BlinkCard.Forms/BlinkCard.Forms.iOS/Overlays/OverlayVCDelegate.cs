using BlinkCard;

namespace BlinkCard.Forms.iOS.Overlays
{
    public interface IOverlayVCDelegate
    {
        void ScanningFinished(MBCOverlayViewController overlayViewController, MBCRecognizerResultState state);

        void CloseButtonTapped(MBCOverlayViewController overlayViewController);
    }
}