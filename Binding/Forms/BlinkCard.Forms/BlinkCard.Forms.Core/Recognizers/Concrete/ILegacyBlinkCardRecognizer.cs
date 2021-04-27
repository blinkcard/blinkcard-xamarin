﻿namespace BlinkCard.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer used for scanning the front side of credit/debit cards.
    /// </summary>
    public interface ILegacyBlinkCardRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Should anonymize the card number area (redact image pixels) on the document image result
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AnonymizeCardNumber { get; set; }
        
        /// <summary>
        /// Should anonymize the CVV on the document image result
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AnonymizeCvv { get; set; }
        
        /// <summary>
        /// Should anonymize the IBAN area (redact image pixels) on the document image result
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AnonymizeIban { get; set; }
        
        /// <summary>
        /// Should anonymize the owner area (redact image pixels) on the document image result
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AnonymizeOwner { get; set; }
        
        /// <summary>
        /// Defines if glare detection should be turned on/off.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Should extract CVV
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCvv { get; set; }
        
        /// <summary>
        /// Should extract the payment card's IBAN
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ExtractIban { get; set; }
        
        /// <summary>
        /// Should extract the card's inventory number
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractInventoryNumber { get; set; }
        
        /// <summary>
        /// Should extract the card owner information
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ExtractOwner { get; set; }
        
        /// <summary>
        /// Should extract the payment card's month of expiry
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidThru { get; set; }
        
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
        /// By default, this is set to '{0.0f, 0.0f, 0.0f, 0.0f}'
        /// </summary>
        IImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
        
        /// <summary>
        /// Sets whether full document image of ID card should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        
        /// <summary>
        /// Whether or not recognition result should be signed.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool SignResult { get; set; }
        

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
        ///  Payment card's security code/value 
        /// </summary>
        string Cvv { get; }
        
        /// <summary>
        /// Digital signature of the recognition result. Available only if enabled with signResult property. 
        /// </summary>
        byte[] DigitalSignature { get; }
        
        /// <summary>
        /// Version of the digital signature. Available only if enabled with signResult property. 
        /// </summary>
        int DigitalSignatureVersion { get; }
        
        /// <summary>
        /// Returns CDataMatchResultSuccess if data from scanned parts/sides of the document match,
        /// CDataMatchResultFailed otherwise. For example if date of expiry is scanned from the front and back side
        /// of the document and values do not match, this method will return CDataMatchResultFailed. Result will
        /// be CDataMatchResultSuccess only if scanned values for all fields that are compared are the same. 
        /// </summary>
        DataMatchResult DocumentDataMatch { get; }
        
        /// <summary>
        /// back side image of the document if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentBackImage { get; }
        
        /// <summary>
        /// front side image of the document if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentFrontImage { get; }
        
        /// <summary>
        /// Payment card's IBAN 
        /// </summary>
        string Iban { get; }
        
        /// <summary>
        /// Payment card's inventory number. 
        /// </summary>
        string InventoryNumber { get; }
        
        /// <summary>
        /// Payment card's issuing network 
        /// </summary>
        LegacyCardIssuer Issuer { get; }
        
        /// <summary>
        /// Information about the payment card owner (name, company, etc.). 
        /// </summary>
        string Owner { get; }
        
        /// <summary>
        /// Returns true if recognizer has finished scanning first side and is now scanning back side,
        /// false if it's still scanning first side. 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// The payment card's last month of validity. 
        /// </summary>
        IDate ValidThru { get; }
        
    }
}