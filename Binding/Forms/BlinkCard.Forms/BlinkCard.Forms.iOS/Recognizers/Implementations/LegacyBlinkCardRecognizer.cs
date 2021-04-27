using BlinkCard.Forms.iOS.Recognizers;
using BlinkCard.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(LegacyBlinkCardRecognizer))]
namespace BlinkCard.Forms.iOS.Recognizers
{
    public sealed class LegacyBlinkCardRecognizer : Recognizer, ILegacyBlinkCardRecognizer
    {
        MBCLegacyBlinkCardRecognizer nativeRecognizer;

        LegacyBlinkCardRecognizerResult result;

        public LegacyBlinkCardRecognizer() : base(new MBCLegacyBlinkCardRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBCLegacyBlinkCardRecognizer;
            result = new LegacyBlinkCardRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ILegacyBlinkCardRecognizerResult Result => result;

        
        
        public bool AnonymizeCardNumber 
        { 
            get => nativeRecognizer.AnonymizeCardNumber; 
            set => nativeRecognizer.AnonymizeCardNumber = value;
        }
        
        
        
        public bool AnonymizeCvv 
        { 
            get => nativeRecognizer.AnonymizeCvv; 
            set => nativeRecognizer.AnonymizeCvv = value;
        }
        
        
        
        public bool AnonymizeIban 
        { 
            get => nativeRecognizer.AnonymizeIban; 
            set => nativeRecognizer.AnonymizeIban = value;
        }
        
        
        
        public bool AnonymizeOwner 
        { 
            get => nativeRecognizer.AnonymizeOwner; 
            set => nativeRecognizer.AnonymizeOwner = value;
        }
        
        
        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        
        
        public bool ExtractCvv 
        { 
            get => nativeRecognizer.ExtractCvv; 
            set => nativeRecognizer.ExtractCvv = value;
        }
        
        
        
        public bool ExtractIban 
        { 
            get => nativeRecognizer.ExtractIban; 
            set => nativeRecognizer.ExtractIban = value;
        }
        
        
        
        public bool ExtractInventoryNumber 
        { 
            get => nativeRecognizer.ExtractInventoryNumber; 
            set => nativeRecognizer.ExtractInventoryNumber = value;
        }
        
        
        
        public bool ExtractOwner 
        { 
            get => nativeRecognizer.ExtractOwner; 
            set => nativeRecognizer.ExtractOwner = value;
        }
        
        
        
        public bool ExtractValidThru 
        { 
            get => nativeRecognizer.ExtractValidThru; 
            set => nativeRecognizer.ExtractValidThru = value;
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
        
        
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
        
        
        public bool SignResult 
        { 
            get => nativeRecognizer.SignResult; 
            set => nativeRecognizer.SignResult = value;
        }
        
        
    }

    public sealed class LegacyBlinkCardRecognizerResult : RecognizerResult, ILegacyBlinkCardRecognizerResult
    {
        MBCLegacyBlinkCardRecognizerResult nativeResult;

        internal LegacyBlinkCardRecognizerResult(MBCLegacyBlinkCardRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string CardNumber => nativeResult.CardNumber;
        public string Cvv => nativeResult.Cvv;
        public byte[] DigitalSignature => nativeResult.DigitalSignature != null ? nativeResult.DigitalSignature.ToArray() : null;
        public int DigitalSignatureVersion => (int)nativeResult.DigitalSignatureVersion;
        public DataMatchResult DocumentDataMatch => (DataMatchResult)nativeResult.DocumentDataMatch;
        public Xamarin.Forms.ImageSource FullDocumentBackImage => nativeResult.FullDocumentBackImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentBackImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => nativeResult.FullDocumentFrontImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentFrontImage.Image) : null;
        public string Iban => nativeResult.Iban;
        public string InventoryNumber => nativeResult.InventoryNumber;
        public LegacyCardIssuer Issuer => (LegacyCardIssuer)nativeResult.Issuer;
        public string Owner => nativeResult.Owner;
        public bool ScanningFirstSideDone => nativeResult.ScanningFirstSideDone;
        public IDate ValidThru => nativeResult.ValidThru != null ? new Date(nativeResult.ValidThru) : null;
    }
}