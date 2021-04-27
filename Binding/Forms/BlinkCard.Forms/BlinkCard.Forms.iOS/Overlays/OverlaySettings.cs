
using BlinkCard.Forms.iOS.Overlays;
using BlinkCard.Forms.Core.Overlays;
using BlinkCard.Forms.Core.Recognizers;
using BlinkCard;

namespace BlinkCard.Forms.iOS.Overlays
{
	public abstract class OverlaySettings : IOverlaySettings
    {
        public MBCOverlaySettings NativeOverlaySettings { get; }

        protected OverlaySettings(MBCOverlaySettings nativeOverlaySettings)
        {
            NativeOverlaySettings = nativeOverlaySettings;
        }

        public bool UseFrontCamera
        {
            get
            {
                return NativeOverlaySettings.CameraSettings.CameraType == MBCCameraType.Front;
            }
            set
            {
                if (value) {
                    NativeOverlaySettings.CameraSettings.CameraType = MBCCameraType.Front;
                }
                else
                {
                    NativeOverlaySettings.CameraSettings.CameraType = MBCCameraType.Back;
                }
                
            }
        }

        public abstract MBCOverlayViewController CreateOverlayViewController(IOverlayVCDelegate overlayVCDelegate);
    }
}