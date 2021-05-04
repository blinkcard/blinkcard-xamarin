using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.PM;

using Android.Content;

using Com.Microblink.Blinkcard.Entities.Recognizers;
using Com.Microblink.Blinkcard.Util;
using Com.Microblink.Blinkcard;
using Com.Microblink.Blinkcard.Intent;
using Com.Microblink.Blinkcard.Uisettings;
using Android.Runtime;
using Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard;
using Com.Microblink.Blinkcard.Results.Date;

namespace Android
{
    [Activity(Label = "BlinkCard Xamarin", MainLauncher = true, Icon = "@mipmap/icon", HardwareAccelerated = true)]
    public class MainActivity : Activity
    {
        const int ACTIVITY_REQUEST_ID = 101;

        // BlinkCardRecognizer is used for automatic classification and data extraction from the supported
        // payment card
        BlinkCardRecognizer blinkCardRecognizer;

        // RecognizerBundle is required for transferring recognizers via Intent to another activity
        // and for loading results from them back.
        RecognizerBundle recognizerBundle;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            RequestedOrientation = ScreenOrientation.Portrait;

            Button button = FindViewById<Button>(Resource.Id.startScanningButton);

            // Setup BlinkCard before usage
            initBlinkCard();

            // check if BlinkCard is supported on current device. Device needs to have camera with autofocus.
            if (RecognizerCompatibility.GetRecognizerCompatibilityStatus(this) != RecognizerCompatibilityStatus.RecognizerSupported)
            {
                button.Enabled = false;
                Toast.MakeText(this, "BlinkCard is not supported!", ToastLength.Long).Show();
            }
            else
            {
                button.Click += delegate {
                    // create a settings object for activity that will be used
                    var blinkCardUISettings = new BlinkCardUISettings(recognizerBundle);

                    // start activity associated with given UI settings. After scanning completes,
                    // OnActivityResult will be invoked
                    ActivityRunner.StartActivityForResult(this, ACTIVITY_REQUEST_ID, blinkCardUISettings);
                };
            }
        }

        private void initBlinkCard()
        {
            // set license key for Android with package name com.microblink.sample
            MicroblinkSDK.SetLicenseKey("sRwAAAAVY29tLm1pY3JvYmxpbmsuc2FtcGxlU9kJdb5ZkGlTu623OXxCZAobpIusBmuyUQMA9/t6Rw1i5tRcC8Bme/1kN6nQqjUc6YE60O2TCPy+tjaxJkZjj6fzwH+MGC8tDu2P2mk/S1pjoL6LQtE7wHXNiPi3H3er/xl1vhYOjr3DstYb67zyztxOawLGMTsfSF1qAK7T6HD50ppcpkHZ7uuyqWTFAxT6MW6GbZpod6cz6r0e3aAc/W313pw8euZu6LxkzM2q9Q==", this);

            // Since we plan to transfer large data between activities, we need to enable
            // PersistedOptimised intent data transfer mode.
            // for more information about transfer mode, check android documentation: https://github.com/blinkcard/blinkcard-android#-passing-recognizer-objects-between-activities
            MicroblinkSDK.IntentDataTransferMode = IntentDataTransferMode.PersistedOptimised;

            // create recognizer and bundle it into RecognizerBundle
            blinkCardRecognizer = new BlinkCardRecognizer();
            blinkCardRecognizer.SetReturnFullDocumentImage(true);

            recognizerBundle = new RecognizerBundle(blinkCardRecognizer);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == ACTIVITY_REQUEST_ID && resultCode == Result.Ok)
            {

                // obtain image view that will display image of the document
                ImageView documentImageFrontView = this.FindViewById<ImageView>(Resource.Id.documentImageFrontView);
                ImageView documentImageBackView = this.FindViewById<ImageView>(Resource.Id.documentImageBackView);

                // unfortunately, C# does not support covariant return types, so binding
                // of AAR loses the return type of the Java's GetResult method. Therefore, a cast is required.
                // This is always a safe cast, since the original object in Java is of correct type - type
                // information was lost during conversion to C# due to https://github.com/xamarin/java.interop/pull/216
                var blinkCardResult = (BlinkCardRecognizer.Result)blinkCardRecognizer.GetResult();

                var message = "";

                // we can check ResultState property of the Result to see if the result contains scanned information
                if (blinkCardResult.ResultState == Recognizer.Result.State.Valid)
                {
                    message += "BlinkCard recognizer result:\n" +
                        BuildResult(blinkCardResult.Issuer.Name(), "Issuer") +
                        BuildResult(blinkCardResult.CardNumber, "CardNumber") +
                        BuildResult(blinkCardResult.IsCardNumberValid, "CardNumberValid") +
                        BuildResult(blinkCardResult.CardNumberPrefix, "CardNumberPrefix") +
                        BuildResult(blinkCardResult.Cvv, "CVV") +
                        BuildResult(blinkCardResult.Iban, "IBAN") +
                        BuildResult(blinkCardResult.ExpiryDate.Date, "DateOfExpiry");

                    // show full document images
                    if (blinkCardResult.FirstSideFullDocumentImage != null)
                    {
                        documentImageFrontView.SetImageBitmap(blinkCardResult.FirstSideFullDocumentImage.ConvertToBitmap());
                    }
                    else
                    {
                        documentImageFrontView.SetImageResource(0);
                    }
                    if (blinkCardResult.SecondSideFullDocumentImage != null)
                    {
                        documentImageBackView.SetImageBitmap(blinkCardResult.SecondSideFullDocumentImage.ConvertToBitmap());
                    }
                    else
                    {
                        documentImageBackView.SetImageResource(0);
                    }

                }

                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("BlinkCard Results");
                alert.SetPositiveButton("OK", (senderAlert, args) => { });
                alert.SetMessage(message);
                alert.Show();
            }
        }

        private string BuildResult(string result, string propertyName)
        {
            if (result == null || result.Length == 0)
            {
                return "";
            }

            return propertyName + ": " + result + "\n";
        }

        private string BuildResult(bool result, string propertyName)
        {
            if (result)
            {
                return propertyName + ": YES" + "\n";
            }

            return propertyName + ": NO" + "\n";
        }

        private string BuildResult(Date result, string propertyName)
        {
            if (result == null || result.Year == 0)
            {
                return "";
            }
            return propertyName + ": " + result.Year.ToString() + "/" + result.Month.ToString("D2") + "\n";
        }

    }
}


