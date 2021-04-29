using Foundation;
using UIKit;

namespace BlinkCardFormsSample
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

            Xamarin.Forms.DependencyService.Register<BlinkCard.Forms.iOS.MicroblinkScannerFactoryImplementation>();

			LoadApplication (new BlinkCardApp.App());

			return base.FinishedLaunching (app, options);
		}
	}
}