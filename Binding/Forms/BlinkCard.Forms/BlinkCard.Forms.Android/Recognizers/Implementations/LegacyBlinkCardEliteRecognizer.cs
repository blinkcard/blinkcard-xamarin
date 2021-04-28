using BlinkCard.Forms.Droid.Recognizers;
using BlinkCard.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(LegacyBlinkCardEliteRecognizer))]
namespace BlinkCard.Forms.Droid.Recognizers
{
    public sealed class LegacyBlinkCardEliteRecognizer : Recognizer, ILegacyBlinkCardEliteRecognizer
    {
        Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.Legacy.LegacyBlinkCardEliteRecognizer nativeRecognizer;

        LegacyBlinkCardEliteRecognizerResult result;

        public LegacyBlinkCardEliteRecognizer() : base(new Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.Legacy.LegacyBlinkCardEliteRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.Legacy.LegacyBlinkCardEliteRecognizer;
            result = new LegacyBlinkCardEliteRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.Legacy.LegacyBlinkCardEliteRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ILegacyBlinkCardEliteRecognizerResult Result => result;

        
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

    public sealed class LegacyBlinkCardEliteRecognizerResult : RecognizerResult, ILegacyBlinkCardEliteRecognizerResult
    {
        Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.Legacy.LegacyBlinkCardEliteRecognizer.Result nativeResult;

        internal LegacyBlinkCardEliteRecognizerResult(Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.Legacy.LegacyBlinkCardEliteRecognizer.Result nativeResult) : base(nativeResult)
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
        public string InventoryNumber => nativeResult.InventoryNumber;
        public string Owner => nativeResult.Owner;
        public bool ScanningFirstSideDone => nativeResult.IsScanningFirstSideDone;
        public IDate ValidThru => nativeResult.ValidThru.Date != null ? new Date(nativeResult.ValidThru.Date) : null;
    }
}