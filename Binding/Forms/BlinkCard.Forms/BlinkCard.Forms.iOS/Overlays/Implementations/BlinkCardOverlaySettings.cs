using BlinkCard.Forms.iOS.Overlays;
using BlinkCard.Forms.iOS.Recognizers;
using BlinkCard.Forms.Core.Overlays;
using BlinkCard.Forms.Core.Recognizers;
using BlinkCard;

[assembly: Xamarin.Forms.Dependency(typeof(BlinkCardOverlaySettingsFactory))]
namespace BlinkCard.Forms.iOS.Overlays
{
    public sealed class BlinkCardOverlaySettings : RecognizerCollectionOverlaySettings, IBlinkCardOverlaySettings
    {
        readonly MBCBlinkCardOverlaySettings nativeBlinkCardOverlaySettings;

        // this ensures GC does not collect delegate proxy while it is used by ObjC
        BlinkCardOverlayVCDelegate blinkCardOverlayVCDelegate;

        public BlinkCardOverlaySettings(IRecognizerCollection recognizerCollection)
            : base(new MBCBlinkCardOverlaySettings(), recognizerCollection)
        {
            nativeBlinkCardOverlaySettings = NativeOverlaySettings as MBCBlinkCardOverlaySettings;
            nativeBlinkCardOverlaySettings.EnableEditScreen = false;
        }

        public override MBCOverlayViewController CreateOverlayViewController(IOverlayVCDelegate overlayVCDelegate)
        {
            blinkCardOverlayVCDelegate = new BlinkCardOverlayVCDelegate(overlayVCDelegate);
            return new MBCBlinkCardOverlayViewController(nativeBlinkCardOverlaySettings, (RecognizerCollection as RecognizerCollection).NativeRecognizerCollection, blinkCardOverlayVCDelegate);
        }

        public string FirstSideInstructions { get; set; }

        public string FlipCardInstructions {
            get {
                return nativeBlinkCardOverlaySettings.BackSideMessage;
            }
            set {
                nativeBlinkCardOverlaySettings.BackSideMessage = value;
            }
        }

        public bool ShowFlashlightWarning {
		get {
			return nativeBlinkCardOverlaySettings.ShowFlashlightWarning;
		}
		set {
			nativeBlinkCardOverlaySettings.ShowFlashlightWarning = value;
		}
        }
    }

    public sealed class BlinkCardOverlaySettingsFactory : IBlinkCardOverlaySettingsFactory
    {
        public IBlinkCardOverlaySettings CreateBlinkCardOverlaySettings(IRecognizerCollection recognizerCollection)
        {
            return new BlinkCardOverlaySettings(recognizerCollection);
        }
    }

    public sealed class BlinkCardOverlayVCDelegate : MBCBlinkCardOverlayViewControllerDelegate
    {
        readonly IOverlayVCDelegate overlayVCDelegate;

        public BlinkCardOverlayVCDelegate(IOverlayVCDelegate overlayVCDelegate)
        {
            this.overlayVCDelegate = overlayVCDelegate;
        }

        public override void BlinkCardOverlayViewControllerDidFinishScanning(MBCBlinkCardOverlayViewController blinkCardOverlayViewController, MBCRecognizerResultState state)
        {
            overlayVCDelegate.ScanningFinished(blinkCardOverlayViewController, state);
        }

        public override void BlinkCardOverlayViewControllerDidTapClose(MBCBlinkCardOverlayViewController blinkCardOverlayViewController)
        {
            overlayVCDelegate.CloseButtonTapped(blinkCardOverlayViewController);
        }
    }
}