using System;
using BlinkCard.Forms.Core;
using BlinkCard.Forms.Core.Overlays;
using BlinkCard.Forms.Core.Recognizers;

using Xamarin.Forms;

namespace BlinkCardApp
{
    public partial class BlinkCardPage : ContentPage
    {
        /// <summary>
        /// Microblink scanner is used for scanning the credit cards
        /// </summary>
        IMicroblinkScanner blinkCard;

        /// <summary>
        /// BlinkCard recognizer will be used for automatic detection and data extraction from the supported document.
        /// </summary>
        IBlinkCardRecognizer blinkCardRecognizer;

        public BlinkCardPage ()
        {
            InitializeComponent ();

            // before obtaining any of the recognizer's implementations from DependencyService, it is required
            // to obtain instance of IMicroblinkScanner and set the license key.
            // Failure to do so will crash your app.
            var microblinkFactory = DependencyService.Get<IMicroblinkScannerFactory>();

            // license keys are different for iOS and Android and depend on iOS bundleID/Android application ID
            // in your app, you may obtain the correct license key for your platform via DependencyService from
            // your Droid/iOS projects
            string licenseKey;

            // both these license keys are demo license keys for bundleID/applicationID com.microblink.sample
            if (Device.RuntimePlatform == Device.iOS)
            {
                licenseKey = "sRwAAAEVY29tLm1pY3JvYmxpbmsuc2FtcGxl1BIcP6dpSuS/37rVPcGKMeTrsgR8MahcSwwXAx7W+q4DISNxpyD6+I7UJwEXZY0idcmSKWVeQM6vHpTFfH7GFprdWTFfjlKyu60UtOHF0npdL2MmfTLta+7nnJRT28SshWOzbKsFOlZ0JJoeiZMEyM4znE2J6KFWNTsI8rIUfKoZvf1ZrPQRT1B+2AzIVrm6WmIIUKHsoHnmvNM424vPEBC4yhcWu2anECMkX8Li/Q==";
            }
            else
            {
                licenseKey = "sRwAAAAVY29tLm1pY3JvYmxpbmsuc2FtcGxlU9kJdZhZkGlTu9U3ORtGZDC+pgWPewByA2mcAQzqNk16/kWSp2nLRQjfkEuG9yGoE/K0LrodsEN7Al0N7WPru283evPr/SeAo6r28d9ctFxOdHMT/FZIbSE5cEhVCXABiq9jHegOrfRcCpHF2C2yyiqnzFkP2vYDvfkmVJaGssG3isYCB57Oz3HSW5DkORMbQjkFtiHIZvcUZGRMMBkeT1TmK1YwVz85q6XMgC3+QMLOhpbNsYZg2DsO1kgC6PcTmkdwweXNoXJw+9i7gfKw7M/4u3LCcXCoPpBilJJND+BW+Qr9L+zDj2t8WnxCOa5yAUiED9QlTss086BIkmxov3Fs";
            }

            // since DependencyService requires implementations to have default constructor, a factory is needed
            // to construct implementation of IMicroblinkScanner with given license key
            blinkCard = microblinkFactory.CreateMicroblinkScanner(licenseKey, true);

            // subscribe to scanning done message
            MessagingCenter.Subscribe<Messages.ScanningDoneMessage> (this, Messages.ScanningDoneMessageId, (sender) => {
                ImageSource fullDocumentFirstImageSource = null;
                ImageSource fullDocumentSecondImageSource = null;

                string stringResult = "No valid results.";

                // if user cancelled scanning, sender.ScanningCancelled will be true
                if (sender.ScanningCancelled)
                {
                    stringResult = "Scanning cancelled";
                }
                else
                {
                    // otherwise, one or more recognizers used in RecognizerCollection (see StartScan method below)
                    // will contain result

                    // if specific recognizer's result's state is Valid, then it contains data recognized from image
                    if (blinkCardRecognizer.Result.ResultState == RecognizerResultState.Valid)
                    {
                        var blinkCard = blinkCardRecognizer.Result;
                        stringResult =
                            "BlinkCard recognizer result:\n" +
                            BuildResult(blinkCard.CardNumber, "Card number") +
                            BuildResult(blinkCard.Owner, "Owner") +
                            BuildResult(blinkCard.CardNumberValid, "Card number valid") +
                            BuildResult(blinkCard.ExpiryDate, "Expiry date") +
                            BuildResult(blinkCard.Cvv, "CVV");

                        fullDocumentFirstImageSource = blinkCard.FirstSideFullDocumentImage;
                        fullDocumentSecondImageSource = blinkCard.SecondSideFullDocumentImage;
                    }

                }

                // updating the UI must be performed on main thread
                Device.BeginInvokeOnMainThread (() => {
                    resultsEditor.Text = stringResult;
                    fullDocumentFirstImage.Source = fullDocumentFirstImageSource;
                    fullDocumentSecondImage.Source = fullDocumentSecondImageSource;
                });

            });

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

        private string BuildResult(IDate result, string propertyName)
        {
            if (result == null || result.Year == 0)
            {
                return "";
            }

            DateTime date = new DateTime(result.Year, result.Month, 1);
            return propertyName + ": " + date.Year.ToString() + "/" + date.Month.ToString() + "\n";
        }

        /// <summary>
        /// Button click event handler that will start the scanning procedure.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void StartScan (object sender, EventArgs e)
        {
            // license keys must be set before creating Recognizer, othervise InvalidLicenseKeyException will be thrown
            // the following code creates and sets up implementation of MrtdRecognizer
            blinkCardRecognizer = DependencyService.Get<IBlinkCardRecognizer>(DependencyFetchTarget.NewInstance);
            blinkCardRecognizer.ReturnFullDocumentImage = true;

            // first create a recognizer collection from all recognizers that you want to use in recognition
            // if some recognizer is wrapped with SuccessFrameGrabberRecognizer, then you should use only the wrapped one
            var recognizerCollection = DependencyService.Get<IRecognizerCollectionFactory>().CreateRecognizerCollection(blinkCardRecognizer);

            // using recognizerCollection, create overlay settings that will define the UI that will be used
            // there are several available overlay settings classes in Microblink.Forms.Core.Overlays namespace
            // document overlay settings is best for scanning identity documents
            var blinkCardOverlaySettings = DependencyService.Get<IBlinkCardOverlaySettingsFactory>().CreateBlinkCardOverlaySettings(recognizerCollection);

            // start scanning
            blinkCard.Scan(blinkCardOverlaySettings);
        }
    }
}