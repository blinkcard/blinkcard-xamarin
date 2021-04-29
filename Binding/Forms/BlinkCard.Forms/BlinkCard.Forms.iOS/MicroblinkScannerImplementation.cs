using Xamarin.Forms;
using BlinkCard.Forms.iOS;
using UIKit;
using BlinkCard.Forms.Core.Overlays;
using BlinkCard.Forms.iOS.Overlays;
using BlinkCard.Forms.Core.Recognizers;
using BlinkCard.Forms.Core;
using BlinkCard.Forms.iOS.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MicroblinkScannerFactoryImplementation))]
namespace BlinkCard.Forms.iOS
{
    public sealed class MicroblinkScannerImplementation : IMicroblinkScanner, IOverlayVCDelegate
    {
        // ensure RecognizerRunnerVC does not get GC-ed while it is required for ObjC code
        IMBCRecognizerRunnerViewController recognizerRunnerViewController;
        // ensure OverlaySettings don't get GC-ed while they are required for ObjC code
        IOverlaySettings overlaySettings;

        public MicroblinkScannerImplementation(string licenseKey, string licensee, bool showTrialLicenseWarning)
        {
            MBCMicroblinkSDK.SharedInstance().ShowTrialLicenseWarning = showTrialLicenseWarning;
            if (licensee == null)
            {
                MBCMicroblinkSDK.SharedInstance().SetLicenseKey(licenseKey, (licenseError) => {
                    // here, you can check license error
                });
            }
            else
            {
                MBCMicroblinkSDK.SharedInstance().SetLicenseKey(licenseKey, licensee, (licenseError) => {
                    // here, you can check license error
                });
            }
        }

        public void Scan(IOverlaySettings overlaySettings)
        {
            this.overlaySettings = overlaySettings;
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;

            recognizerRunnerViewController = MBCViewControllerFactory.RecognizerRunnerViewControllerWithOverlayViewController(((OverlaySettings)overlaySettings).CreateOverlayViewController(this));

            vc.PresentViewController(ObjCRuntime.Runtime.GetINativeObject<UIViewController>(recognizerRunnerViewController.Handle, false), true, null);
        }

        public void ScanningFinished(MBCOverlayViewController overlayViewController, MBCRecognizerResultState state)
        {
            overlayViewController.RecognizerRunnerViewController.PauseScanning();

            UIApplication.SharedApplication.InvokeOnMainThread(delegate {
                MessagingCenter.Send(new BlinkCard.Forms.Core.Messages.ScanningDoneMessage { ScanningCancelled = false }, BlinkCard.Forms.Core.Messages.ScanningDoneMessageId);
                overlayViewController.DismissViewController(true, null);
            });
        }

        public void CloseButtonTapped(MBCOverlayViewController overlayViewController)
        {
            MessagingCenter.Send(new BlinkCard.Forms.Core.Messages.ScanningDoneMessage { ScanningCancelled = true }, BlinkCard.Forms.Core.Messages.ScanningDoneMessageId);
            overlayViewController.DismissViewController(true, null);
        }

    }

    public sealed class MicroblinkScannerFactoryImplementation : IMicroblinkScannerFactory
    {
        public IMicroblinkScanner CreateMicroblinkScanner(string licenseKey, bool showTrialLicenseWarning)
        {
            return new MicroblinkScannerImplementation(licenseKey, null, showTrialLicenseWarning);
        }

        public IMicroblinkScanner CreateMicroblinkScanner(string licenseKey, string licensee, bool showTrialLicenseWarning)
        {
            return new MicroblinkScannerImplementation(licenseKey, licensee, showTrialLicenseWarning);
        }
    }
}