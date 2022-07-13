using BlinkCard.Forms.Droid.Recognizers;
using BlinkCard.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BlinkCardRecognizer))]
namespace BlinkCard.Forms.Droid.Recognizers
{
    public sealed class BlinkCardRecognizer : Recognizer, IBlinkCardRecognizer
    {
        Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.BlinkCardRecognizer nativeRecognizer;

        BlinkCardRecognizerResult result;

        public BlinkCardRecognizer() : base(new Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.BlinkCardRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.BlinkCardRecognizer;
            result = new BlinkCardRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.BlinkCardRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBlinkCardRecognizerResult Result => result;

        
        public bool AllowBlurFilter 
        { 
            get => nativeRecognizer.ShouldAllowBlurFilter(); 
            set => nativeRecognizer.SetAllowBlurFilter(value);
        }
        
        public IBlinkCardAnonymizationSettings AnonymizationSettings 
        { 
            get => new BlinkCardAnonymizationSettings(nativeRecognizer.AnonymizationSettings); 
            set => nativeRecognizer.AnonymizationSettings = (value as BlinkCardAnonymizationSettings).NativeSettings;
        }
        
        public bool ExtractCvv 
        { 
            get => nativeRecognizer.ShouldExtractCvv(); 
            set => nativeRecognizer.SetExtractCvv(value);
        }
        
        public bool ExtractExpiryDate 
        { 
            get => nativeRecognizer.ShouldExtractExpiryDate(); 
            set => nativeRecognizer.SetExtractExpiryDate(value);
        }
        
        public bool ExtractIban 
        { 
            get => nativeRecognizer.ShouldExtractIban(); 
            set => nativeRecognizer.SetExtractIban(value);
        }
        
        public bool ExtractOwner 
        { 
            get => nativeRecognizer.ShouldExtractOwner(); 
            set => nativeRecognizer.SetExtractOwner(value);
        }
        
        public int FullDocumentImageDpi 
        { 
            get => nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = (int)value;
        }
        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeImageExtensionFactors;
        }
        
        public float PaddingEdge 
        { 
            get => nativeRecognizer.PaddingEdge; 
            set => nativeRecognizer.PaddingEdge = value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
    }

    public sealed class BlinkCardRecognizerResult : RecognizerResult, IBlinkCardRecognizerResult
    {
        Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.BlinkCardRecognizer.Result nativeResult;

        internal BlinkCardRecognizerResult(Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.BlinkCardRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string CardNumber => nativeResult.CardNumber;
        public string CardNumberPrefix => nativeResult.CardNumberPrefix;
        public bool CardNumberValid => nativeResult.IsCardNumberValid;
        public string Cvv => nativeResult.Cvv;
        public IDate ExpiryDate => nativeResult.ExpiryDate.Date != null ? new Date(nativeResult.ExpiryDate.Date) : null;
        public bool FirstSideBlurred => nativeResult.IsFirstSideBlurred;
        public Xamarin.Forms.ImageSource FirstSideFullDocumentImage => nativeResult.FirstSideFullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FirstSideFullDocumentImage.ConvertToBitmap()) : null;
        public string Iban => nativeResult.Iban;
        public Issuer Issuer => (Issuer)nativeResult.Issuer.Ordinal();
        public string Owner => nativeResult.Owner;
        public BlinkCardProcessingStatus ProcessingStatus => (BlinkCardProcessingStatus)nativeResult.ProcessingStatus.Ordinal();
        public bool ScanningFirstSideDone => nativeResult.IsScanningFirstSideDone;
        public bool SecondSideBlurred => nativeResult.IsSecondSideBlurred;
        public Xamarin.Forms.ImageSource SecondSideFullDocumentImage => nativeResult.SecondSideFullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.SecondSideFullDocumentImage.ConvertToBitmap()) : null;
    }
}