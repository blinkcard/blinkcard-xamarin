using System;
using AVFoundation;
using CoreAnimation;
using CoreGraphics;
using CoreMedia;
using CoreVideo;
using Foundation;
using BlinkCard;
using ObjCRuntime;
using UIKit;
// using System.Runtime.InteropServices;

namespace BlinkCard
{
    // typedef void (^MBCBlock)();
	delegate void MBCBlock ();

    // @interface MBCMicroblinkApp : NSObject
	[BaseType (typeof(NSObject))]
	interface MBCMicroblinkApp
	{
		// @property (nonatomic) NSString * language;
		[Export ("language")]
		string Language { get; set; }

		// @property (nonatomic) NSBundle * resourcesBundle;
		[Export ("resourcesBundle", ArgumentSemantic.Assign)]
		NSBundle ResourcesBundle { get; set; }

		// @property (nonatomic) NSBundle * customResourcesBundle;
		[Export ("customResourcesBundle", ArgumentSemantic.Assign)]
		NSBundle CustomResourcesBundle { get; set; }

		// @property (nonatomic) NSString * customLocalizationFileName;
		[Export ("customLocalizationFileName")]
		string CustomLocalizationFileName { get; set; }

		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		MBCMicroblinkApp SharedInstance ();

		// -(void)setDefaultLanguage;
		[Export ("setDefaultLanguage")]
		void SetDefaultLanguage ();

		// -(void)pushStatusBarStyle:(UIStatusBarStyle)statusBarStyle;
		[Export ("pushStatusBarStyle:")]
		void PushStatusBarStyle (UIStatusBarStyle statusBarStyle);

		// -(void)popStatusBarStyle;
		[Export ("popStatusBarStyle")]
		void PopStatusBarStyle ();

		// -(void)pushStatusBarHidden:(BOOL)hidden;
		[Export ("pushStatusBarHidden:")]
		void PushStatusBarHidden (bool hidden);

		// -(void)popStatusBarHidden;
		[Export ("popStatusBarHidden")]
		void PopStatusBarHidden ();

		// -(void)setHelpShown:(BOOL)value;
		[Export ("setHelpShown:")]
		void SetHelpShown (bool value);

		// -(BOOL)isHelpShown;
		[Export ("isHelpShown")]
		bool IsHelpShown { get; }

		// +(NSBundle *)getDefaultResourcesBundle;
		[Static]
		[Export ("getDefaultResourcesBundle")]
		NSBundle DefaultResourcesBundle { get; }
	}

    // @interface MBCCameraSettings : NSObject <NSCopying>
    [iOS (8,0)]
    [BaseType (typeof(NSObject))]
	interface MBCCameraSettings : INSCopying
	{
		// @property (assign, nonatomic) MBCCameraPreset cameraPreset;
		[Export ("cameraPreset", ArgumentSemantic.Assign)]
		MBCCameraPreset CameraPreset { get; set; }

		// @property (assign, nonatomic) MBCCameraType cameraType;
		[Export ("cameraType", ArgumentSemantic.Assign)]
		MBCCameraType CameraType { get; set; }

		// @property (assign, nonatomic) NSTimeInterval autofocusInterval;
		[Export ("autofocusInterval")]
		double AutofocusInterval { get; set; }

		// @property (assign, nonatomic) MBCCameraAutofocusRestriction cameraAutofocusRestriction;
		[Export ("cameraAutofocusRestriction", ArgumentSemantic.Assign)]
		MBCCameraAutofocusRestriction CameraAutofocusRestriction { get; set; }

		// @property (nonatomic, weak) NSString * videoGravity;
		[Export ("videoGravity", ArgumentSemantic.Weak)]
		string VideoGravity { get; set; }

		// @property (assign, nonatomic) CGPoint focusPoint;
		[Export ("focusPoint", ArgumentSemantic.Assign)]
		CGPoint FocusPoint { get; set; }

		// @property (nonatomic) BOOL cameraMirroredHorizontally;
		[Export ("cameraMirroredHorizontally")]
		bool CameraMirroredHorizontally { get; set; }

		// @property (nonatomic) BOOL cameraMirroredVertically;
		[Export ("cameraMirroredVertically")]
		bool CameraMirroredVertically { get; set; }

		// @property (nonatomic) CGFloat previewZoomScale;
		[Export ("previewZoomScale")]
		nfloat PreviewZoomScale { get; set; }

		// -(NSString *)calcSessionPreset;
		[Export ("calcSessionPreset")]
		string CalcSessionPreset { get; }

		// -(AVCaptureAutoFocusRangeRestriction)calcAutofocusRangeRestriction;
		[Export ("calcAutofocusRangeRestriction")]
		AVCaptureAutoFocusRangeRestriction CalcAutofocusRangeRestriction { get; }
	}

    // typedef void (^MBCCaptureHighResImage)(MBCImage * _Nullable);
	delegate void MBCCaptureHighResImage ([NullAllowed] MBCImage arg0);

    interface IMBCRecognizerRunnerViewController {}

    // @protocol MBCRecognizerRunnerViewController <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MBCRecognizerRunnerViewController
	{
		// @required @property (nonatomic) BOOL autorotate;
		[Abstract]
		[Export ("autorotate")]
		bool Autorotate { get; set; }

		// @required @property (nonatomic) UIInterfaceOrientationMask supportedOrientations;
		[Abstract]
		[Export ("supportedOrientations", ArgumentSemantic.Assign)]
		UIInterfaceOrientationMask SupportedOrientations { get; set; }

		// @required -(void)pauseScanning;
		[Abstract]
		[Export ("pauseScanning")]
		void PauseScanning ();

		// @required -(BOOL)isScanningPaused;
		[Abstract]
		[Export ("isScanningPaused")]
		bool IsScanningPaused { get; }

		// @required -(void)resumeScanningAndResetState:(BOOL)resetState;
		[Abstract]
		[Export ("resumeScanningAndResetState:")]
		void ResumeScanningAndResetState (bool resetState);

		// @required -(void)resumeCamera:(void (^ _Nullable)(void))completion;
		[Abstract]
		[Export ("resumeCamera:")]
		void ResumeCamera ([NullAllowed] Action completion);

		// @required -(BOOL)pauseCamera;
		[Abstract]
		[Export ("pauseCamera")]
		bool PauseCamera { get; }

		// @required -(BOOL)isCameraPaused;
		[Abstract]
		[Export ("isCameraPaused")]
		bool IsCameraPaused { get; }

		// @required -(void)playScanSuccessSound;
		[Abstract]
		[Export ("playScanSuccessSound")]
		void PlayScanSuccessSound ();

		// @required -(void)willSetTorchOn:(BOOL)torchOn;
		[Abstract]
		[Export ("willSetTorchOn:")]
		void WillSetTorchOn (bool torchOn);

		// @required -(void)resetState;
		[Abstract]
		[Export ("resetState")]
		void ResetState ();

		// @required -(void)captureHighResImage:(MBCCaptureHighResImage _Nonnull)highResoulutionImageCaptured;
		[Abstract]
		[Export ("captureHighResImage:")]
		void CaptureHighResImage (MBCCaptureHighResImage highResoulutionImageCaptured);
	}

    // @protocol MBOverlayContainerViewController <MBCRecognizerRunnerViewController>
    [Protocol]
    interface MBCOverlayContainerViewController : MBCRecognizerRunnerViewController
	{
		// @required -(void)overlayViewControllerWillCloseCamera:(MBCOverlayViewController *)overlayViewController;
		[Abstract]
		[Export ("overlayViewControllerWillCloseCamera:")]
		void OverlayViewControllerWillCloseCamera (MBCOverlayViewController overlayViewController);

		// @required -(BOOL)overlayViewControllerShouldDisplayTorch:(MBCOverlayViewController *)overlayViewController;
		[Abstract]
		[Export ("overlayViewControllerShouldDisplayTorch:")]
		bool OverlayViewControllerShouldDisplayTorch (MBCOverlayViewController overlayViewController);

		// @required -(BOOL)overlayViewController:(MBCOverlayViewController *)overlayViewController willSetTorch:(BOOL)isTorchOn;
		[Abstract]
		[Export ("overlayViewController:willSetTorch:")]
		bool OverlayViewController (MBCOverlayViewController overlayViewController, bool isTorchOn);

		// @required -(BOOL)shouldDisplayHelpButton;
		[Abstract]
		[Export ("shouldDisplayHelpButton")]
		bool ShouldDisplayHelpButton { get; }

		// @required -(BOOL)isStatusBarPresented;
		[Abstract]
		[Export ("isStatusBarPresented")]
		bool IsStatusBarPresented { get; }

		// @required -(BOOL)isTorchOn;
		[Abstract]
		[Export ("isTorchOn")]
		bool IsTorchOn { get; }

		// @required -(BOOL)isCameraAuthorized;
		[Abstract]
		[Export ("isCameraAuthorized")]
		bool IsCameraAuthorized { get; }
	}


    interface IMBCOverlayContainerViewController {}

    // @interface MBOverlayViewController : UIViewController
    
    [BaseType(typeof(UIViewController))]
    [DisableDefaultCtor]
    interface MBCOverlayViewController
    {
        // @property (nonatomic, weak) UIViewController<MBOverlayContainerViewController> * _Nullable recognizerRunnerViewController;
        [NullAllowed, Export("recognizerRunnerViewController", ArgumentSemantic.Weak)]
        IMBCOverlayContainerViewController RecognizerRunnerViewController { get; set; }
    }

    // @interface MBViewControllerFactory : NSObject
    
	// @interface MBCViewControllerFactory : NSObject
	[iOS (8,0)]
	[BaseType (typeof(NSObject))]
	interface MBCViewControllerFactory
	{
		// +(UIViewController<MBCRecognizerRunnerViewController> * _Nullable)recognizerRunnerViewControllerWithOverlayViewController:(MBCOverlayViewController * _Nonnull)overlayViewController;
		[Static]
		[Export ("recognizerRunnerViewControllerWithOverlayViewController:")]
		IMBCRecognizerRunnerViewController RecognizerRunnerViewControllerWithOverlayViewController (MBCOverlayViewController overlayViewController);
	}

	[Static]
	partial interface Constants
	{
		// extern NSString *const MBCLicenseErrorNotification;
		[Field ("MBCLicenseErrorNotification", "__Internal")]
		NSString MBCLicenseErrorNotification { get; }
	}

    // typedef void (^MBCLicenseErrorBlock)(MBCLicenseError);
	delegate void MBCLicenseErrorBlock (MBCLicenseError arg0);

	// @interface MBCMicroblinkSDK : NSObject
	[iOS (8,0)]
	[BaseType (typeof(NSObject))]
	interface MBCMicroblinkSDK
	{
		// +(instancetype _Nonnull)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		MBCMicroblinkSDK SharedInstance ();

		// @property (assign, nonatomic) BOOL showTrialLicenseWarning;
		[Export ("showTrialLicenseWarning")]
		bool ShowTrialLicenseWarning { get; set; }

		// -(void)setLicenseBuffer:(NSData * _Nonnull)licenseBuffer errorCallback:(MBCLicenseErrorBlock _Nonnull)errorCallback;
		[Export ("setLicenseBuffer:errorCallback:")]
		void SetLicenseBuffer (NSData licenseBuffer, MBCLicenseErrorBlock errorCallback);

		// -(void)setLicenseBuffer:(NSData * _Nonnull)licenseBuffer andLicensee:(NSString * _Nonnull)licensee errorCallback:(MBCLicenseErrorBlock _Nonnull)errorCallback;
		[Export ("setLicenseBuffer:andLicensee:errorCallback:")]
		void SetLicenseBuffer (NSData licenseBuffer, string licensee, MBCLicenseErrorBlock errorCallback);

		// -(void)setLicenseKey:(NSString * _Nonnull)base64LicenseKey errorCallback:(MBCLicenseErrorBlock _Nonnull)errorCallback;
		[Export ("setLicenseKey:errorCallback:")]
		void SetLicenseKey (string base64LicenseKey, MBCLicenseErrorBlock errorCallback);

		// -(void)setLicenseKey:(NSString * _Nonnull)base64LicenseKey andLicensee:(NSString * _Nonnull)licensee errorCallback:(MBCLicenseErrorBlock _Nonnull)errorCallback;
		[Export ("setLicenseKey:andLicensee:errorCallback:")]
		void SetLicenseKey (string base64LicenseKey, string licensee, MBCLicenseErrorBlock errorCallback);

		// -(void)setLicenseResource:(NSString * _Nonnull)fileName withExtension:(NSString * _Nullable)extension inSubdirectory:(NSString * _Nullable)subdirectory forBundle:(NSBundle * _Nonnull)bundle errorCallback:(MBCLicenseErrorBlock _Nonnull)errorCallback;
		[Export ("setLicenseResource:withExtension:inSubdirectory:forBundle:errorCallback:")]
		void SetLicenseResource (string fileName, [NullAllowed] string extension, [NullAllowed] string subdirectory, NSBundle bundle, MBCLicenseErrorBlock errorCallback);

