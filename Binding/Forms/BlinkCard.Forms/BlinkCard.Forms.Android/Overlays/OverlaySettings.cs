
using BlinkCard.Forms.Droid.Overlays;
using BlinkCard.Forms.Core.Overlays;
using BlinkCard.Forms.Core.Recognizers;
using BlinkCard.Forms.Droid;
using Com.Microblink.Blinkcard.Uisettings;
using Com.Microblink.Blinkcard.Uisettings.Options;
using Com.Microblink.Blinkcard.Hardware.Camera;

namespace BlinkCard.Forms.Droid.Overlays
{
    public abstract class OverlaySettings : IOverlaySettings, IScanSoundOverlaySettings
    {
        private readonly UISettings _nativeUISEttings;

        public virtual UISettings NativeUISettings { 
            get {
                CameraSettings cameraSettings = null;
                if (UseFrontCamera) {
                     cameraSettings = new CameraSettings.Builder().SetType(CameraType.CameraFrontface).Build();
                } else {
                    cameraSettings = new CameraSettings.Builder().SetType(CameraType.CameraDefault).Build();
                }
                _nativeUISEttings.SetCameraSettings(cameraSettings);

                IBeepSoundUIOptions beepSoundOptions = _nativeUISEttings as IBeepSoundUIOptions;
                if (beepSoundOptions != null) {
                    if (EnableBeep) {
                        beepSoundOptions.SetBeepSoundResourceID(Resource.Raw.beep);
                    } else {
                        beepSoundOptions.SetBeepSoundResourceID(0);
                    }
                }
                return _nativeUISEttings;
            }
        }

        protected OverlaySettings(UISettings nativeUISettings)
        {
            _nativeUISEttings = nativeUISettings;
        }

        public bool UseFrontCamera { get; set; } = false;

        public bool EnableBeep { get; set; } = false;
    }
}