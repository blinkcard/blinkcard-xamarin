using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using ObjCRuntime;

namespace BlinkCard
{
	
	[Native]
	public enum MBCCameraPreset : ulong
	{
		MBCCameraPreset480p,
		MBCCameraPreset720p,
		MBCCameraPreset1080p,
		MBCCameraPreset4K,
		Optimal,
		Max,
		Photo
	}

	[Native]
	public enum MBCCameraType : ulong
	{
		Back,
		Front
	}

	[Native]
	public enum MBCCameraAutofocusRestriction : ulong
	{
		None,
		Near,
		Far
	}

	[Native]
	public enum MBCLicenseError : ulong
	{
		NetworkRequired,
		UnableToDoRemoteLicenceCheck,
		LicenseIsLocked,
		LicenseCheckFailed,
		InvalidLicense,
		PermissionExpired,
		PayloadCorrupted,
		PayloadSignatureVerificationFailed,
		IncorrectTokenState
	}

	[Native]
	public enum MBCProcessingOrientation : ulong
	{
		Up,
		Right,
		Down,
		Left
	}

	[Native]
	public enum MBCRecognizerResultState : ulong
	{
		Empty,
		Uncertain,
		Valid,
		StageValid
	}

	[Native]
	public enum MBCDataMatchResult : ulong
	{
		NotPerformed = 0,
		Failed,
		Success
	}

	[Native]
	public enum MBCIssuer : ulong
	{
		Other = 0,
		AmericanExpress,
		ChinaUnionPay,
		Diners,
		DiscoverCard,
		Elo,
		Jcb,
		Maestro,
		Mastercard,
		RuPay,
		Verve,
		Visa,
		VPay
	}

	[Native]
	public enum MBCBlinkCardProcessingStatus : ulong
	{
		Success,
		DetectionFailed,
		ImagePreprocessingFailed,
		StabilityTestFailed,
		ScanningWrongSide,
		FieldIdentificationFailed,
		ImageReturnFailed,
		UnsupportedCard
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct MBCImageExtensionFactors
	{
		public nfloat top;

		public nfloat right;

		public nfloat bottom;

		public nfloat left;
	}

	[Native]
	public enum MBCBlinkCardAnonymizationMode : ulong
	{
		None = 0,
		ImageOnly,
		ResultFieldsOnly,
		FullResult
	}

	[Native]
	public enum MBCLegacyCardIssuer : ulong
	{
		Other = 0,
		AmericanExpress,
		BmoAbm,
		ChinaTUnion,
		ChinaUnionPay,
		CibcAdvantageDebit,
		Ciss,
		DinersClubInternational,
		DinersClubUsCanada,
		DiscoverCard,
		Hsbc,
		RuPay,
		InterPayment,
		InstaPayment,
		Jcb,
		Laser,
		Maestro,
		Dankort,
		Mir,
		MasterCard,
		RbcClient,
		ScotiaBank,
		TdCtAccess,
		Troy,
		Visa,
		Uatp,
		Verve
	}

	[Native]
	public enum MBCDetectionStatus : ulong
	{
		Success = 1 << 0,
		Fail = 1 << 1,
		CameraTooHigh = 1 << 2,
		CameraAtAngle = 1 << 3,
		CameraRotated = 1 << 4,
		QRSuccess = 1 << 6,
		Pdf417Success = 1 << 7,
		FallbackSuccess = 1 << 8,
		PartialForm = 1 << 9,
		CameraTooNear = 1 << 10,
		DocumentTooCloseToEdge = 1 << 11
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct CGLine
	{
		public CGPoint point1;

		public CGPoint point2;
	}

	[Native]
	public enum MBCRecognitionDebugMode : ulong
	{
		Default,
		Test,
		DetectionTest
	}

	[Native]
	public enum MBCFrameQualityEstimationMode : ulong
	{
		Default,
		On,
		Off
	}

	[Native]
	public enum MBCRectDocumentSubviewScanMode : ulong
	{
		Initalized,
		Scanning,
		FirstSideScanWillFinish,
		WillErrorCameraTooNear,
		DidCameraTooNear,
		WillErrorCameraTooFar,
		DidErrorCameraTooFar,
		WillErrorFieldIdentificationFailed,
		DidErrorFieldIdentificationFailed,
		ScanFinished
	}

	[Native]
	public enum MBCOcrFont : ulong
	{
		AkzidenzGrotesk,
		Arial,
		ArialBlack,
		Arnhem,
		AvantGarde,
		Bembo,
		Bodoni,
		Calibri,
		CalibriBold,
		Chainprinter,
		ComicSans,
		ConcertoRoundedSg,
		Courier,
		CourierBold,
		CourierMediumBold,
		CourierNewBold,
		CourierNewCe,
		CourierCondensed,
		DejavuSansMono,
		Din,
		EuropaGroteskNo2SbBold,
		Eurostile,
		F25BankPrinterBold,
		FranklinGothic,
		Frutiger,
		Futura,
		FuturaBold,
		Garamond,
		Georgia,
		GillSans,
		Handwritten,
		Helvetica,
		HelveticaBold,
		HelveticaCondensedLight,
		Hypermarket,
		Interstate,
		LatinModern,
		LatinModernItalic,
		LetterGothic,
		Lucida,
		LucidaSans,
		Matrix,
		Meta,
		Minion,
		Ocra,
		Ocrb,
		Officina,
		Optima,
		Printf,
		Rockwell,
		RotisSansSerif,
		RotisSerif,
		Sabon,
		Stone,
		SvBasicManual,
		Tahoma,
		TahomaBold,
		TexGyreTermes,
		TexGyreTermesItalic,
		TheSansMonoCondensedBlack,
		Thesis,
		TicketDeCaisse,
		TimesNewRoman,
		Trajan,
		Trinite,
		Univers,
		Verdana,
		Voltaire,
		Walbaum,
		EuropaGroSb,
		EuropaGroSbLight,
		AntonioRegular,
		CorporateLight,
		Micr,
		ArabicNile,
		Unknown,
		XitsMath,
		Any,
		UnknownMath,
		UkdlLight,
		Count,
		FeSchrift
	}

	[Native]
	public enum MBCLogLevel : ulong
	{
		Error,
		Warning,
		Info,
		Debug,
		Verbose
	}
}