		// -(void)setLicenseResource:(NSString * _Nonnull)fileName withExtension:(NSString * _Nullable)extension inSubdirectory:(NSString * _Nullable)subdirectory forBundle:(NSBundle * _Nonnull)bundle andLicensee:(NSString * _Nonnull)licensee errorCallback:(MBCLicenseErrorBlock _Nonnull)errorCallback;
		[Export ("setLicenseResource:withExtension:inSubdirectory:forBundle:andLicensee:errorCallback:")]
		void SetLicenseResource (string fileName, [NullAllowed] string extension, [NullAllowed] string subdirectory, NSBundle bundle, string licensee, MBCLicenseErrorBlock errorCallback);

		// +(NSString * _Nonnull)buildVersionString;
		[Static]
		[Export ("buildVersionString")]
		string BuildVersionString { get; }

		// +(BOOL)isScanningUnsupportedForCameraType:(MBCCameraType)type error:(NSError * _Nullable * _Nullable)error;
		[Static]
		[Export ("isScanningUnsupportedForCameraType:error:")]
		bool IsScanningUnsupportedForCameraType (MBCCameraType type, [NullAllowed] out NSError error);
	}

	// @interface MBCProductIntegrationInfo : NSObject
	[iOS (9,0)]
	[BaseType (typeof(NSObject))]
	interface MBCProductIntegrationInfo
	{
		// +(instancetype _Nonnull)sharedInstance __attribute__((swift_name("shared()")));
		[Static]
		[Export ("sharedInstance")]
		MBCProductIntegrationInfo SharedInstance ();

