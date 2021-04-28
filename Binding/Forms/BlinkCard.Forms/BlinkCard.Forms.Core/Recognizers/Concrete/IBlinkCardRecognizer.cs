namespace BlinkCard.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer used for scanning both sides of payment cards.
    /// </summary>
    public interface IBlinkCardRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Whether blured frames filtering is allowed. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool AllowBlurFilter { get; set; }
        
        /// <summary>
        /// The settings which control the anonymization of returned data. 
        ///
        /// By default, this is set to '[0, 0, 0, 0, 0, 0, 0]'
        /// </summary>
        IBlinkCardAnonymizationSettings AnonymizationSettings { get; set; }
        
        /// <summary>
        /// Should extract the card CVV 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCvv { get; set; }
        
        /// <summary>
        /// Should extract the payment card's expiry date. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractExpiryDate { get; set; }
        
        /// <summary>
        /// Should extract the card IBAN 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIban { get; set; }
        
        /// <summary>
        /// Should extract the card owner information 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractOwner { get; set; }
        
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
        /// Padding is a minimum distance from the edge of the frame and it is defined as a percentage 
        ///
        /// By default, this is set to '0.0'
        /// </summary>
        float PaddingEdge { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        
        /// <summary>
        /// Defines whether or not recognition result should be signed. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool SignResult { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IBlinkCardRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IBlinkCardRecognizer.
    /// </summary>
    public interface IBlinkCardRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The payment card number. 
        /// </summary>
        string CardNumber { get; }
        
        /// <summary>
        /// The payment card number prefix. 
        /// </summary>
        string CardNumberPrefix { get; }
        
        /// <summary>
        /// Flag which indicatew whether the payment card number is valid or not. 
        /// </summary>
        bool CardNumberValid { get; }
        
        /// <summary>
        /// Payment card's security code/value. 
        /// </summary>
        string Cvv { get; }
        
        /// <summary>
        /// Defines digital signature of recognition results. 
        /// </summary>
        byte[] DigitalSignature { get; }
        
        /// <summary>
        /// Defines digital signature version. 
        /// </summary>
        int DigitalSignatureVersion { get; }
        
        /// <summary>
        /// The payment card's expiry date. 
        /// </summary>
        IDate ExpiryDate { get; }
        
        /// <summary>
        /// Whether the first scanned side is blurred. 
        /// </summary>
        bool FirstSideBlurred { get; }
        
        /// <summary>
        /// Full image of the payment card from first side recognition. 
        /// </summary>
        Xamarin.Forms.ImageSource FirstSideFullDocumentImage { get; }
        
        /// <summary>
        /// Payment card's IBAN. 
        /// </summary>
        string Iban { get; }
        
        /// <summary>
        /// Payment card's issuing network. 
        /// </summary>
        Issuer Issuer { get; }
        
        /// <summary>
        /// Information about the payment card owner. 
        /// </summary>
        string Owner { get; }
        
        /// <summary>
        /// Status of the last recognition process. 
        /// </summary>
        BlinkCardProcessingStatus ProcessingStatus { get; }
        
        /// <summary>
        /// {true} if recognizer has finished scanning first side and is now scanning back side, 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// Whether the second scanned side is blurred. 
        /// </summary>
        bool SecondSideBlurred { get; }
        
        /// <summary>
        /// Full image of the payment card from second side recognition. 
        /// </summary>
        Xamarin.Forms.ImageSource SecondSideFullDocumentImage { get; }
        
    }
}