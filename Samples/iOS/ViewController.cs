using System;

using UIKit;

using BlinkCard;

namespace iOS
{
	public partial class ViewController : UIViewController
	{
        // MBCBlinkCardRecognizer is used to scan all supported credit cards
        MBCBlinkCardRecognizer blinkCardRecognizer;

        // for more information: https://github.com/BlinkCard/blinkcard-ios

        CustomDelegate customDelegate;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

            customDelegate = new CustomDelegate(this);

            // set license key for iOS with bundle ID com.microblink.sample
            MBCMicroblinkSDK.SharedInstance().SetLicenseKey("sRwAAAEVY29tLm1pY3JvYmxpbmsuc2FtcGxl1BIcP6dpSuS/37rVPcGKMeTrsgR8MahcSwwXAx7W+q4DISNxpyD6+I7UJwEXZY0idcmSKWVeQM6vHpTFfH7GFprdWTFfjlKyu60UtOHF0npdL2MmfTLta+7nnJRT28SshWOzbKsFOlZ0JJoeiZMEyM4znE2J6KFWNTsI8rIUfKoZvf1ZrPQRT1B+2AzIVrm6WmIIUKHsoHnmvNM424vPEBC4yhcWu2anECMkX8Li/Q==", (licenseError) => {
                // here, you can check license error
            });
        }

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void StartScanningButton_TouchUpInside (UIButton sender)
		{
            blinkCardRecognizer = new MBCBlinkCardRecognizer();

            // create a collection of recognizers that will be used for scanning
            var recognizerCollection = new MBCRecognizerCollection(new MBCRecognizer[] { blinkCardRecognizer });

            // create a settings object for overlay that will be used. For credit card it's best to use BlinkCardOverlayViewController
            var blinkCardOverlaySettings = new MBCBlinkCardOverlaySettings();
            blinkCardOverlaySettings.EnableEditScreen = false;
            var blinkCardOverlay = new MBCBlinkCardOverlayViewController(blinkCardOverlaySettings, recognizerCollection, customDelegate);
            
            // finally, create a recognizerRunnerViewController
            var recognizerRunnerViewController = MBCViewControllerFactory.RecognizerRunnerViewControllerWithOverlayViewController(blinkCardOverlay);

            // in ObjC recognizerRunnerViewController would actually be of type UIViewController<MBRecognizerRunnerViewController>*, but this construct
            // is not supported in C#, so we need to use Runtime.GetINativeObject to cast obtained IMBCReocognizerRunnerViewController into UIViewController
            // that can be presented
            this.PresentViewController(ObjCRuntime.Runtime.GetINativeObject<UIViewController>(recognizerRunnerViewController.Handle, false), true, null);
		}

        class CustomDelegate : MBCBlinkCardOverlayViewControllerDelegate
        {
            ViewController me;

            public CustomDelegate(ViewController me)
            {
                this.me = me;
            }


            public override void BlinkCardOverlayViewControllerDidFinishScanning(MBCBlinkCardOverlayViewController blinkCardOverlayViewController, MBCRecognizerResultState state)
            {
                // this method is called on background processing thread. The scanning will resume as soon
                // as this method ends, so in order to have unchanged results at the time of displaying UIAlertView
                // pause the scanning
                blinkCardOverlayViewController.RecognizerRunnerViewController.PauseScanning();

                var title = "Result";
                var message = "";

                // we can check ResultState property of the Result to see if the result contains scanned information
                if (me.blinkCardRecognizer.Result.ResultState == MBCRecognizerResultState.Valid)
                {
                    var blinkCardResult = me.blinkCardRecognizer.Result;
                    message += "BlinkCard recognizer result:\n" +
                        BuildResult(blinkCardResult.CardNumber, "Card number") +
                        BuildResult(blinkCardResult.Owner, "Owner") +
                        BuildResult(blinkCardResult.ExpiryDate, "Expiry date") +
                        BuildResult(blinkCardResult.CardNumberValid, "Card number valid") +
                        BuildResult(blinkCardResult.Cvv, "CVV");
                }

                UIApplication.SharedApplication.InvokeOnMainThread(delegate
                {
                    UIAlertView alert = new UIAlertView()
                    {
                        Title = title,
                        Message = message
                    };
                    alert.AddButton("OK");
                    alert.Show();
                    // after alert dialog is dismissed, you can either resume scanning with 
                    // documentOverlayViewController.RecognizerRunnerViewController.ResumeScanningAndResetState(true)
                    // or you can simply dismiss the RecognizerRunnerViewController
                    alert.Dismissed += (sender, e) => me.DismissViewController(true, null);
                });
            }

            public override void BlinkCardOverlayViewControllerDidTapClose(MBCBlinkCardOverlayViewController blinkCardOverlayViewController)
            {
                me.DismissViewController(true, null);
            }

            private string BuildResult(string result, string propertyName)
            {
                if (result == null || result.Length == 0)
                {
                    return "";
                }

                return propertyName + ": " + result + "\n";
            }

            private string BuildResult(Boolean result, string propertyName)
            {
                if (result)
                {
                    return propertyName + ": YES" + "\n";
                }

                return propertyName + ": NO" + "\n";
            }

            private string BuildResult(int result, string propertyName)
            {
                if (result < 0)
                {
                    return "";
                }

                return propertyName + ": " + result + "\n";
            }

            private string BuildResult(MBCDateResult result, string propertyName)
            {
                if (result == null || result.Year == 0)
                {
                    return "";
                }

                return propertyName + ": " + result.OriginalDateString + "\n";
            }
        }
	}
}