		// @property (readonly, nonatomic, strong) NSString * _Nonnull product;
		[Export ("product", ArgumentSemantic.Strong)]
		string Product { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull productVersion;
		[Export ("productVersion", ArgumentSemantic.Strong)]
		string ProductVersion { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull packageName;
		[Export ("packageName", ArgumentSemantic.Strong)]
		string PackageName { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull platform;
		[Export ("platform", ArgumentSemantic.Strong)]
		string Platform { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull osVersion;
		[Export ("osVersion", ArgumentSemantic.Strong)]
		string OsVersion { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull device;
		[Export ("device", ArgumentSemantic.Strong)]
		string Device { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull userId;
		[Export ("userId", ArgumentSemantic.Strong)]
		string UserId { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull licensee;
		[Export ("licensee", ArgumentSemantic.Strong)]
		string Licensee { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull licenseId;
		[Export ("licenseId", ArgumentSemantic.Strong)]
		string LicenseId { get; }
	}

	partial interface Constants
	{
		// extern const MBCExceptionName MBCIllegalModificationException;
		[Field ("MBCIllegalModificationException", "__Internal")]
		NSString MBCIllegalModificationException { get; }

		// extern const MBCExceptionName MBCInvalidLicenseKeyException;
		[Field ("MBCInvalidLicenseKeyException", "__Internal")]
		NSString MBCInvalidLicenseKeyException { get; }

		// extern const MBCExceptionName MBCInvalidLicenseeKeyException;
		[Field ("MBCInvalidLicenseeKeyException", "__Internal")]
		NSString MBCInvalidLicenseeKeyException { get; }

		// extern const MBCExceptionName MBCInvalidLicenseResourceException;
		[Field ("MBCInvalidLicenseResourceException", "__Internal")]
		NSString MBCInvalidLicenseResourceException { get; }

		// extern const MBCExceptionName MBCInvalidBundleException;
		[Field ("MBCInvalidBundleException", "__Internal")]
		NSString MBCInvalidBundleException { get; }

		// extern const MBCExceptionName MBCMissingSettingsException;
		[Field ("MBCMissingSettingsException", "__Internal")]
		NSString MBCMissingSettingsException { get; }

		// extern const MBCExceptionName MBCInvalidArgumentException;
		[Field ("MBCInvalidArgumentException", "__Internal")]
		NSString MBCInvalidArgumentException { get; }
	}

    // @interface MBCImage : NSObject
	[iOS (8,0)]
	[BaseType (typeof(NSObject))]
	interface MBCImage
	{
		// @property (readonly, nonatomic) UIImage * _Nullable image;
		[NullAllowed, Export ("image")]
		UIImage Image { get; }

		// @property (nonatomic) CGRect roi;
		[Export ("roi", ArgumentSemantic.Assign)]
		CGRect Roi { get; set; }

		// @property (nonatomic) MBCProcessingOrientation orientation;
		[Export ("orientation", ArgumentSemantic.Assign)]
		MBCProcessingOrientation Orientation { get; set; }

		// @property (nonatomic) BOOL mirroredHorizontally;
		[Export ("mirroredHorizontally")]
		bool MirroredHorizontally { get; set; }

		// @property (nonatomic) BOOL mirroredVertically;
		[Export ("mirroredVertically")]
		bool MirroredVertically { get; set; }

		// @property (nonatomic) BOOL estimateFrameQuality;
		[Export ("estimateFrameQuality")]
		bool EstimateFrameQuality { get; set; }

		// @property (nonatomic) BOOL cameraFrame;
		[Export ("cameraFrame")]
		bool CameraFrame { get; set; }

		// +(instancetype _Nonnull)imageWithUIImage:(UIImage * _Nonnull)image;
		[Static]
		[Export ("imageWithUIImage:")]
		MBCImage ImageWithUIImage (UIImage image);

		// +(instancetype _Nonnull)imageWithCmSampleBuffer:(CMSampleBufferRef _Nonnull)buffer;
		[Static]
		[Export ("imageWithCmSampleBuffer:")]
		MBCImage ImageWithCmSampleBuffer (CMSampleBuffer buffer);

		// +(instancetype _Nonnull)imageWithCvPixelBuffer:(CVPixelBufferRef _Nonnull)buffer orientation:(UIImageOrientation)orientation;
		[Static]
		[Export ("imageWithCvPixelBuffer:orientation:")]
		MBCImage ImageWithCvPixelBuffer (CVPixelBuffer buffer, UIImageOrientation orientation);
	}

    // @protocol MBCNativeResult
    [Protocol]
	interface MBCNativeResult
	{
		// @required -(NSObject * _Nullable)nativeResult;
		[Abstract]
		[NullAllowed, Export ("nativeResult")]
		NSObject NativeResult { get; }

		// @required -(NSString * _Nullable)stringResult;
		[Abstract]
		[NullAllowed, Export ("stringResult")]
		string StringResult { get; }
	}

    // @interface MBCDateResult : NSObject <MBNativeResult>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
	interface MBCDateResult : MBCNativeResult
	{
		// -(instancetype _Nonnull)initWithDay:(NSInteger)day month:(NSInteger)month year:(NSInteger)year originalDateString:(NSString * _Nullable)originalDateString __attribute__((objc_designated_initializer));
		[Export ("initWithDay:month:year:originalDateString:")]
		[DesignatedInitializer]
		IntPtr Constructor (nint day, nint month, nint year, [NullAllowed] string originalDateString);

		// @property (readonly, nonatomic) NSString * _Nullable originalDateString;
		[NullAllowed, Export ("originalDateString")]
		string OriginalDateString { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable date;
		[NullAllowed, Export ("date")]
		NSDate Date { get; }

		// @property (readonly, assign, nonatomic) NSInteger day;
		[Export ("day")]
		nint Day { get; }

		// @property (readonly, assign, nonatomic) NSInteger month;
		[Export ("month")]
		nint Month { get; }

		// @property (readonly, assign, nonatomic) NSInteger year;
		[Export ("year")]
		nint Year { get; }

		// +(instancetype _Nonnull)dateResultWithDay:(NSInteger)day month:(NSInteger)month year:(NSInteger)year originalDateString:(NSString * _Nullable)originalDateString;
		[Static]
		[Export ("dateResultWithDay:month:year:originalDateString:")]
		MBCDateResult DateResultWithDay (nint day, nint month, nint year, [NullAllowed] string originalDateString);
	}

	// @interface MBCSignedPayload : NSObject
	[iOS (11,0)]
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBCSignedPayload
	{
		// @property (readonly, nonatomic) NSString * _Nullable payload;
		[NullAllowed, Export ("payload")]
		string Payload { get; }

		// @property (readonly, nonatomic) NSString * _Nullable signature;
		[NullAllowed, Export ("signature")]
		string Signature { get; }

		// @property (readonly, nonatomic) NSString * _Nullable signatureVersion;
		[NullAllowed, Export ("signatureVersion")]
		string SignatureVersion { get; }

		// -(instancetype _Nonnull)initWithPayload:(NSString * _Nonnull)payload signature:(NSString * _Nonnull)signature signatureVersion:(NSString * _Nonnull)signatureVersion __attribute__((objc_designated_initializer));
		[Export ("initWithPayload:signature:signatureVersion:")]
		[DesignatedInitializer]
		IntPtr Constructor (string payload, string signature, string signatureVersion);
	}

    // @protocol MBCDebugRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
	interface MBCDebugRecognizerRunnerViewControllerDelegate
	{
		// @required -(void)recognizerRunnerViewController:(UIViewController<MBCRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didOutputDebugImage:(MBCImage * _Nonnull)image;
		[Abstract]
		[Export ("recognizerRunnerViewController:didOutputDebugImage:")]
		void DidOutputDebugImage (MBCRecognizerRunnerViewController recognizerRunnerViewController, MBCImage image);

		// @required -(void)recognizerRunnerViewController:(UIViewController<MBCRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didOutputDebugText:(NSString * _Nonnull)text;
		[Abstract]
		[Export ("recognizerRunnerViewController:didOutputDebugText:")]
		void DidOutputDebugText (MBCRecognizerRunnerViewController recognizerRunnerViewController, string text);
	}

    // @protocol MBDetectionRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
	interface MBCDetectionRecognizerRunnerViewControllerDelegate
	{
		// @optional -(void)recognizerRunnerViewController:(UIViewController<MBCRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didFinishDetectionWithDisplayableQuad:(MBCDisplayableQuadDetection * _Nonnull)displayableQuad;
		[Export ("recognizerRunnerViewController:didFinishDetectionWithDisplayableQuad:")]
		void RecognizerRunnerViewController (MBCRecognizerRunnerViewController recognizerRunnerViewController, MBCDisplayableQuadDetection displayableQuad);

		// @optional -(void)recognizerRunnerViewController:(UIViewController<MBCRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didFinishDetectionWithDisplayablePoints:(MBCDisplayablePointsDetection * _Nonnull)displayablePoints;
		[Export ("recognizerRunnerViewController:didFinishDetectionWithDisplayablePoints:")]
		void RecognizerRunnerViewController (MBCRecognizerRunnerViewController recognizerRunnerViewController, MBCDisplayablePointsDetection displayablePoints);

		// @optional -(void)recognizerRunnerViewControllerDidFailDetection:(UIViewController<MBCRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
		[Export ("recognizerRunnerViewControllerDidFailDetection:")]
		void RecognizerRunnerViewControllerDidFailDetection (MBCRecognizerRunnerViewController recognizerRunnerViewController);
	}

    // @protocol MBOcrRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
	interface MBCOcrRecognizerRunnerViewControllerDelegate
	{
		// @required -(void)recognizerRunnerViewController:(UIViewController<MBCRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didObtainOcrResult:(MBCOcrLayout * _Nonnull)ocrResult withResultName:(NSString * _Nonnull)resultName;
		[Abstract]
		[Export ("recognizerRunnerViewController:didObtainOcrResult:withResultName:")]
		void DidObtainOcrResult (MBCRecognizerRunnerViewController recognizerRunnerViewController, MBCOcrLayout ocrResult, string resultName);
	}

    // @protocol MBGlareRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
	interface MBCGlareRecognizerRunnerViewControllerDelegate
	{
		// @required -(void)recognizerRunnerViewController:(UIViewController<MBCRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didFinishGlareDetectionWithResult:(BOOL)glareFound;
		[Abstract]
		[Export ("recognizerRunnerViewController:didFinishGlareDetectionWithResult:")]
		void DidFinishGlareDetectionWithResult (MBCRecognizerRunnerViewController recognizerRunnerViewController, bool glareFound);
	}

    // @protocol MBFirstSideFinishedRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
	interface MBCFirstSideFinishedRecognizerRunnerViewControllerDelegate
	{
		// @required -(void)recognizerRunnerViewControllerDidFinishRecognitionOfFirstSide:(UIViewController<MBCRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
		[Abstract]
		[Export ("recognizerRunnerViewControllerDidFinishRecognitionOfFirstSide:")]
		void RecognizerRunnerViewControllerDidFinishRecognitionOfFirstSide (MBCRecognizerRunnerViewController recognizerRunnerViewController);
	}

    // @interface MBCRecognizerRunnerViewControllerMetadataDelegates : NSObject
    
    [BaseType(typeof(NSObject))]
	interface MBCRecognizerRunnerViewControllerMetadataDelegates
	{
		[Wrap ("WeakDebugRecognizerRunnerViewControllerDelegate")]
		[NullAllowed]
		MBCDebugRecognizerRunnerViewControllerDelegate DebugRecognizerRunnerViewControllerDelegate { get; set; }

		// @property (nonatomic, weak) id<MBCDebugRecognizerRunnerViewControllerDelegate> _Nullable debugRecognizerRunnerViewControllerDelegate;
		[NullAllowed, Export ("debugRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
		NSObject WeakDebugRecognizerRunnerViewControllerDelegate { get; set; }

		[Wrap ("WeakDetectionRecognizerRunnerViewControllerDelegate")]
		[NullAllowed]
		MBCDetectionRecognizerRunnerViewControllerDelegate DetectionRecognizerRunnerViewControllerDelegate { get; set; }

		// @property (nonatomic, weak) id<MBCDetectionRecognizerRunnerViewControllerDelegate> _Nullable detectionRecognizerRunnerViewControllerDelegate;
		[NullAllowed, Export ("detectionRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
		NSObject WeakDetectionRecognizerRunnerViewControllerDelegate { get; set; }

		[Wrap ("WeakOcrRecognizerRunnerViewControllerDelegate")]
		[NullAllowed]
		MBCOcrRecognizerRunnerViewControllerDelegate OcrRecognizerRunnerViewControllerDelegate { get; set; }

		// @property (nonatomic, weak) id<MBCOcrRecognizerRunnerViewControllerDelegate> _Nullable ocrRecognizerRunnerViewControllerDelegate;
		[NullAllowed, Export ("ocrRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
		NSObject WeakOcrRecognizerRunnerViewControllerDelegate { get; set; }

		[Wrap ("WeakGlareRecognizerRunnerViewControllerDelegate")]
		[NullAllowed]
		MBCGlareRecognizerRunnerViewControllerDelegate GlareRecognizerRunnerViewControllerDelegate { get; set; }

		// @property (nonatomic, weak) id<MBCGlareRecognizerRunnerViewControllerDelegate> _Nullable glareRecognizerRunnerViewControllerDelegate;
		[NullAllowed, Export ("glareRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
		NSObject WeakGlareRecognizerRunnerViewControllerDelegate { get; set; }

		[Wrap ("WeakFirstSideFinishedRecognizerRunnerViewControllerDelegate")]
		[NullAllowed]
		MBCFirstSideFinishedRecognizerRunnerViewControllerDelegate FirstSideFinishedRecognizerRunnerViewControllerDelegate { get; set; }

		// @property (nonatomic, weak) id<MBCFirstSideFinishedRecognizerRunnerViewControllerDelegate> _Nullable firstSideFinishedRecognizerRunnerViewControllerDelegate;
		[NullAllowed, Export ("firstSideFinishedRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
		NSObject WeakFirstSideFinishedRecognizerRunnerViewControllerDelegate { get; set; }
	}

    // @protocol MBCRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
	interface MBCRecognizerRunnerViewControllerDelegate
	{
		// @required -(void)recognizerRunnerViewControllerUnauthorizedCamera:(UIViewController<MBCRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
		[Abstract]
		[Export ("recognizerRunnerViewControllerUnauthorizedCamera:")]
		void RecognizerRunnerViewControllerUnauthorizedCamera (MBCRecognizerRunnerViewController recognizerRunnerViewController);

		// @required -(void)recognizerRunnerViewController:(UIViewController<MBCRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didFindError:(NSError * _Nonnull)error;
		[Abstract]
		[Export ("recognizerRunnerViewController:didFindError:")]
		void RecognizerRunnerViewController (MBCRecognizerRunnerViewController recognizerRunnerViewController, NSError error);

		// @required -(void)recognizerRunnerViewControllerDidClose:(UIViewController<MBCRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
		[Abstract]
		[Export ("recognizerRunnerViewControllerDidClose:")]
		void RecognizerRunnerViewControllerDidClose (MBCRecognizerRunnerViewController recognizerRunnerViewController);

		// @required -(void)recognizerRunnerViewControllerWillPresentHelp:(UIViewController<MBCRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
		[Abstract]
		[Export ("recognizerRunnerViewControllerWillPresentHelp:")]
		void RecognizerRunnerViewControllerWillPresentHelp (MBCRecognizerRunnerViewController recognizerRunnerViewController);

		// @required -(void)recognizerRunnerViewControllerDidResumeScanning:(UIViewController<MBCRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
		[Abstract]
		[Export ("recognizerRunnerViewControllerDidResumeScanning:")]
		void RecognizerRunnerViewControllerDidResumeScanning (MBCRecognizerRunnerViewController recognizerRunnerViewController);

		// @required -(void)recognizerRunnerViewControllerDidStopScanning:(UIViewController<MBCRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
		[Abstract]
		[Export ("recognizerRunnerViewControllerDidStopScanning:")]
		void RecognizerRunnerViewControllerDidStopScanning (MBCRecognizerRunnerViewController recognizerRunnerViewController);

		// @optional -(void)recognizerRunnerViewController:(UIViewController<MBCRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController willSetTorch:(BOOL)isTorchOn;
		[Export ("recognizerRunnerViewController:willSetTorch:")]
		void RecognizerRunnerViewController (MBCRecognizerRunnerViewController recognizerRunnerViewController, bool isTorchOn);
	}

    // @interface MBCRecognizerResult : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
	interface MBCRecognizerResult
	{
		// @property (readonly, assign, nonatomic) MBCRecognizerResultState resultState;
		[Export ("resultState", ArgumentSemantic.Assign)]
		MBCRecognizerResultState ResultState { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull resultStateString;
		[Export ("resultStateString")]
		string ResultStateString { get; }
	}

    // @protocol MBScanningRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
	interface MBCScanningRecognizerRunnerViewControllerDelegate
	{
		// @required -(void)recognizerRunnerViewControllerDidFinishScanning:(UIViewController<MBCRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController state:(MBCRecognizerResultState)state;
		[Abstract]
		[Export ("recognizerRunnerViewControllerDidFinishScanning:state:")]
		void State (MBCRecognizerRunnerViewController recognizerRunnerViewController, MBCRecognizerResultState state);
	}

	// @protocol MBCFrameRecognitionRecognizerRunnerViewControllerDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface MBCFrameRecognitionRecognizerRunnerViewControllerDelegate
	{
		// @required -(void)recognizerRunnerViewControllerDidFinishFrameRecognition:(UIViewController<MBCRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController state:(MBCRecognizerResultState)state;
		[Abstract]
		[Export ("recognizerRunnerViewControllerDidFinishFrameRecognition:state:")]
		void State (MBCRecognizerRunnerViewController recognizerRunnerViewController, MBCRecognizerResultState state);
	}

    // @protocol MBCDebugRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
	interface MBCDebugRecognizerRunnerDelegate
	{
		// @optional -(void)recognizerRunner:(MBCRecognizerRunner * _Nonnull)recognizerRunner didOutputDebugImage:(MBCImage * _Nonnull)image;
		[Export ("recognizerRunner:didOutputDebugImage:")]
		void DidOutputDebugImage (MBCRecognizerRunner recognizerRunner, MBCImage image);

		// @optional -(void)recognizerRunner:(MBCRecognizerRunner * _Nonnull)recognizerRunner didOutputDebugText:(NSString * _Nonnull)text;
		[Export ("recognizerRunner:didOutputDebugText:")]
		void DidOutputDebugText (MBCRecognizerRunner recognizerRunner, string text);
	}

    // @protocol MBDetectionRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
	interface MBCDetectionRecognizerRunnerDelegate
	{
		// @optional -(void)recognizerRunner:(MBCRecognizerRunner * _Nonnull)recognizerRunner didFinishDetectionWithDisplayableQuad:(MBCDisplayableQuadDetection * _Nonnull)displayableQuad;
		[Export ("recognizerRunner:didFinishDetectionWithDisplayableQuad:")]
		void RecognizerRunner (MBCRecognizerRunner recognizerRunner, MBCDisplayableQuadDetection displayableQuad);

		// @optional -(void)recognizerRunner:(MBCRecognizerRunner * _Nonnull)recognizerRunner didFinishDetectionWithDisplayablePoints:(MBCDisplayablePointsDetection * _Nonnull)displayablePoints;
		[Export ("recognizerRunner:didFinishDetectionWithDisplayablePoints:")]
		void RecognizerRunner (MBCRecognizerRunner recognizerRunner, MBCDisplayablePointsDetection displayablePoints);

		// @optional -(void)recognizerRunnerDidFailDetection:(MBCRecognizerRunner * _Nonnull)recognizerRunner;
		[Export ("recognizerRunnerDidFailDetection:")]
		void RecognizerRunnerDidFailDetection (MBCRecognizerRunner recognizerRunner);
	}

    // @protocol MBOcrRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
	interface MBCOcrRecognizerRunnerDelegate
	{
		// @required -(void)recognizerRunner:(MBCRecognizerRunner * _Nonnull)recognizerRunner didObtainOcrResult:(MBCOcrLayout * _Nonnull)ocrResult withResultName:(NSString * _Nonnull)resultName;
		[Abstract]
		[Export ("recognizerRunner:didObtainOcrResult:withResultName:")]
		void DidObtainOcrResult (MBCRecognizerRunner recognizerRunner, MBCOcrLayout ocrResult, string resultName);
	}

    // @protocol MBGlareRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
	interface MBCGlareRecognizerRunnerDelegate
	{
		// @required -(void)recognizerRunner:(MBCRecognizerRunner * _Nonnull)recognizerRunner didFinishGlareDetectionWithResult:(BOOL)glareFound;
		[Abstract]
		[Export ("recognizerRunner:didFinishGlareDetectionWithResult:")]
		void DidFinishGlareDetectionWithResult (MBCRecognizerRunner recognizerRunner, bool glareFound);
	}

    // @protocol MBFirstSideFinishedRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
	interface MBCFirstSideFinishedRecognizerRunnerDelegate
	{
		// @required -(void)recognizerRunnerDidFinishRecognitionOfFirstSide:(MBCRecognizerRunner * _Nonnull)recognizerRunner;
		[Abstract]
		[Export ("recognizerRunnerDidFinishRecognitionOfFirstSide:")]
		void RecognizerRunnerDidFinishRecognitionOfFirstSide (MBCRecognizerRunner recognizerRunner);
	}

    // @interface MBCRecognizerRunnerMetadataDelegates : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBCRecognizerRunnerMetadataDelegates
	{
		[Wrap ("WeakDebugRecognizerRunnerDelegate")]
		[NullAllowed]
		MBCDebugRecognizerRunnerDelegate DebugRecognizerRunnerDelegate { get; set; }

		// @property (nonatomic, weak) id<MBCDebugRecognizerRunnerDelegate> _Nullable debugRecognizerRunnerDelegate;
		[NullAllowed, Export ("debugRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
		NSObject WeakDebugRecognizerRunnerDelegate { get; set; }

		[Wrap ("WeakDetectionRecognizerRunnerDelegate")]
		[NullAllowed]
		MBCDetectionRecognizerRunnerDelegate DetectionRecognizerRunnerDelegate { get; set; }

		// @property (nonatomic, weak) id<MBCDetectionRecognizerRunnerDelegate> _Nullable detectionRecognizerRunnerDelegate;
		[NullAllowed, Export ("detectionRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
		NSObject WeakDetectionRecognizerRunnerDelegate { get; set; }

		[Wrap ("WeakOcrRecognizerRunnerDelegate")]
		[NullAllowed]
		MBCOcrRecognizerRunnerDelegate OcrRecognizerRunnerDelegate { get; set; }

		// @property (nonatomic, weak) id<MBCOcrRecognizerRunnerDelegate> _Nullable ocrRecognizerRunnerDelegate;
		[NullAllowed, Export ("ocrRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
		NSObject WeakOcrRecognizerRunnerDelegate { get; set; }

		[Wrap ("WeakGlareRecognizerRunnerDelegate")]
		[NullAllowed]
		MBCGlareRecognizerRunnerDelegate GlareRecognizerRunnerDelegate { get; set; }

		// @property (nonatomic, weak) id<MBCGlareRecognizerRunnerDelegate> _Nullable glareRecognizerRunnerDelegate;
		[NullAllowed, Export ("glareRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
		NSObject WeakGlareRecognizerRunnerDelegate { get; set; }

		[Wrap ("WeakFirstSideFinishedRecognizerRunnerDelegate")]
		[NullAllowed]
		MBCFirstSideFinishedRecognizerRunnerDelegate FirstSideFinishedRecognizerRunnerDelegate { get; set; }

		// @property (nonatomic, weak) id<MBCFirstSideFinishedRecognizerRunnerDelegate> _Nullable firstSideFinishedRecognizerRunnerDelegate;
		[NullAllowed, Export ("firstSideFinishedRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
		NSObject WeakFirstSideFinishedRecognizerRunnerDelegate { get; set; }
	}

    // @protocol MBScanningRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
	interface MBCScanningRecognizerRunnerDelegate
	{
		// @required -(void)recognizerRunner:(MBCRecognizerRunner * _Nonnull)recognizerRunner didFinishScanningWithState:(MBCRecognizerResultState)state;
		[Abstract]
		[Export ("recognizerRunner:didFinishScanningWithState:")]
		void DidFinishScanningWithState (MBCRecognizerRunner recognizerRunner, MBCRecognizerResultState state);
	}

    // @protocol MBImageProcessingRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
	interface MBCImageProcessingRecognizerRunnerDelegate
	{
		// @required -(void)recognizerRunner:(MBCRecognizerRunner * _Nonnull)recognizerRunner didFinishProcessingImage:(MBCImage * _Nonnull)image;
		[Abstract]
		[Export ("recognizerRunner:didFinishProcessingImage:")]
		void DidFinishProcessingImage (MBCRecognizerRunner recognizerRunner, MBCImage image);
	}

    // @protocol MBStringProcessingRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
	interface MBCStringProcessingRecognizerRunnerDelegate
	{
		// @required -(void)recognizerRunner:(MBCRecognizerRunner * _Nonnull)recognizerRunner didFinishProcessingString:(NSString * _Nonnull)string;
		[Abstract]
		[Export ("recognizerRunner:didFinishProcessingString:")]
		void DidFinishProcessingString (MBCRecognizerRunner recognizerRunner, string @string);
	}

    // @interface MBCRecognizerRunner : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBCRecognizerRunner
	{
		// @property (readonly, nonatomic, strong) MBCRecognizerRunnerMetadataDelegates * _Nonnull metadataDelegates;
		[Export ("metadataDelegates", ArgumentSemantic.Strong)]
		MBCRecognizerRunnerMetadataDelegates MetadataDelegates { get; }

		[Wrap ("WeakScanningRecognizerRunnerDelegate")]
		[NullAllowed]
		MBCScanningRecognizerRunnerDelegate ScanningRecognizerRunnerDelegate { get; set; }

		// @property (nonatomic, weak) id<MBCScanningRecognizerRunnerDelegate> _Nullable scanningRecognizerRunnerDelegate;
		[NullAllowed, Export ("scanningRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
		NSObject WeakScanningRecognizerRunnerDelegate { get; set; }

		[Wrap ("WeakImageProcessingRecognizerRunnerDelegate")]
		[NullAllowed]
		MBCImageProcessingRecognizerRunnerDelegate ImageProcessingRecognizerRunnerDelegate { get; set; }

		// @property (nonatomic, weak) id<MBCImageProcessingRecognizerRunnerDelegate> _Nullable imageProcessingRecognizerRunnerDelegate;
		[NullAllowed, Export ("imageProcessingRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
		NSObject WeakImageProcessingRecognizerRunnerDelegate { get; set; }

		[Wrap ("WeakStringProcessingRecognizerRunnerDelegate")]
		[NullAllowed]
		MBCStringProcessingRecognizerRunnerDelegate StringProcessingRecognizerRunnerDelegate { get; set; }

		// @property (nonatomic, weak) id<MBCStringProcessingRecognizerRunnerDelegate> _Nullable stringProcessingRecognizerRunnerDelegate;
		[NullAllowed, Export ("stringProcessingRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
		NSObject WeakStringProcessingRecognizerRunnerDelegate { get; set; }

		// -(instancetype _Nonnull)initWithRecognizerCollection:(MBCRecognizerCollection * _Nonnull)recognizerCollection __attribute__((objc_designated_initializer));
		[Export ("initWithRecognizerCollection:")]
		[DesignatedInitializer]
		IntPtr Constructor (MBCRecognizerCollection recognizerCollection);

		// -(void)resetState;
		[Export ("resetState")]
		void ResetState ();

		// -(void)resetState:(BOOL)hard;
		[Export ("resetState:")]
		void ResetState (bool hard);

		// -(void)cancelProcessing;
		[Export ("cancelProcessing")]
		void CancelProcessing ();

		// -(void)processImage:(MBCImage * _Nonnull)image;
		[Export ("processImage:")]
		void ProcessImage (MBCImage image);

		// -(void)processString:(NSString * _Nonnull)string;
		[Export ("processString:")]
		void ProcessString (string @string);

		// -(void)reconfigureRecognizers:(MBCRecognizerCollection * _Nonnull)recognizerCollection;
		[Export ("reconfigureRecognizers:")]
		void ReconfigureRecognizers (MBCRecognizerCollection recognizerCollection);
	}

	// @interface MBCBlinkCardEditOverlayTheme : NSObject
	[iOS (8,0)]
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBCBlinkCardEditOverlayTheme
	{
		// +(instancetype _Nonnull)sharedInstance __attribute__((swift_name("shared()")));
		[Static]
		[Export ("sharedInstance")]
		MBCBlinkCardEditOverlayTheme SharedInstance ();

		// @property (nonatomic, strong) UIColor * _Nonnull placeholderTextColor;
		[Export ("placeholderTextColor", ArgumentSemantic.Strong)]
		UIColor PlaceholderTextColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull floatingTitleIdleModeColor;
		[Export ("floatingTitleIdleModeColor", ArgumentSemantic.Strong)]
		UIColor FloatingTitleIdleModeColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull floatingTitleFloatingModeColor;
		[Export ("floatingTitleFloatingModeColor", ArgumentSemantic.Strong)]
		UIColor FloatingTitleFloatingModeColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull floatingTitleEditedModeColor;
		[Export ("floatingTitleEditedModeColor", ArgumentSemantic.Strong)]
		UIColor FloatingTitleEditedModeColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull floatingTitleErrorModeColor;
		[Export ("floatingTitleErrorModeColor", ArgumentSemantic.Strong)]
		UIColor FloatingTitleErrorModeColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull separatorViewColor;
		[Export ("separatorViewColor", ArgumentSemantic.Strong)]
		UIColor SeparatorViewColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull confirmButtonColor;
		[Export ("confirmButtonColor", ArgumentSemantic.Strong)]
		UIColor ConfirmButtonColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull confirmButtonTitleColor;
		[Export ("confirmButtonTitleColor", ArgumentSemantic.Strong)]
		UIColor ConfirmButtonTitleColor { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull textFieldFont;
		[Export ("textFieldFont", ArgumentSemantic.Strong)]
		UIFont TextFieldFont { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull floatingTitleFont;
		[Export ("floatingTitleFont", ArgumentSemantic.Strong)]
		UIFont FloatingTitleFont { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull confirmButtonFont;
		[Export ("confirmButtonFont", ArgumentSemantic.Strong)]
		UIFont ConfirmButtonFont { get; set; }

		// @property (nonatomic, strong) UIImage * _Nullable leadingImage;
		[NullAllowed, Export ("leadingImage", ArgumentSemantic.Strong)]
		UIImage LeadingImage { get; set; }

		// @property (nonatomic, strong) UIImage * _Nullable editButtonImage;
		[NullAllowed, Export ("editButtonImage", ArgumentSemantic.Strong)]
		UIImage EditButtonImage { get; set; }

		// @property (assign, nonatomic) CGFloat confirmButtonCornerRadius;
		[Export ("confirmButtonCornerRadius")]
		nfloat ConfirmButtonCornerRadius { get; set; }
	}

	// @interface MBCBlinkCardEditNavigationController : UINavigationController
	[iOS (9,0)]
	[BaseType (typeof(UINavigationController))]
	interface MBCBlinkCardEditNavigationController
	{
	}

    // @interface MBCEntity : NSObject
    [BaseType(typeof(NSObject))]
    interface MBCEntity
    {
    }

	// @interface MBCRecognizer : MBCEntity
	[iOS (8,0)]
	[BaseType (typeof(MBCEntity))]
	interface MBCRecognizer
	{
		// @property (readonly, nonatomic, weak) MBCRecognizerResult * _Nullable baseResult;
		[NullAllowed, Export ("baseResult", ArgumentSemantic.Weak)]
		MBCRecognizerResult BaseResult { get; }

		// -(UIInterfaceOrientationMask)getOptimalHudOrientation;
		[Export ("getOptimalHudOrientation")]
		UIInterfaceOrientationMask OptimalHudOrientation { get; }
	}

    // @interface MBFrameGrabberRecognizer : MBCRecognizer <NSCopying>
    
    [BaseType(typeof(MBCRecognizer))]
    [DisableDefaultCtor]
	interface MBCFrameGrabberRecognizer : INSCopying
	{
		// -(instancetype _Nonnull)initWithFrameGrabberDelegate:(id<MBCFrameGrabberRecognizerDelegate> _Nonnull)frameGrabberDelegate;
		[Export ("initWithFrameGrabberDelegate:")]
		IntPtr Constructor (MBCFrameGrabberRecognizerDelegate frameGrabberDelegate);

		// @property (assign, nonatomic) BOOL grabFocusedFrames;
		[Export ("grabFocusedFrames")]
		bool GrabFocusedFrames { get; set; }

		// @property (assign, nonatomic) BOOL grabUnfocusedFrames;
		[Export ("grabUnfocusedFrames")]
		bool GrabUnfocusedFrames { get; set; }
	}

    // @protocol MBFrameGrabberRecognizerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
	interface MBCFrameGrabberRecognizerDelegate
	{
		// @required -(void)onFrameAvailable:(MBCImage * _Nonnull)cameraFrame isFocused:(BOOL)focused frameQuality:(CGFloat)frameQuality;
		[Abstract]
		[Export ("onFrameAvailable:isFocused:frameQuality:")]
		void IsFocused (MBCImage cameraFrame, bool focused, nfloat frameQuality);
	}

    // @interface MBSuccessFrameGrabberRecognizerResult : MBCRecognizerResult <NSCopying>
    
    [BaseType(typeof(MBCRecognizerResult))]
    [DisableDefaultCtor]
	interface MBCSuccessFrameGrabberRecognizerResult : INSCopying
	{
		// @property (readonly, nonatomic, strong) MBCImage * _Nonnull successFrame;
		[Export ("successFrame", ArgumentSemantic.Strong)]
		MBCImage SuccessFrame { get; }
	}

    // @interface MBSuccessFrameGrabberRecognizer : MBCRecognizer <NSCopying>
    
    [BaseType(typeof(MBCRecognizer))]
    [DisableDefaultCtor]
	interface MBCSuccessFrameGrabberRecognizer : INSCopying
	{
		// -(instancetype _Nonnull)initWithRecognizer:(MBCRecognizer * _Nonnull)recognizer __attribute__((objc_designated_initializer));
		[Export ("initWithRecognizer:")]
		[DesignatedInitializer]
		IntPtr Constructor (MBCRecognizer recognizer);

		// @property (readonly, nonatomic, strong) MBCSuccessFrameGrabberRecognizerResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBCSuccessFrameGrabberRecognizerResult Result { get; }

		// @property (readonly, nonatomic, strong) MBCRecognizer * _Nonnull slaveRecognizer;
		[Export ("slaveRecognizer", ArgumentSemantic.Strong)]
		MBCRecognizer SlaveRecognizer { get; }
	}

    // @interface MBQuadrangle : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBCQuadrangle
	{
		// @property (assign, nonatomic) CGPoint upperLeft;
		[Export ("upperLeft", ArgumentSemantic.Assign)]
		CGPoint UpperLeft { get; set; }

		// @property (assign, nonatomic) CGPoint upperRight;
		[Export ("upperRight", ArgumentSemantic.Assign)]
		CGPoint UpperRight { get; set; }

		// @property (assign, nonatomic) CGPoint lowerLeft;
		[Export ("lowerLeft", ArgumentSemantic.Assign)]
		CGPoint LowerLeft { get; set; }

		// @property (assign, nonatomic) CGPoint lowerRight;
		[Export ("lowerRight", ArgumentSemantic.Assign)]
		CGPoint LowerRight { get; set; }

		// -(instancetype _Nonnull)initWithUpperLeft:(CGPoint)upperLeft upperRight:(CGPoint)upperRight lowerLeft:(CGPoint)lowerLeft lowerRight:(CGPoint)lowerRight;
		[Export ("initWithUpperLeft:upperRight:lowerLeft:lowerRight:")]
		IntPtr Constructor (CGPoint upperLeft, CGPoint upperRight, CGPoint lowerLeft, CGPoint lowerRight);

		// -(NSArray * _Nonnull)toPointsArray;
		[Export ("toPointsArray")]
		NSObject[] ToPointsArray { get; }

		// -(instancetype _Nonnull)quadrangleWithTransformation:(CGAffineTransform)transform;
		[Export ("quadrangleWithTransformation:")]
		MBCQuadrangle QuadrangleWithTransformation (CGAffineTransform transform);

		// -(CGPoint)center;
		[Export ("center")]
		CGPoint Center { get; }
	}

    // @interface MBOcrLayout : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
interface MBCOcrLayout
	{
		// @property (nonatomic) CGRect box;
		[Export ("box", ArgumentSemantic.Assign)]
		CGRect Box { get; set; }

		// @property (nonatomic) NSArray<MBCOcrBlock *> * _Nonnull blocks;
		[Export ("blocks", ArgumentSemantic.Assign)]
		MBCOcrBlock[] Blocks { get; set; }

		// @property (nonatomic) CGAffineTransform transform;
		[Export ("transform", ArgumentSemantic.Assign)]
		CGAffineTransform Transform { get; set; }

		// @property (nonatomic) BOOL transformInvalid;
		[Export ("transformInvalid")]
		bool TransformInvalid { get; set; }

		// @property (nonatomic) MBCPosition * _Nonnull position;
		[Export ("position", ArgumentSemantic.Assign)]
		MBCPosition Position { get; set; }

		// @property (nonatomic) BOOL flipped;
		[Export ("flipped")]
		bool Flipped { get; set; }

		// -(instancetype _Nonnull)initWithOcrBlocks:(NSArray<MBCOcrBlock *> * _Nonnull)ocrBlocks transform:(CGAffineTransform)transform box:(CGRect)box flipped:(BOOL)flipped __attribute__((objc_designated_initializer));
		[Export ("initWithOcrBlocks:transform:box:flipped:")]
		[DesignatedInitializer]
		IntPtr Constructor (MBCOcrBlock[] ocrBlocks, CGAffineTransform transform, CGRect box, bool flipped);

		// -(instancetype _Nonnull)initWithOcrBlocks:(NSArray * _Nonnull)ocrBlocks;
		[Export ("initWithOcrBlocks:")]
		IntPtr Constructor (NSObject[] ocrBlocks);

		// -(NSString * _Nonnull)string;
		[Export ("string")]
		string String { get; }
	}

    // @interface MBOcrBlock : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
	interface MBCOcrBlock
	{
		// @property (nonatomic) NSArray<MBCOcrLine *> * _Nonnull lines;
		[Export ("lines", ArgumentSemantic.Assign)]
		MBCOcrLine[] Lines { get; set; }

		// @property (nonatomic) MBCPosition * _Nonnull position;
		[Export ("position", ArgumentSemantic.Assign)]
		MBCPosition Position { get; set; }

		// -(instancetype _Nonnull)initWithOcrLines:(NSArray<MBCOcrLine *> * _Nonnull)ocrLines position:(MBCPosition * _Nonnull)position __attribute__((objc_designated_initializer));
		[Export ("initWithOcrLines:position:")]
		[DesignatedInitializer]
		IntPtr Constructor (MBCOcrLine[] ocrLines, MBCPosition position);

		// -(NSString * _Nonnull)string;
		[Export ("string")]
		string String { get; }
	}

    // @interface MBOcrLine : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
	interface MBCOcrLine
	{
		// @property (nonatomic) NSArray<MBCCharWithVariants *> * _Nonnull chars;
		[Export ("chars", ArgumentSemantic.Assign)]
		MBCCharWithVariants[] Chars { get; set; }

		// @property (nonatomic) MBCPosition * _Nonnull position;
		[Export ("position", ArgumentSemantic.Assign)]
		MBCPosition Position { get; set; }

		// -(instancetype _Nonnull)initWithOcrChars:(NSArray<MBCCharWithVariants *> * _Nonnull)ocrChars position:(MBCPosition * _Nonnull)position __attribute__((objc_designated_initializer));
		[Export ("initWithOcrChars:position:")]
		[DesignatedInitializer]
		IntPtr Constructor (MBCCharWithVariants[] ocrChars, MBCPosition position);

		// -(NSString * _Nonnull)string;
		[Export ("string")]
		string String { get; }
	}

    // @interface MBCharWithVariants : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
	interface MBCCharWithVariants
	{
		// @property (nonatomic) MBCOcrChar * _Nonnull character;
		[Export ("character", ArgumentSemantic.Assign)]
		MBCOcrChar Character { get; set; }

		// @property (nonatomic) NSSet * _Nonnull variants;
		[Export ("variants", ArgumentSemantic.Assign)]
		NSSet Variants { get; set; }

		// -(instancetype _Nonnull)initWithValue:(MBCOcrChar * _Nonnull)character __attribute__((objc_designated_initializer));
		[Export ("initWithValue:")]
		[DesignatedInitializer]
		IntPtr Constructor (MBCOcrChar character);
	}

    // @interface MBOcrChar : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
	interface MBCOcrChar
	{
		// @property (nonatomic) unichar value;
		[Export ("value")]
		ushort Value { get; set; }

		// @property (nonatomic) MBCPosition * _Nonnull position;
		[Export ("position", ArgumentSemantic.Assign)]
		MBCPosition Position { get; set; }

		// @property (nonatomic) CGFloat height;
		[Export ("height")]
		nfloat Height { get; set; }

		// @property (getter = isUncertain, nonatomic) BOOL uncertain;
		[Export ("uncertain")]
		bool Uncertain { [Bind ("isUncertain")] get; set; }

		// @property (nonatomic) NSInteger quality;
		[Export ("quality")]
		nint Quality { get; set; }

		// @property (nonatomic) MBCOcrFont font;
		[Export ("font", ArgumentSemantic.Assign)]
		MBCOcrFont Font { get; set; }

		// -(instancetype _Nonnull)initWithValue:(unichar)value position:(MBCPosition * _Nonnull)position height:(CGFloat)height __attribute__((objc_designated_initializer));
		[Export ("initWithValue:position:height:")]
		[DesignatedInitializer]
		IntPtr Constructor (ushort value, MBCPosition position, nfloat height);
	}

    // @interface MBPosition : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
	interface MBCPosition
	{
		// @property (nonatomic) CGPoint ul;
		[Export ("ul", ArgumentSemantic.Assign)]
		CGPoint Ul { get; set; }

		// @property (nonatomic) CGPoint ur;
		[Export ("ur", ArgumentSemantic.Assign)]
		CGPoint Ur { get; set; }

		// @property (nonatomic) CGPoint ll;
		[Export ("ll", ArgumentSemantic.Assign)]
		CGPoint Ll { get; set; }

		// @property (nonatomic) CGPoint lr;
		[Export ("lr", ArgumentSemantic.Assign)]
		CGPoint Lr { get; set; }

		// -(instancetype _Nonnull)initWithUpperLeft:(CGPoint)ul upperRight:(CGPoint)ur lowerLeft:(CGPoint)ll lowerRight:(CGPoint)lr __attribute__((objc_designated_initializer));
		[Export ("initWithUpperLeft:upperRight:lowerLeft:lowerRight:")]
		[DesignatedInitializer]
		IntPtr Constructor (CGPoint ul, CGPoint ur, CGPoint ll, CGPoint lr);

		// -(MBCPosition * _Nonnull)positionWithOffset:(CGPoint)offset;
		[Export ("positionWithOffset:")]
		MBCPosition PositionWithOffset (CGPoint offset);

		// -(CGRect)rect;
		[Export ("rect")]
		CGRect Rect { get; }

		// -(CGPoint)center;
		[Export ("center")]
		CGPoint Center { get; }

		// -(CGFloat)height;
		[Export ("height")]
		nfloat Height { get; }
	}

    // @protocol MBFullDocumentImageResult
    [Protocol]
    interface IMBCFullDocumentImageResult
    {
        // @required @property (readonly, nonatomic) MBImage * _Nullable fullDocumentImage;
        [Abstract]
        [NullAllowed, Export("fullDocumentImage")]
        MBCImage FullDocumentImage { get; }
    }

    // @protocol MBFaceImage
    [Protocol]
    interface IMBCFaceImage
    {
        // @required @property (assign, nonatomic) BOOL returnFaceImage;
        [Abstract]
        [Export ("returnFaceImage")]
        bool ReturnFaceImage { get; set; }
    }

    // @protocol MBFullDocumentImage
    [Protocol]
    interface IMBCFullDocumentImage
    {
        // @required @property (assign, nonatomic) BOOL returnFullDocumentImage;
        [Abstract]
        [Export ("returnFullDocumentImage")]
        bool ReturnFullDocumentImage { get; set; }
    }

    // @protocol MBFullDocumentImageDpi
    [Protocol]
    interface IMBCFullDocumentImageDpi
    {
        // @required @property (assign, nonatomic) NSInteger fullDocumentImageDpi;
        [Abstract]
        [Export ("fullDocumentImageDpi")]
        nint FullDocumentImageDpi { get; set; }
    }

    // @protocol MBGlareDetection
    [Protocol]
    interface IMBCGlareDetection
    {
        // @required @property (assign, nonatomic) BOOL detectGlare;
        [Abstract]
        [Export ("detectGlare")]
        bool DetectGlare { get; set; }
    }

    // @protocol MBCombinedFullDocumentImageResult
    [Protocol]
    interface IMBCCombinedFullDocumentImageResult
    {
		// @required @property (readonly, nonatomic) MBCImage * _Nullable fullDocumentFrontImage;
		[Abstract]
		[NullAllowed, Export ("fullDocumentFrontImage")]
		MBCImage FullDocumentFrontImage { get; }

		// @required @property (readonly, nonatomic) MBCImage * _Nullable fullDocumentBackImage;
		[Abstract]
		[NullAllowed, Export ("fullDocumentBackImage")]
		MBCImage FullDocumentBackImage { get; }
    }

    // @protocol MBEncodedCombinedFullDocumentImageResult
    [Protocol]
    interface IMBCEncodedCombinedFullDocumentImageResult
    {
		// @required @property (readonly, nonatomic) NSData * _Nullable encodedFullDocumentFrontImage;
		[Abstract]
		[NullAllowed, Export ("encodedFullDocumentFrontImage")]
		NSData EncodedFullDocumentFrontImage { get; }

		// @required @property (readonly, nonatomic) NSData * _Nullable encodedFullDocumentBackImage;
		[Abstract]
		[NullAllowed, Export ("encodedFullDocumentBackImage")]
		NSData EncodedFullDocumentBackImage { get; }
    }

    interface IMBCCombinedRecognizerResult {}

    // @protocol MBCombinedRecognizerResult
    [Protocol]   
    interface MBCCombinedRecognizerResult
    {
		// @required @property (readonly, assign, nonatomic) BOOL scanningFirstSideDone;
		[Abstract]
		[Export ("scanningFirstSideDone")]
		bool ScanningFirstSideDone { get; }

		// @optional @property (readonly, assign, nonatomic) MBCDataMatchResult documentDataMatch;
		[Export ("documentDataMatch", ArgumentSemantic.Assign)]
		MBCDataMatchResult DocumentDataMatch { get; }
    }

    // @protocol MBCombinedRecognizer
    [Protocol]
    interface IMBCCombinedRecognizer
    {
        // @required @property (readonly, nonatomic) MBCRecognizerResult<MBCombinedRecognizerResult> * combinedResult;
        [Abstract]
        [Export ("combinedResult")]
        IMBCCombinedRecognizerResult CombinedResult { get; }
    }

    // @protocol MBEncodeFullDocumentImage
    [Protocol]
    interface IMBCEncodeFullDocumentImage
    {
        // @required @property (assign, nonatomic) BOOL encodeFullDocumentImage;
        [Abstract]
        [Export ("encodeFullDocumentImage")]
        bool EncodeFullDocumentImage { get; set; }
    }

    
    // @protocol MBFullDocumentImageExtensionFactors
    [Protocol]
    interface IMBCFullDocumentImageExtensionFactors
    {
        // @required @property (assign, nonatomic) MBImageExtensionFactors fullDocumentImageExtensionFactors;
        [Abstract]
        [Export ("fullDocumentImageExtensionFactors", ArgumentSemantic.Assign)]
        MBCImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
    }

    // @protocol MBEncodedFullDocumentImageResult
    [Protocol]
    interface IMBCEncodedFullDocumentImageResult
    {
        // @required @property (readonly, nonatomic) NSData * _Nullable encodedFullDocumentImage;
        [Abstract]
        [NullAllowed, Export("encodedFullDocumentImage")]
        NSData EncodedFullDocumentImage { get; }
    }

	// @interface MBCBlinkCardUtils : NSObject
	[iOS (9,0)]
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBCBlinkCardUtils
	{
		// +(MBCIssuer)determineIssuerFromCardNumberPrefix:(NSString * _Nonnull)cardNumberPrefix;
		[Static]
		[Export ("determineIssuerFromCardNumberPrefix:")]
		MBCIssuer DetermineIssuerFromCardNumberPrefix (string cardNumberPrefix);

		// +(BOOL)isValidCardNumber:(NSString * _Nonnull)cardNumber;
		[Static]
		[Export ("isValidCardNumber:")]
		bool IsValidCardNumber (string cardNumber);

		// +(BOOL)isValidIban:(NSString * _Nonnull)iban;
		[Static]
		[Export ("isValidIban:")]
		bool IsValidIban (string iban);

		// +(NSString * _Nonnull)issuerToString:(MBCIssuer)issuer;
		[Static]
		[Export ("issuerToString:")]
		string IssuerToString (MBCIssuer issuer);
	}

    // @interface MBCBlinkCardEditResult : NSObject <NSCopying>
	[iOS (9,0)]
	[BaseType (typeof(NSObject))]
	interface MBCBlinkCardEditResult : INSCopying
	{
		// @property (nonatomic, strong) NSString * _Nullable cardNumber;
		[NullAllowed, Export ("cardNumber", ArgumentSemantic.Strong)]
		string CardNumber { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable owner;
		[NullAllowed, Export ("owner", ArgumentSemantic.Strong)]
		string Owner { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable cvv;
		[NullAllowed, Export ("cvv", ArgumentSemantic.Strong)]
		string Cvv { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable expiryDate;
		[NullAllowed, Export ("expiryDate", ArgumentSemantic.Strong)]
		string ExpiryDate { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable iban;
		[NullAllowed, Export ("iban", ArgumentSemantic.Strong)]
		string Iban { get; set; }
	}

    // @interface MBCBlinkCardRecognizerResult : MBCRecognizerResult <NSCopying, MBCCombinedRecognizerResult>
	[iOS (9,0)]
	[BaseType (typeof(MBCRecognizerResult))]
	[DisableDefaultCtor]
	interface MBCBlinkCardRecognizerResult : INSCopying, MBCCombinedRecognizerResult
	{
		// @property (readonly, nonatomic) MBCIssuer issuer;
		[Export ("issuer")]
		MBCIssuer Issuer { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull cardNumber;
		[Export ("cardNumber")]
		string CardNumber { get; }

		// @property (readonly, nonatomic) BOOL cardNumberValid;
		[Export ("cardNumberValid")]
		bool CardNumberValid { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull cardNumberPrefix;
		[Export ("cardNumberPrefix")]
		string CardNumberPrefix { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull iban;
		[Export ("iban")]
		string Iban { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull cvv;
		[Export ("cvv")]
		string Cvv { get; }

		// @property (readonly, nonatomic) MBCDateResult * _Nonnull expiryDate;
		[Export ("expiryDate")]
		MBCDateResult ExpiryDate { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull owner;
		[Export ("owner")]
		string Owner { get; }

		// @property (readonly, nonatomic) BOOL firstSideBlurred;
		[Export ("firstSideBlurred")]
		bool FirstSideBlurred { get; }

		// @property (readonly, nonatomic) BOOL secondSideBlurred;
		[Export ("secondSideBlurred")]
		bool SecondSideBlurred { get; }

		// @property (readonly, nonatomic) MBCImage * _Nullable firstSideFullDocumentImage;
		[NullAllowed, Export ("firstSideFullDocumentImage")]
		MBCImage FirstSideFullDocumentImage { get; }

		// @property (readonly, nonatomic) MBCImage * _Nullable secondSideFullDocumentImage;
		[NullAllowed, Export ("secondSideFullDocumentImage")]
		MBCImage SecondSideFullDocumentImage { get; }

		// @property (readonly, nonatomic) NSData * _Nullable encodedFirstSideFullDocumentImage;
		[NullAllowed, Export ("encodedFirstSideFullDocumentImage")]
		NSData EncodedFirstSideFullDocumentImage { get; }

		// @property (readonly, nonatomic) NSData * _Nullable encodedSecondSideFullDocumentImage;
		[NullAllowed, Export ("encodedSecondSideFullDocumentImage")]
		NSData EncodedSecondSideFullDocumentImage { get; }

		// @property (readonly, nonatomic) MBCBlinkCardProcessingStatus processingStatus;
		[Export ("processingStatus")]
		MBCBlinkCardProcessingStatus ProcessingStatus { get; }
	}

    // @interface MBCBlinkCardRecognizer : MBCRecognizer <NSCopying, MBCCombinedRecognizer, MBCFullDocumentImage, MBCEncodeFullDocumentImage, MBCFullDocumentImageDpi, MBCFullDocumentImageExtensionFactors>
	[iOS (9,0)]
	[BaseType (typeof(MBCRecognizer))]
	interface MBCBlinkCardRecognizer : INSCopying, IMBCCombinedRecognizer, IMBCFullDocumentImage, IMBCEncodeFullDocumentImage, IMBCFullDocumentImageDpi, IMBCFullDocumentImageExtensionFactors
	{
		// @property (readonly, nonatomic, strong) MBCBlinkCardRecognizerResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBCBlinkCardRecognizerResult Result { get; }

		// @property (assign, nonatomic) BOOL extractOwner;
		[Export ("extractOwner")]
		bool ExtractOwner { get; set; }

		// @property (assign, nonatomic) BOOL extractExpiryDate;
		[Export ("extractExpiryDate")]
		bool ExtractExpiryDate { get; set; }

		// @property (assign, nonatomic) BOOL extractCvv;
		[Export ("extractCvv")]
		bool ExtractCvv { get; set; }

		// @property (assign, nonatomic) BOOL extractIban;
		[Export ("extractIban")]
		bool ExtractIban { get; set; }

		// @property (assign, nonatomic) BOOL allowBlurFilter;
		[Export ("allowBlurFilter")]
		bool AllowBlurFilter { get; set; }

		// @property (assign, nonatomic) CGFloat paddingEdge;
		[Export ("paddingEdge")]
		nfloat PaddingEdge { get; set; }

		// @property (nonatomic, strong) MBCBlinkCardAnonymizationSettings * _Nonnull anonymizationSettings;
		[Export ("anonymizationSettings", ArgumentSemantic.Strong)]
		MBCBlinkCardAnonymizationSettings AnonymizationSettings { get; set; }
	}

    // @interface MBCBlinkCardAnonymizationSettings : NSObject <NSCopying>
	[iOS (9,0)]
	[BaseType (typeof(NSObject))]
	interface MBCBlinkCardAnonymizationSettings : INSCopying
	{
		// @property (nonatomic, strong) MBCCardNumberAnonymizationSettings * _Nonnull cardNumberAnonymizationSettings;
		[Export ("cardNumberAnonymizationSettings", ArgumentSemantic.Strong)]
		MBCCardNumberAnonymizationSettings CardNumberAnonymizationSettings { get; set; }

		// @property (assign, nonatomic) MBCBlinkCardAnonymizationMode cardNumberPrefixAnonymizationMode;
		[Export ("cardNumberPrefixAnonymizationMode", ArgumentSemantic.Assign)]
		MBCBlinkCardAnonymizationMode CardNumberPrefixAnonymizationMode { get; set; }

		// @property (assign, nonatomic) MBCBlinkCardAnonymizationMode cvvAnonymizationMode;
		[Export ("cvvAnonymizationMode", ArgumentSemantic.Assign)]
		MBCBlinkCardAnonymizationMode CvvAnonymizationMode { get; set; }

		// @property (assign, nonatomic) MBCBlinkCardAnonymizationMode ibanAnonymizationMode;
		[Export ("ibanAnonymizationMode", ArgumentSemantic.Assign)]
		MBCBlinkCardAnonymizationMode IbanAnonymizationMode { get; set; }

		// @property (assign, nonatomic) MBCBlinkCardAnonymizationMode ownerAnonymizationMode;
		[Export ("ownerAnonymizationMode", ArgumentSemantic.Assign)]
		MBCBlinkCardAnonymizationMode OwnerAnonymizationMode { get; set; }
	}

    // @interface MBCCardNumberAnonymizationSettings : NSObject <NSCopying>
	[iOS (9,0)]
	[BaseType (typeof(NSObject))]
	interface MBCCardNumberAnonymizationSettings : INSCopying
	{
		// @property (assign, nonatomic) MBCBlinkCardAnonymizationMode mode;
		[Export ("mode", ArgumentSemantic.Assign)]
		MBCBlinkCardAnonymizationMode Mode { get; set; }

		// @property (assign, nonatomic) NSInteger prefixDigitsVisible;
		[Export ("prefixDigitsVisible")]
		nint PrefixDigitsVisible { get; set; }

		// @property (assign, nonatomic) NSInteger suffixDigitsVisible;
		[Export ("suffixDigitsVisible")]
		nint SuffixDigitsVisible { get; set; }
	}


	// @interface MBCLegacyBlinkCardRecognizerResult : MBCRecognizerResult <NSCopying, MBCCombinedRecognizerResult, MBCCombinedFullDocumentImageResult, MBCEncodedCombinedFullDocumentImageResult>
	[iOS (8,0)]
	[BaseType (typeof(MBCRecognizerResult))]
	[DisableDefaultCtor]
	interface MBCLegacyBlinkCardRecognizerResult : INSCopying, MBCCombinedRecognizerResult, IMBCCombinedFullDocumentImageResult, IMBCEncodedCombinedFullDocumentImageResult
	{
		// @property (readonly, nonatomic) NSString * _Nonnull cardNumber;
		[Export ("cardNumber")]
		string CardNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull owner;
		[Export ("owner")]
		string Owner { get; }

		// @property (readonly, nonatomic) MBCDateResult * _Nonnull validThru;
		[Export ("validThru")]
		MBCDateResult ValidThru { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull cvv;
		[Export ("cvv")]
		string Cvv { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull inventoryNumber;
		[Export ("inventoryNumber")]
		string InventoryNumber { get; }

		// @property (readonly, nonatomic) MBCLegacyCardIssuer issuer;
		[Export ("issuer")]
		MBCLegacyCardIssuer Issuer { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull iban;
		[Export ("iban")]
		string Iban { get; }
	}

    // @interface MBCLegacyBlinkCardRecognizer : MBCRecognizer <NSCopying, MBCCombinedRecognizer, MBCFullDocumentImage, MBCEncodeFullDocumentImage, MBCFullDocumentImageDpi, MBCGlareDetection, MBCFullDocumentImageExtensionFactors>
	[iOS (8,0)]
	[BaseType (typeof(MBCRecognizer))]
	interface MBCLegacyBlinkCardRecognizer : INSCopying, IMBCCombinedRecognizer, IMBCFullDocumentImage, IMBCEncodeFullDocumentImage, IMBCFullDocumentImageDpi, IMBCGlareDetection, IMBCFullDocumentImageExtensionFactors
	{
		// @property (readonly, nonatomic, strong) MBCLegacyBlinkCardRecognizerResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBCLegacyBlinkCardRecognizerResult Result { get; }

		// @property (assign, nonatomic) BOOL extractOwner;
		[Export ("extractOwner")]
		bool ExtractOwner { get; set; }

		// @property (assign, nonatomic) BOOL extractValidThru;
		[Export ("extractValidThru")]
		bool ExtractValidThru { get; set; }

		// @property (assign, nonatomic) BOOL extractCvv;
		[Export ("extractCvv")]
		bool ExtractCvv { get; set; }

		// @property (assign, nonatomic) BOOL extractIban;
		[Export ("extractIban")]
		bool ExtractIban { get; set; }

		// @property (assign, nonatomic) BOOL extractInventoryNumber;
		[Export ("extractInventoryNumber")]
		bool ExtractInventoryNumber { get; set; }

		// @property (assign, nonatomic) BOOL anonymizeCardNumber;
		[Export ("anonymizeCardNumber")]
		bool AnonymizeCardNumber { get; set; }

		// @property (assign, nonatomic) BOOL anonymizeOwner;
		[Export ("anonymizeOwner")]
		bool AnonymizeOwner { get; set; }

		// @property (assign, nonatomic) BOOL anonymizeCvv;
		[Export ("anonymizeCvv")]
		bool AnonymizeCvv { get; set; }

		// @property (assign, nonatomic) BOOL anonymizeIban;
		[Export ("anonymizeIban")]
		bool AnonymizeIban { get; set; }
	}

	// @interface MBCLegacyBlinkCardEliteRecognizerResult : MBCRecognizerResult <NSCopying, MBCCombinedRecognizerResult, MBCCombinedFullDocumentImageResult, MBCEncodedCombinedFullDocumentImageResult>
	[iOS (8,0)]
	[BaseType (typeof(MBCRecognizerResult))]
	[DisableDefaultCtor]
	interface MBCLegacyBlinkCardEliteRecognizerResult : INSCopying, MBCCombinedRecognizerResult, IMBCCombinedFullDocumentImageResult, IMBCEncodedCombinedFullDocumentImageResult
	{
		// @property (readonly, nonatomic) NSString * _Nonnull cardNumber;
		[Export ("cardNumber")]
		string CardNumber { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull owner;
		[Export ("owner")]
		string Owner { get; }

		// @property (readonly, nonatomic) MBCDateResult * _Nonnull validThru;
		[Export ("validThru")]
		MBCDateResult ValidThru { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull cvv;
		[Export ("cvv")]
		string Cvv { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull inventoryNumber;
		[Export ("inventoryNumber")]
		string InventoryNumber { get; }
	}

	// @interface MBCLegacyBlinkCardEliteRecognizer : MBCRecognizer <NSCopying, MBCCombinedRecognizer, MBCFullDocumentImage, MBCEncodeFullDocumentImage, MBCFullDocumentImageDpi, MBCGlareDetection, MBCFullDocumentImageExtensionFactors>
	[iOS (8,0)]
	[BaseType (typeof(MBCRecognizer))]
	interface MBCLegacyBlinkCardEliteRecognizer : INSCopying, IMBCCombinedRecognizer, IMBCFullDocumentImage, IMBCEncodeFullDocumentImage, IMBCFullDocumentImageDpi, IMBCGlareDetection, IMBCFullDocumentImageExtensionFactors
	{
		// @property (readonly, nonatomic, strong) MBCLegacyBlinkCardEliteRecognizerResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBCLegacyBlinkCardEliteRecognizerResult Result { get; }

		// @property (assign, nonatomic) BOOL extractOwner;
		[Export ("extractOwner")]
		bool ExtractOwner { get; set; }

		// @property (assign, nonatomic) BOOL extractValidThru;
		[Export ("extractValidThru")]
		bool ExtractValidThru { get; set; }

		// @property (assign, nonatomic) BOOL extractInventoryNumber;
		[Export ("extractInventoryNumber")]
		bool ExtractInventoryNumber { get; set; }

		// @property (assign, nonatomic) BOOL anonymizeCardNumber;
		[Export ("anonymizeCardNumber")]
		bool AnonymizeCardNumber { get; set; }

		// @property (assign, nonatomic) BOOL anonymizeOwner;
		[Export ("anonymizeOwner")]
		bool AnonymizeOwner { get; set; }

		// @property (assign, nonatomic) BOOL anonymizeCvv;
		[Export ("anonymizeCvv")]
		bool AnonymizeCvv { get; set; }
	}


    // @interface MBBaseOverlayViewController : MBOverlayViewController
    
    [BaseType(typeof(MBCOverlayViewController))]
    interface MBCBaseOverlayViewController
    {
		// -(void)reconfigureRecognizers:(MBCRecognizerCollection * _Nonnull)recognizerCollection;
		[Export ("reconfigureRecognizers:")]
		void ReconfigureRecognizers (MBCRecognizerCollection recognizerCollection);
    }

    // @interface MBCRecognizerCollection : NSObject <NSCopying>
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBCRecognizerCollection : INSCopying
    {
		// -(instancetype _Nonnull)initWithRecognizers:(NSArray<MBCRecognizer *> * _Nonnull)recognizers __attribute__((objc_designated_initializer));
		[Export ("initWithRecognizers:")]
		[DesignatedInitializer]
		IntPtr Constructor (MBCRecognizer[] recognizers);

		// @property (nonatomic, strong) NSArray<MBCRecognizer *> * _Nonnull recognizerList;
		[Export ("recognizerList", ArgumentSemantic.Strong)]
		MBCRecognizer[] RecognizerList { get; set; }

		// @property (nonatomic) BOOL allowMultipleResults;
		[Export ("allowMultipleResults")]
		bool AllowMultipleResults { get; set; }

		// @property (nonatomic) NSTimeInterval partialRecognitionTimeout;
		[Export ("partialRecognitionTimeout")]
		double PartialRecognitionTimeout { get; set; }

		// @property (nonatomic) MBCRecognitionDebugMode recognitionDebugMode;
		[Export ("recognitionDebugMode", ArgumentSemantic.Assign)]
		MBCRecognitionDebugMode RecognitionDebugMode { get; set; }

		// @property (nonatomic) MBCFrameQualityEstimationMode frameQualityEstimationMode;
		[Export ("frameQualityEstimationMode", ArgumentSemantic.Assign)]
		MBCFrameQualityEstimationMode FrameQualityEstimationMode { get; set; }
    }

    // @interface MBOverlaySettings : NSObject <NSCopying>
    
    [BaseType(typeof(NSObject))]
    interface MBCOverlaySettings : INSCopying
    {
        // @property (nonatomic, strong) NSString * _Nullable language;
        [NullAllowed, Export("language", ArgumentSemantic.Strong)]
        string Language { get; set; }

        // @property (nonatomic, strong) MBCameraSettings * _Nonnull cameraSettings;
        [Export ("cameraSettings", ArgumentSemantic.Strong)]
        MBCCameraSettings CameraSettings { get; set; }
    }

    // @interface MBBaseOverlaySettings : MBOverlaySettings
    
    [BaseType(typeof(MBCOverlaySettings))]
    interface MBCBaseOverlaySettings
    {
        // @property (assign, nonatomic) BOOL autorotateOverlay;
        [Export ("autorotateOverlay")]
        bool AutorotateOverlay { get; set; }

        // @property (assign, nonatomic) BOOL showStatusBar;
        [Export ("showStatusBar")]
        bool ShowStatusBar { get; set; }

        // @property (assign, nonatomic) UIInterfaceOrientationMask supportedOrientations;
        [Export ("supportedOrientations", ArgumentSemantic.Assign)]
        UIInterfaceOrientationMask SupportedOrientations { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable soundFilePath;
        [NullAllowed, Export("soundFilePath", ArgumentSemantic.Strong)]
        string SoundFilePath { get; set; }

        // @property (assign, nonatomic) BOOL displayCancelButton;
        [Export ("displayCancelButton")]
        bool DisplayCancelButton { get; set; }

        // @property (assign, nonatomic) BOOL displayTorchButton;
        [Export ("displayTorchButton")]
        bool DisplayTorchButton { get; set; }
    }

    // @interface MBCustomOverlayViewController : MBOverlayViewController
    
    [BaseType(typeof(MBCOverlayViewController))]
	interface MBCCustomOverlayViewController
	{
		// @property (readonly, nonatomic, strong) MBCRecognizerCollection * _Nonnull recognizerCollection;
		[Export ("recognizerCollection", ArgumentSemantic.Strong)]
		MBCRecognizerCollection RecognizerCollection { get; }

		// @property (readonly, nonatomic, strong) MBCCameraSettings * _Nonnull cameraSettings;
		[Export ("cameraSettings", ArgumentSemantic.Strong)]
		MBCCameraSettings CameraSettings { get; }

		// @property (nonatomic, strong) MBCRecognizerRunnerViewControllerMetadataDelegates * _Nonnull metadataDelegates;
		[Export ("metadataDelegates", ArgumentSemantic.Strong)]
		MBCRecognizerRunnerViewControllerMetadataDelegates MetadataDelegates { get; set; }

		[Wrap ("WeakScanningRecognizerRunnerViewControllerDelegate")]
		[NullAllowed]
		MBCScanningRecognizerRunnerViewControllerDelegate ScanningRecognizerRunnerViewControllerDelegate { get; set; }

		// @property (nonatomic, weak) id<MBCScanningRecognizerRunnerViewControllerDelegate> _Nullable scanningRecognizerRunnerViewControllerDelegate;
		[NullAllowed, Export ("scanningRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
		NSObject WeakScanningRecognizerRunnerViewControllerDelegate { get; set; }

		[Wrap ("WeakRecognizerRunnerViewControllerDelegate")]
		[NullAllowed]
		MBCRecognizerRunnerViewControllerDelegate RecognizerRunnerViewControllerDelegate { get; set; }

		// @property (nonatomic, weak) id<MBCRecognizerRunnerViewControllerDelegate> _Nullable recognizerRunnerViewControllerDelegate;
		[NullAllowed, Export ("recognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
		NSObject WeakRecognizerRunnerViewControllerDelegate { get; set; }

		// -(instancetype _Nonnull)initWithRecognizerCollection:(MBCRecognizerCollection * _Nonnull)recognizerCollection cameraSettings:(MBCCameraSettings * _Nonnull)cameraSettings __attribute__((objc_designated_initializer));
		[Export ("initWithRecognizerCollection:cameraSettings:")]
		[DesignatedInitializer]
		IntPtr Constructor (MBCRecognizerCollection recognizerCollection, MBCCameraSettings cameraSettings);

		// @property (nonatomic) CGRect scanningRegion;
		[Export ("scanningRegion", ArgumentSemantic.Assign)]
		CGRect ScanningRegion { get; set; }

		// @property (assign, nonatomic) BOOL autorotateOverlay;
		[Export ("autorotateOverlay")]
		bool AutorotateOverlay { get; set; }

		// @property (assign, nonatomic) BOOL showStatusBar;
		[Export ("showStatusBar")]
		bool ShowStatusBar { get; set; }

		// @property (assign, nonatomic) UIInterfaceOrientationMask supportedOrientations;
		[Export ("supportedOrientations", ArgumentSemantic.Assign)]
		UIInterfaceOrientationMask SupportedOrientations { get; set; }

		// -(void)reconfigureRecognizers:(MBCRecognizerCollection * _Nonnull)recognizerCollection;
		[Export ("reconfigureRecognizers:")]
		void ReconfigureRecognizers (MBCRecognizerCollection recognizerCollection);
	}

    // @interface MBSubview : UIView
    
    [BaseType(typeof(UIView))]
    interface MBCSubview
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        MBCSubviewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<MBSubviewDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }
    }

    // @protocol MBSubviewDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBCSubviewDelegate
    {
        // @required -(void)subviewAnimationDidStart:(MBSubview * _Nonnull)subview;
        [Abstract]
        [Export ("subviewAnimationDidStart:")]
        void SubviewAnimationDidStart(MBCSubview subview);

        // @required -(void)subviewAnimationDidFinish:(MBSubview * _Nonnull)subview;
        [Abstract]
        [Export ("subviewAnimationDidFinish:")]
        void SubviewAnimationDidFinish(MBCSubview subview);
    }

	// @interface MBCRectDocumentSubview : MBCSubview
	[iOS (8,0)]
	[BaseType (typeof(MBCSubview))]
	[DisableDefaultCtor]
	interface MBCRectDocumentSubview
	{
		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export ("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor (CGRect frame);

		// @property (nonatomic) CGFloat widthToHightAspectRatio;
		[Export ("widthToHightAspectRatio")]
		nfloat WidthToHightAspectRatio { get; set; }

		// @property (nonatomic) NSString * _Nonnull titleText;
		[Export ("titleText")]
		string TitleText { get; set; }

		// @property (nonatomic) UILabel * _Nonnull titleView;
		[Export ("titleView", ArgumentSemantic.Assign)]
		UILabel TitleView { get; set; }

		// @property (nonatomic) CGSize viewSize;
		[Export ("viewSize", ArgumentSemantic.Assign)]
		CGSize ViewSize { get; set; }

		// @property (nonatomic) CGFloat titleTextDelay;
		[Export ("titleTextDelay")]
		nfloat TitleTextDelay { get; set; }

		// @property (nonatomic) UIView * _Nonnull centerView;
		[Export ("centerView", ArgumentSemantic.Assign)]
		UIView CenterView { get; set; }

		[Wrap ("WeakRectSubviewDelegate")]
		[NullAllowed]
		MBCRectDocumentSubviewDelegate RectSubviewDelegate { get; set; }

		// @property (nonatomic, weak) id<MBCRectDocumentSubviewDelegate> _Nullable rectSubviewDelegate;
		[NullAllowed, Export ("rectSubviewDelegate", ArgumentSemantic.Weak)]
		NSObject WeakRectSubviewDelegate { get; set; }

		// -(void)startScanLineAnimation;
		[Export ("startScanLineAnimation")]
		void StartScanLineAnimation ();

		// -(void)stopScanLineAnimation;
		[Export ("stopScanLineAnimation")]
		void StopScanLineAnimation ();

		// -(void)startFlipAnimation;
		[Export ("startFlipAnimation")]
		void StartFlipAnimation ();

		// -(void)updateForMode:(MBCRectDocumentSubviewScanMode)mode;
		[Export ("updateForMode:")]
		void UpdateForMode (MBCRectDocumentSubviewScanMode mode);

		// -(void)startScannedFirstSideFinishAnimation;
		[Export ("startScannedFirstSideFinishAnimation")]
		void StartScannedFirstSideFinishAnimation ();

		// -(void)resetTitleLabelConstraint;
		[Export ("resetTitleLabelConstraint")]
		void ResetTitleLabelConstraint ();

		// -(void)configureCornersBounds;
		[Export ("configureCornersBounds")]
		void ConfigureCornersBounds ();

		// -(void)updateProgress;
		[Export ("updateProgress")]
		void UpdateProgress ();
	}

	// @protocol MBCRectDocumentSubviewDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface MBCRectDocumentSubviewDelegate
	{
		// @required -(void)rectDocumentSubviewDidFinishFlipAnimation:(MBCRectDocumentSubview * _Nonnull)rectDocumentSubvie;
		[Abstract]
		[Export ("rectDocumentSubviewDidFinishFlipAnimation:")]
		void RectDocumentSubviewDidFinishFlipAnimation (MBCRectDocumentSubview rectDocumentSubvie);

		// @required -(void)rectDocumentSubviewDidFinishAnimation:(MBCRectDocumentSubview * _Nonnull)rectDocumentSubvie;
		[Abstract]
		[Export ("rectDocumentSubviewDidFinishAnimation:")]
		void RectDocumentSubviewDidFinishAnimation (MBCRectDocumentSubview rectDocumentSubvie);

		// @required -(void)rectDocumentSubviewDidStartTransitionAnimation:(MBCRectDocumentSubview * _Nonnull)rectDocumentSubvie mode:(MBCRectDocumentSubviewScanMode)mode;
		[Abstract]
		[Export ("rectDocumentSubviewDidStartTransitionAnimation:mode:")]
		void RectDocumentSubviewDidStartTransitionAnimation (MBCRectDocumentSubview rectDocumentSubvie, MBCRectDocumentSubviewScanMode mode);
	}

    // @interface MBCDisplayableObject : NSObject
    [BaseType(typeof(NSObject))]
	interface MBCDisplayableObject
	{
		// @property (assign, nonatomic) CGAffineTransform transform;
		[Export ("transform", ArgumentSemantic.Assign)]
		CGAffineTransform Transform { get; set; }
	}

    // @interface MBDisplayableDetection : MBDisplayableObject
    
    [BaseType(typeof(MBCDisplayableObject))]
    [DisableDefaultCtor]
	interface MBCDisplayableDetection
	{
		// -(instancetype _Nonnull)initWithDetectionStatus:(MBCDetectionStatus)status __attribute__((objc_designated_initializer));
		[Export ("initWithDetectionStatus:")]
		[DesignatedInitializer]
		IntPtr Constructor (MBCDetectionStatus status);

		// @property (readonly, assign, nonatomic) MBCDetectionStatus detectionStatus;
		[Export ("detectionStatus", ArgumentSemantic.Assign)]
		MBCDetectionStatus DetectionStatus { get; }
	}

    // @interface MBDisplayablePointsDetection : MBDisplayableDetection
    
	[BaseType (typeof(MBCDisplayableDetection))]
	interface MBCDisplayablePointsDetection
	{
		// @property (nonatomic) NSArray * _Nonnull points;
		[Export ("points", ArgumentSemantic.Assign)]
		NSObject[] Points { get; set; }
	}


    // @interface MBCDotsSubview : MBSubview <MBPointDetectorSubview>
    [BaseType(typeof(MBCSubview))]
    interface MBCDotsSubview : IMBCPointDetectorSubview
    {
		// @property (nonatomic, strong) CAShapeLayer * _Nonnull dotsLayer;
		[Export ("dotsLayer", ArgumentSemantic.Strong)]
		CAShapeLayer DotsLayer { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull dotsColor;
		[Export ("dotsColor", ArgumentSemantic.Strong)]
		UIColor DotsColor { get; set; }

		// @property (assign, nonatomic) CGFloat dotsStrokeWidth;
		[Export ("dotsStrokeWidth")]
		nfloat DotsStrokeWidth { get; set; }

		// @property (assign, nonatomic) CGFloat dotsRadius;
		[Export ("dotsRadius")]
		nfloat DotsRadius { get; set; }

		// @property (assign, nonatomic) CGFloat animationDuration;
		[Export ("animationDuration")]
		nfloat AnimationDuration { get; set; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame;
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);
    }

    // @interface MBDisplayableQuadDetection : MBDisplayableDetection
    
    [BaseType(typeof(MBCDisplayableDetection))]
    interface MBCDisplayableQuadDetection
    {
        // @property (nonatomic, strong) MBQuadrangle * _Nonnull detectionLocation;
        [Export ("detectionLocation", ArgumentSemantic.Strong)]
        MBCQuadrangle DetectionLocation { get; set; }
    }

	// @protocol MBCPointDetectorSubview <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol]
	[BaseType (typeof(NSObject))]
	interface IMBCPointDetectorSubview
	{
		// @required -(void)detectionFinishedWithDisplayablePoints:(MBCDisplayablePointsDetection *)displayablePointsDetection;
		[Abstract]
		[Export ("detectionFinishedWithDisplayablePoints:")]
		void DetectionFinishedWithDisplayablePoints (MBCDisplayablePointsDetection displayablePointsDetection);

		// @required -(void)detectionFinishedWithDisplayablePoints:(MBCDisplayablePointsDetection *)displayablePointsDetection originalRectangle:(CGRect)originalRect relativeRectangle:(CGRect)relativeRectangle;
		[Abstract]
		[Export ("detectionFinishedWithDisplayablePoints:originalRectangle:relativeRectangle:")]
		void OriginalRectangle (MBCDisplayablePointsDetection displayablePointsDetection, CGRect originalRect, CGRect relativeRectangle);
	}

    // @interface MBCTapToFocusSubview : MBSubview
    [BaseType(typeof(MBCSubview))]
    interface MBCTapToFocusSubview
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export ("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);

        // -(void)willFocusAtPoint:(CGPoint)point;
        [Export ("willFocusAtPoint:")]
        void WillFocusAtPoint(CGPoint point);
    }

    // @protocol MBResultSubview <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBCResultSubview
    {
        // @required -(void)scanningFinishedWithState:(MBCRecognizerResultState)state;
        [Abstract]
        [Export ("scanningFinishedWithState:")]
        void ScanningFinishedWithState(MBCRecognizerResultState state);
    }

    // @interface MBGlareStatusSubview : MBSubview
    
    [BaseType(typeof(MBCSubview))]
    [DisableDefaultCtor]
    interface MBCGlareStatusSubview
    {
        // @property (nonatomic) UILabel * _Nonnull label;
        [Export ("label", ArgumentSemantic.Assign)]
        UILabel Label { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export ("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);

        // -(void)glareDetectionFinishedWithResult:(BOOL)glareFound;
        [Export ("glareDetectionFinishedWithResult:")]
        void GlareDetectionFinishedWithResult(bool glareFound);
    }

    // @interface MBBaseOcrOverlaySettings : MBBaseOverlaySettings
    
    [BaseType(typeof(MBCBaseOverlaySettings))]
    interface MBCBaseOcrOverlaySettings
    {
        // @property (nonatomic) BOOL showOcrDots;
        [Export ("showOcrDots")]
        bool ShowOcrDots { get; set; }
    }

    // @interface MBCBlinkCardOverlaySettings : MBCBaseOcrOverlaySettings
	[iOS (8,0)]
	[BaseType (typeof(MBCBaseOcrOverlaySettings))]
	interface MBCBlinkCardOverlaySettings
	{
		// @property (nonatomic, strong) NSString * _Nonnull glareStatusMessage;
		[Export ("glareStatusMessage", ArgumentSemantic.Strong)]
		string GlareStatusMessage { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull frontSideMessage;
		[Export ("frontSideMessage", ArgumentSemantic.Strong)]
		string FrontSideMessage { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull backSideMessage;
		[Export ("backSideMessage", ArgumentSemantic.Strong)]
		string BackSideMessage { get; set; }

		// @property (assign, nonatomic) BOOL showFlashlightWarning;
		[Export ("showFlashlightWarning")]
		bool ShowFlashlightWarning { get; set; }

		// @property (assign, nonatomic) BOOL enableEditScreen;
		[Export ("enableEditScreen")]
		bool EnableEditScreen { get; set; }

		// @property (nonatomic, strong) MBCBlinkCardEditFieldConfiguration * _Nonnull fieldConfiguration;
		[Export ("fieldConfiguration", ArgumentSemantic.Strong)]
		MBCBlinkCardEditFieldConfiguration FieldConfiguration { get; set; }
	}

    // @interface MBCBlinkCardEditFieldConfiguration : NSObject <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(NSObject))]
	interface MBCBlinkCardEditFieldConfiguration : INSCopying
	{
		// @property (assign, nonatomic) BOOL shouldDisplayCardNumber;
		[Export ("shouldDisplayCardNumber")]
		bool ShouldDisplayCardNumber { get; set; }

		// @property (assign, nonatomic) BOOL shouldDisplayOwner;
		[Export ("shouldDisplayOwner")]
		bool ShouldDisplayOwner { get; set; }

		// @property (assign, nonatomic) BOOL shouldDisplayCvv;
		[Export ("shouldDisplayCvv")]
		bool ShouldDisplayCvv { get; set; }

		// @property (assign, nonatomic) BOOL shouldDisplayExpiryDate;
		[Export ("shouldDisplayExpiryDate")]
		bool ShouldDisplayExpiryDate { get; set; }

		// @property (assign, nonatomic) BOOL shouldDisplayIban;
		[Export ("shouldDisplayIban")]
		bool ShouldDisplayIban { get; set; }

		// @property (assign, nonatomic) BOOL allowCardsWithInvalidFields;
		[Export ("allowCardsWithInvalidFields")]
		bool AllowCardsWithInvalidFields { get; set; }
	}

	// @interface MBCBlinkCardEditViewController : UIViewController
	[iOS (8,0)]
	[BaseType (typeof(UIViewController))]
	[DisableDefaultCtor]
	interface MBCBlinkCardEditViewController
	{
		// -(instancetype _Nonnull)initWithDelegate:(id<MBCBlinkCardEditViewControllerDelegate> _Nonnull)delegate;
		[Export ("initWithDelegate:")]
		IntPtr Constructor (MBCBlinkCardEditViewControllerDelegate @delegate);

		// -(instancetype _Nonnull)initWithBlinkCardRecognizerResult:(MBCBlinkCardRecognizerResult * _Nullable)result fieldConfiguration:(MBCBlinkCardEditFieldConfiguration * _Nonnull)fieldConfiguration delegate:(id<MBCBlinkCardEditViewControllerDelegate> _Nonnull)delegate;
		[Export ("initWithBlinkCardRecognizerResult:fieldConfiguration:delegate:")]
		IntPtr Constructor ([NullAllowed] MBCBlinkCardRecognizerResult result, MBCBlinkCardEditFieldConfiguration fieldConfiguration, MBCBlinkCardEditViewControllerDelegate @delegate);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		MBCBlinkCardEditViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MBCBlinkCardEditViewControllerDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }
	}

	// @protocol MBCBlinkCardEditViewControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MBCBlinkCardEditViewControllerDelegate
	{
		// @required -(void)blinkCardEditViewControllerDidFinishEditing:(MBCBlinkCardEditViewController * _Nonnull)blinkCardEditViewController editResult:(MBCBlinkCardEditResult * _Nonnull)editResult;
		[Abstract]
		[Export ("blinkCardEditViewControllerDidFinishEditing:editResult:")]
		void BlinkCardEditViewControllerDidFinishEditing (MBCBlinkCardEditViewController blinkCardEditViewController, MBCBlinkCardEditResult editResult);

		// @required -(void)blinkCardEditViewControllerDidTapClose:(MBCBlinkCardEditViewController * _Nonnull)blinkCardEditViewController;
		[Abstract]
		[Export ("blinkCardEditViewControllerDidTapClose:")]
		void BlinkCardEditViewControllerDidTapClose (MBCBlinkCardEditViewController blinkCardEditViewController);
	}

	// @interface MBCBlinkCardOverlayViewController : MBCBaseOverlayViewController
	[iOS (8,0)]
	[BaseType (typeof(MBCBaseOverlayViewController))]
	interface MBCBlinkCardOverlayViewController
	{
		// @property (readonly, nonatomic, strong) MBCBlinkCardOverlaySettings * _Nonnull settings;
		[Export ("settings", ArgumentSemantic.Strong)]
		MBCBlinkCardOverlaySettings Settings { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		MBCBlinkCardOverlayViewControllerDelegate Delegate { get; }

		// @property (readonly, nonatomic, weak) id<MBCBlinkCardOverlayViewControllerDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; }

		// @property (nonatomic, strong) MBCBlinkCardEditViewController * _Nullable blinkCardEditViewController;
		[NullAllowed, Export ("blinkCardEditViewController", ArgumentSemantic.Strong)]
		MBCBlinkCardEditViewController BlinkCardEditViewController { get; set; }

		// -(instancetype _Nonnull)initWithSettings:(MBCBlinkCardOverlaySettings * _Nonnull)settings recognizerCollection:(MBCRecognizerCollection * _Nonnull)recognizerCollection delegate:(id<MBCBlinkCardOverlayViewControllerDelegate> _Nonnull)delegate;
		[Export ("initWithSettings:recognizerCollection:delegate:")]
		IntPtr Constructor (MBCBlinkCardOverlaySettings settings, MBCRecognizerCollection recognizerCollection, MBCBlinkCardOverlayViewControllerDelegate @delegate);
	}

	// @protocol MBCBlinkCardOverlayViewControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MBCBlinkCardOverlayViewControllerDelegate
	{
		// @required -(void)blinkCardOverlayViewControllerDidFinishScanning:(MBCBlinkCardOverlayViewController * _Nonnull)blinkCardOverlayViewController state:(MBCRecognizerResultState)state;
		[Abstract]
		[Export ("blinkCardOverlayViewControllerDidFinishScanning:state:")]
		void BlinkCardOverlayViewControllerDidFinishScanning (MBCBlinkCardOverlayViewController blinkCardOverlayViewController, MBCRecognizerResultState state);

		// @required -(void)blinkCardOverlayViewControllerDidTapClose:(MBCBlinkCardOverlayViewController * _Nonnull)blinkCardOverlayViewController;
		[Abstract]
		[Export ("blinkCardOverlayViewControllerDidTapClose:")]
		void BlinkCardOverlayViewControllerDidTapClose (MBCBlinkCardOverlayViewController blinkCardOverlayViewController);

		// @optional -(void)blinkCardOverlayViewControllerDidFinishScanningFirstSide:(MBCBlinkCardOverlayViewController * _Nonnull)blinkCardOverlayViewController;
		[Export ("blinkCardOverlayViewControllerDidFinishScanningFirstSide:")]
		void BlinkCardOverlayViewControllerDidFinishScanningFirstSide (MBCBlinkCardOverlayViewController blinkCardOverlayViewController);

		// @optional -(void)blinkCardOverlayViewControllerDidFinishEditing:(MBCBlinkCardOverlayViewController * _Nonnull)blinkCardOverlayViewController editResult:(MBCBlinkCardEditResult * _Nonnull)editResult;
		[Export ("blinkCardOverlayViewControllerDidFinishEditing:editResult:")]
		void BlinkCardOverlayViewControllerDidFinishEditing (MBCBlinkCardOverlayViewController blinkCardOverlayViewController, MBCBlinkCardEditResult editResult);
	}

	// @interface MBCBlinkCardOverlayTheme : NSObject
	[iOS (9,0)]
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBCBlinkCardOverlayTheme
	{
		// +(instancetype _Nonnull)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		MBCBlinkCardOverlayTheme SharedInstance ();

		// @property (nonatomic, strong) UIFont * _Nonnull flashlightWarningFont;
		[Export ("flashlightWarningFont", ArgumentSemantic.Strong)]
		UIFont FlashlightWarningFont { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull flashlightWarningBackgroundColor;
		[Export ("flashlightWarningBackgroundColor", ArgumentSemantic.Strong)]
		UIColor FlashlightWarningBackgroundColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull flashlightWarningTextColor;
		[Export ("flashlightWarningTextColor", ArgumentSemantic.Strong)]
		UIColor FlashlightWarningTextColor { get; set; }

		// @property (assign, nonatomic) CGFloat flashlightWarningCornerRadius;
		[Export ("flashlightWarningCornerRadius")]
		nfloat FlashlightWarningCornerRadius { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull editButtonFont;
		[Export ("editButtonFont", ArgumentSemantic.Strong)]
		UIFont EditButtonFont { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull editButtonColor;
		[Export ("editButtonColor", ArgumentSemantic.Strong)]
		UIColor EditButtonColor { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull scanningStatusLabelFont;
		[Export ("scanningStatusLabelFont", ArgumentSemantic.Strong)]
		UIFont ScanningStatusLabelFont { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull scanningStatusLabelColor;
		[Export ("scanningStatusLabelColor", ArgumentSemantic.Strong)]
		UIColor ScanningStatusLabelColor { get; set; }
	}
}
