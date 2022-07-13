namespace BlinkCard.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer used for scanning both sides of payment cards.
    /// </summary>
    public interface ILegacyBlinkCardRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Should anonymize the card number area (redact image pixels) on the document image result 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AnonymizeCardNumber { get; set; }
        
        /// <summary>
        /// Should anonymize the CVV area (redact image pixels) on the document image result 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AnonymizeCvv { get; set; }
        
        /// <summary>
        /// Should anonymize the IBAN area (redact image pixels) on the document image result 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AnonymizeIban { get; set; }
        
        /// <summary>
        /// Should anonymize the owner area (redact image pixels) on the document image result 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AnonymizeOwner { get; set; }
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Should extract the card CVV 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCvv { get; set; }
        
        /// <summary>
        /// Should extract the card IBAN 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ExtractIban { get; set; }
        
        /// <summary>
        /// Should extract the card's inventory number 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractInventoryNumber { get; set; }
        
        /// <summary>
        /// Should extract the card owner information 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ExtractOwner { get; set; }
        
        /// <summary>
        /// Should extract the payment card's month of expiry 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidThru { get; set; }
        
        /// <summary>
        /// The DPI (Dots Per Inch) for full document image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        int FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// The extension factors for full document image. 
        ///
        /// By default, this is set to '[0.0, 0.0, 0.0, 0.0]'
        /// </summary>
        IImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        ILegacyBlinkCardRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ILegacyBlinkCardRecognizer.
    /// </summary>
    public interface ILegacyBlinkCardRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The payment card number. 
        /// </summary>
        string CardNumber { get; }
        
        /// <summary>
        /// Payment card's security code/value. 
        /// </summary>
        string Cvv { get; }
        
        /// <summary>
        /// Defines result of the data matching algorithm for scanned parts/sides of the document. 
        /// </summary>
        DataMatchResult DocumentDataMatch { get; }
        
        /// <summary>
        /// Back side image of the document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentBackImage { get; }
        
        /// <summary>
        /// Front side image of the document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentFrontImage { get; }
        
        /// <summary>
        /// Payment card's IBAN. 
        /// </summary>
        string Iban { get; }
        
        /// <summary>
        /// Payment card's inventory number. 
        /// </summary>
        string InventoryNumber { get; }
        
        /// <summary>
        /// The payment card's issuing network. 
        /// </summary>
        LegacyCardIssuer Issuer { get; }
        
        /// <summary>
        /// Information about the payment card owner (name, company, etc.) 
        /// </summary>
        string Owner { get; }
        
        /// <summary>
        /// {true} if recognizer has finished scanning first side and is now scanning back side, 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// The payment card's last month of validity. 
        /// </summary>
        IDate ValidThru { get; }
        
    }
}