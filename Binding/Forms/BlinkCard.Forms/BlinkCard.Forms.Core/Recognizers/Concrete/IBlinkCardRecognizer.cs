namespace BlinkCard.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer used for scanning credit/debit cards.
    /// </summary>
    public interface IBlinkCardRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether blured frames filtering is allowed
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool AllowBlurFilter { get; set; }
        
        /// <summary>
        /// Defines whether sensitive data should be redacted from the result.
        /// 
        ///  
        ///
        /// By default, this is set to '[0, 0, 0, 0, 0, 0, 0]'
        /// </summary>
        IBlinkCardAnonymizationSettings AnonymizationSettings { get; set; }
        
        /// <summary>
        /// Should extract CVV
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCvv { get; set; }
        
        /// <summary>
        /// Should extract the payment card's month of expiry
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractExpiryDate { get; set; }
        
        /// <summary>
        /// Should extract the payment card's IBAN
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIban { get; set; }
        
        /// <summary>
        /// Should extract the card owner information
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractOwner { get; set; }
        
        /// <summary>
        /// Property for setting DPI for full document images
        /// Valid ranges are [100,400]. Setting DPI out of valid ranges throws an exception
        /// 
        ///  
        ///
        /// By default, this is set to '250'
        /// </summary>
        int FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// Image extension factors for full document image.
        /// 
        /// @see CImageExtensionFactors
        ///  
        ///
        /// By default, this is set to '[0.0, 0.0, 0.0, 0.0]'
        /// </summary>
        IImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
        
        /// <summary>
        /// Pading is a minimum distance from the edge of the frame and is defined as a percentage of the frame width. Default value is 0.0f and in that case
        /// padding edge and image edge are the same.
        /// Recommended value is 0.02f.
        /// 
        ///  
        ///
        /// By default, this is set to '0.0'
        /// </summary>
        float PaddingEdge { get; set; }
        
        /// <summary>
        /// Sets whether full document image of ID card should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        

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
        /// The payment card number is valid 
        /// </summary>
        bool CardNumberValid { get; }
        
        /// <summary>
        ///  Payment card's security code/value. 
        /// </summary>
        string Cvv { get; }
        
        /// <summary>
        /// The payment card's expiry date. 
        /// </summary>
        IDate ExpiryDate { get; }
        
        /// <summary>
        /// Wheater the first scanned side is blurred. 
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
        /// Information about the payment card owner (name, company, etc.). 
        /// </summary>
        string Owner { get; }
        
        /// <summary>
        /// Status of the last recognition process. 
        /// </summary>
        BlinkCardProcessingStatus ProcessingStatus { get; }
        
        /// <summary>
        /// Returns true if recognizer has finished scanning first side and is now scanning back side,
        /// false if it's still scanning first side. 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// Wheater the second scanned side is blurred. 
        /// </summary>
        bool SecondSideBlurred { get; }
        
        /// <summary>
        /// Full image of the payment card from second side recognition. 
        /// </summary>
        Xamarin.Forms.ImageSource SecondSideFullDocumentImage { get; }
        
    }
}