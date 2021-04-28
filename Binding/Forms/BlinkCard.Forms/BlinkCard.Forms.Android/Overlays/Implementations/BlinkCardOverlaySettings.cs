using System;
using Android.Content;
using Com.Microblink.Blinkcard.Uisettings;
using Com.Microblink.Blinkcard.Fragment.Overlay.Blinkcard.Scanlineui;
using BlinkCard.Forms.Core.Overlays;
using BlinkCard.Forms.Core.Recognizers;
using BlinkCard.Forms.Droid.Overlays.Implementations;
using BlinkCard.Forms.Droid.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BlinkCardOverlaySettingsFactory))]
namespace BlinkCard.Forms.Droid.Overlays.Implementations
{
    public sealed class BlinkCardOverlaySettings : RecognizerCollectionOverlaySettings, IBlinkCardOverlaySettings
    {
        public override UISettings NativeUISettings { 
            get {
                var concreteUISettings = (BlinkCardUISettings)base.NativeUISettings;
                var overlayStringsBuilder = new ScanLineOverlayStrings.Builder(Android.App.Application.Context);
                if (FirstSideInstructions != null) {
                    overlayStringsBuilder.SetFrontSideInstructions(FirstSideInstructions);
                }
                if (FlipCardInstructions != null) {
                    overlayStringsBuilder.SetFlipCardInstructions(FlipCardInstructions);
                }
                concreteUISettings.SetStrings(overlayStringsBuilder.Build());
                concreteUISettings.SetShowGlareWarning(ShowFlashlightWarning);
                concreteUISettings.EditScreenEnabled = false;
                return concreteUISettings;
            }
        }

        public string FirstSideInstructions { get; set; }

        public string FlipCardInstructions { get; set; }

        public bool ShowFlashlightWarning { get; set; } = true;

        public BlinkCardOverlaySettings(IRecognizerCollection recognizerCollection)
            : base(new BlinkCardUISettings((recognizerCollection as RecognizerCollection).NativeRecognizerBundle), recognizerCollection)
        {}
    }

    public sealed class BlinkCardOverlaySettingsFactory : IBlinkCardOverlaySettingsFactory
    {
        public IBlinkCardOverlaySettings CreateBlinkCardOverlaySettings(IRecognizerCollection recognizerCollection)
        {
            return new BlinkCardOverlaySettings(recognizerCollection);
        }
    }
}