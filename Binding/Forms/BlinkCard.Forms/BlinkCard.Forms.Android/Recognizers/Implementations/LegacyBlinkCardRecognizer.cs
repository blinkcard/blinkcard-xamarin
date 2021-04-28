using BlinkCard.Forms.Droid.Recognizers;
using BlinkCard.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(LegacyBlinkCardRecognizer))]
namespace BlinkCard.Forms.Droid.Recognizers
{
    public sealed class LegacyBlinkCardRecognizer : Recognizer, ILegacyBlinkCardRecognizer
    {
        Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.Legacy.LegacyBlinkCardRecognizer nativeRecognizer;

        LegacyBlinkCardRecognizerResult result;

        public LegacyBlinkCardRecognizer() : base(new Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.Legacy.LegacyBlinkCardRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.Legacy.LegacyBlinkCardRecognizer;
            result = new LegacyBlinkCardRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.Legacy.LegacyBlinkCardRecognizer.Result);
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
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractCvv 
        { 
            get => nativeRecognizer.ShouldExtractCvv(); 
            set => nativeRecognizer.SetExtractCvv(value);
        }
        
        public bool ExtractIban 
        { 
            get => nativeRecognizer.ShouldExtractIban(); 
            set => nativeRecognizer.SetExtractIban(value);
        }
        
        public bool ExtractInventoryNumber 
        { 
            get => nativeRecognizer.ShouldExtractInventoryNumber(); 
            set => nativeRecognizer.SetExtractInventoryNumber(value);
        }
        
        public bool ExtractOwner 
        { 
            get => nativeRecognizer.ShouldExtractOwner(); 
            set => nativeRecognizer.SetExtractOwner(value);
        }
        
        public bool ExtractValidThru 
        { 
            get => nativeRecognizer.ShouldExtractValidThru(); 
            set => nativeRecognizer.SetExtractValidThru(value);
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
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
        public bool SignResult 
        { 
            get => nativeRecognizer.ShouldSignResult(); 
            set => nativeRecognizer.SetSignResult(value);
        }
        
    }

    public sealed class LegacyBlinkCardRecognizerResult : RecognizerResult, ILegacyBlinkCardRecognizerResult
    {
        Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.Legacy.LegacyBlinkCardRecognizer.Result nativeResult;

        internal LegacyBlinkCardRecognizerResult(Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.Legacy.LegacyBlinkCardRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string CardNumber => nativeResult.CardNumber;
        public string Cvv => nativeResult.Cvv;
        public byte[] DigitalSignature => nativeResult.GetDigitalSignature();
        public int DigitalSignatureVersion => (int)nativeResult.DigitalSignatureVersion;
        public DataMatchResult DocumentDataMatch => (DataMatchResult)nativeResult.DocumentDataMatch.Ordinal();
        public Xamarin.Forms.ImageSource FullDocumentBackImage => nativeResult.FullDocumentBackImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentBackImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => nativeResult.FullDocumentFrontImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentFrontImage.ConvertToBitmap()) : null;
        public string Iban => nativeResult.Iban;
        public string InventoryNumber => nativeResult.InventoryNumber;
        public LegacyCardIssuer Issuer => (LegacyCardIssuer)nativeResult.Issuer.Ordinal();
        public string Owner => nativeResult.Owner;
        public bool ScanningFirstSideDone => nativeResult.IsScanningFirstSideDone;
        public IDate ValidThru => nativeResult.ValidThru.Date != null ? new Date(nativeResult.ValidThru.Date) : null;
    }
}