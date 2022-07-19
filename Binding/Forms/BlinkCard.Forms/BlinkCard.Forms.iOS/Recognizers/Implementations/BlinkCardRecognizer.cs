using BlinkCard.Forms.iOS.Recognizers;
using BlinkCard.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BlinkCardRecognizer))]
namespace BlinkCard.Forms.iOS.Recognizers
{
    public sealed class BlinkCardRecognizer : Recognizer, IBlinkCardRecognizer
    {
        MBCBlinkCardRecognizer nativeRecognizer;

        BlinkCardRecognizerResult result;

        public BlinkCardRecognizer() : base(new MBCBlinkCardRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBCBlinkCardRecognizer;
            result = new BlinkCardRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBlinkCardRecognizerResult Result => result;

        
        
        public bool AllowBlurFilter 
        { 
            get => nativeRecognizer.AllowBlurFilter; 
            set => nativeRecognizer.AllowBlurFilter = value;
        }
        
        
        
        public IBlinkCardAnonymizationSettings AnonymizationSettings 
        { 
            get => new BlinkCardAnonymizationSettings(nativeRecognizer.AnonymizationSettings); 
            set => nativeRecognizer.AnonymizationSettings = (value as BlinkCardAnonymizationSettings).NativeBlinkCardAnonymizationSettings;
        }
        
        
        
        public bool ExtractCvv 
        { 
            get => nativeRecognizer.ExtractCvv; 
            set => nativeRecognizer.ExtractCvv = value;
        }
        
        
        
        public bool ExtractExpiryDate 
        { 
            get => nativeRecognizer.ExtractExpiryDate; 
            set => nativeRecognizer.ExtractExpiryDate = value;
        }
        
        
        
        public bool ExtractIban 
        { 
            get => nativeRecognizer.ExtractIban; 
            set => nativeRecognizer.ExtractIban = value;
        }
        
        
        
        public bool ExtractOwner 
        { 
            get => nativeRecognizer.ExtractOwner; 
            set => nativeRecognizer.ExtractOwner = value;
        }
        
        
        
        public int FullDocumentImageDpi 
        { 
            get => (int)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = value;
        }
        
        
        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeFactors;
        }
        
        
        
        public float PaddingEdge 
        { 
            get => (float)nativeRecognizer.PaddingEdge; 
            set => nativeRecognizer.PaddingEdge = value;
        }
        
        
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
        
    }

    public sealed class BlinkCardRecognizerResult : RecognizerResult, IBlinkCardRecognizerResult
    {
        MBCBlinkCardRecognizerResult nativeResult;

        internal BlinkCardRecognizerResult(MBCBlinkCardRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string CardNumber => nativeResult.CardNumber;
        public string CardNumberPrefix => nativeResult.CardNumberPrefix;
        public bool CardNumberValid => nativeResult.CardNumberValid;
        public string Cvv => nativeResult.Cvv;
        public IDate ExpiryDate => nativeResult.ExpiryDate != null ? new Date(nativeResult.ExpiryDate) : null;
        public bool FirstSideBlurred => nativeResult.FirstSideBlurred;
        public Xamarin.Forms.ImageSource FirstSideFullDocumentImage => nativeResult.FirstSideFullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FirstSideFullDocumentImage.Image) : null;
        public string Iban => nativeResult.Iban;
        public Issuer Issuer => (Issuer)nativeResult.Issuer;
        public string Owner => nativeResult.Owner;
        public BlinkCardProcessingStatus ProcessingStatus => (BlinkCardProcessingStatus)nativeResult.ProcessingStatus;
        public bool ScanningFirstSideDone => nativeResult.ScanningFirstSideDone;
        public bool SecondSideBlurred => nativeResult.SecondSideBlurred;
        public Xamarin.Forms.ImageSource SecondSideFullDocumentImage => nativeResult.SecondSideFullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.SecondSideFullDocumentImage.Image) : null;
    }
}