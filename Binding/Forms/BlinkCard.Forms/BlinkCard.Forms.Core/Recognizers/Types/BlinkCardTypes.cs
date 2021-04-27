using System;
namespace BlinkCard.Forms.Core.Recognizers
{
    /// <summary>
    /// Supported Legacy BlinkCard card issuer values.
    /// </summary>
    public enum LegacyCardIssuer
    {
        /// <summary>
        /// Unidentified Card
        /// </summary>
        Other,
        /// <summary>
        /// The American Express Company Card
        /// </summary>
        AmericanExpress,
        /// <summary>
        /// The Bank of Montreal ABM Card
        /// </summary>
        BmoAbm,
        /// <summary>
        /// China T-Union Transportation Card
        /// </summary>
        ChinaTUnion,
        /// <summary>
        /// China UnionPay Card
        /// </summary>
        ChinaUnionPay,
        /// <summary>
        /// Canadian Imperial Bank of Commerce Advantage Debit Card
        /// </summary>
        CibcAdvantageDebit,
        /// <summary>
        /// CISS Card
        /// </summary>
        Ciss,
        /// <summary>
        /// Diners Club International Card
        /// </summary>
        DinersClubInternational,
        /// <summary>
        /// Diners Club United States & Canada Card
        /// </summary>
        DinersClubUsCanada,
        /// <summary>
        /// Discover Card
        /// </summary>
        DiscoverCard,
        /// <summary>
        /// HSBC Bank Canada Card
        /// </summary>
        Hsbc,
        /// <summary>
        /// RuPay Card
        /// </summary>
        RuPay,
        /// <summary>
        /// InterPayment Card
        /// </summary>
        InterPayment,
        /// <summary>
        /// InstaPayment Card
        /// </summary>
        InstaPayment,
        /// <summary>
        /// The JCB Company Card
        /// </summary>
        Jcb,
        /// <summary>
        /// Laser Debit Card (deprecated)
        /// </summary>
        Laser,
        /// <summary>
        /// Maestro Debit Card
        /// </summary>
        Maestro,
        /// <summary>
        /// Dankort Card
        /// </summary>
        Dankort,
        /// <summary>
        /// MIR Card
        /// </summary>
        Mir,
        /// <summary>
        /// MasterCard Inc. Card
        /// </summary>
        MasterCard,
        /// <summary>
        /// The Royal Bank of Canada Client Card
        /// </summary>
        RbcClient,
        /// <summary>
        /// ScotiaBank Scotia Card
        /// </summary>
        ScotiaBank,
        /// <summary>
        /// TD Canada Trust Access Card
        /// </summary>
        TdCtAccess,
        /// <summary>
        /// Troy Card
        /// </summary>
        Troy,
        /// <summary>
        /// Visa Inc. Card
        /// </summary>
        Visa,
        /// <summary>
        /// Universal Air Travel Plan Inc. Card
        /// </summary>
        Uatp,
        /// <summary>
        /// Interswitch Verve Card
        /// </summary>
        Verve
    }

    /// <summary>
    /// Supported BlinkCard card issuer values.
    /// </summary>
    public enum Issuer {
        /// Unidentified Card
        Other,
        /// The American Express Company Card
        AmericanExpress,
        /// China UnionPay Card
        ChinaUnionPay,
        /// Diners Club International Card
        Diners,
        /// Discover Card
        DiscoverCard,
        /// Elo card association
        Elo,
        /// The JCB Company Card
        Jcb,
        /// Maestro Debit Card
        Maestro,
        /// Mastercard Inc. Card
        Mastercard,
        /// RuPay
        RuPay,
        /// Interswitch Verve Card
        Verve,
        /// Visa Inc. Card
        Visa,
        /// VPay
        VPay
    }

    /// <summary>
    /// Supported BlinkCard processing status values
    /// </summary>
    public enum BlinkCardProcessingStatus {
        /// Recognition was successful.
        Success,
        /// Detection of the document failed.
        DetectionFailed,
        /// Preprocessing of the input image has failed.
        ImagePreprocessingFailed,
        /// Recognizer has inconsistent results.
        StabilityTestFailed,
        /// Wrong side of the document has been scanned.
        ScanningWrongSide,
        /// Identification of the fields present on the document has failed.
        FieldIdentificationFailed,
        /// Failed to return a requested image.
        ImageReturnFailed,
        /// Payment card currently not supported by the recognizer.
        UnsupportedCard
    }

    /// <summary>
    /// Determines which data is anonymized in the returned recognizer result.
    /// </summary>
    public enum BlinkCardAnonymizationMode
    {
        // No anonymization is performed in this mode.
        None,

        // Sensitive data in the document image is anonymized with black boxes covering selected sensitive data. Data returned in result fields is not changed.
        ImageOnly,

        // Document image is not changed. Data returned in result fields is redacted.
        ResultFieldsOnly,

        // Sensitive data in the image is anonymized with black boxes covering selected sensitive data. Data returned in result fields is redacted.
        FullResult
    }

    /// <summary>
    /// ICardNumberAnonymizationSettings Holds the settings which control card number anonymization.
    /// </summary>
    public interface ICardNumberAnonymizationSettings
    {
        /// <summary>
        /// Defines the mode of card number anonymization.
        /// </summary>
        /// <value>BlinkCardAnonymizationMode</value>
        BlinkCardAnonymizationMode Mode { get; }

        /// <summary>
        /// Defines how many digits at the beginning of the card number remain visible after anonymization.
        /// </summary>
        int PrefixDigitsVisible { get; }

        /// <summary>
        /// Defines how many digits at the end of the card number remain visible after anonymization.
        /// </summary>
        /// <value>Enable Mrz Passport.</value>
        int SuffixDigitsVisible { get; }
    }

    /// <summary>
    /// Use this to create an instance of ICardNumberAnonymizationSettings.
    /// </summary>
    public interface ICardNumberAnonymizationSettingsFactory
    {
        /// <summary>
        /// Creates the card number anonymization settings
        /// </summary>
        /// <returns>Card number anonymization settings.</returns>
        /// <param name="mode">defines the mode of card number anonymization.</param>
        /// <param name="prefixDigitsVisible">Defines how many digits at the beginning of the card number remain visible after anonymization.</param>
        /// <param name="suffixDigitsVisible">Defines how many digits at the end of the card number remain visible after anonymization.</param>
        ICardNumberAnonymizationSettings CreateCardNumberAnonymizationSettings(BlinkCardAnonymizationMode mode = BlinkCardAnonymizationMode.None, int prefixDigitsVisible = 0, int suffixDigitsVisible = 0);
    }

    /// <summary>
    /// IBlinkCardAnonymizationSettings Holds the settings which control blink card anonymization.
    /// </summary>
    public interface IBlinkCardAnonymizationSettings
    {
        /// <summary>
        /// Defines the parameters of card number anonymization.
        /// </summary>
        /// <value>ICardNumberAnonymizationSettings</value>
        ICardNumberAnonymizationSettings CardNumberAnonymizationSettings { get; }

        /// <summary>
        /// Defines the mode of card number prefix anonymization.
        /// </summary>
        /// <value>BlinkCardAnonymizationMode</value>
        BlinkCardAnonymizationMode CardNumberPrefixAnonymizationMode { get; }

        /// <summary>
        /// Defines the mode of CVV anonymization.
        /// </summary>
        /// <value>BlinkCardAnonymizationMode</value>
        BlinkCardAnonymizationMode CvvAnonymizationMode { get; }

        /// <summary>
        /// Defines the mode of IBAN anonymization.
        /// </summary>
        /// <value>BlinkCardAnonymizationMode</value>
        BlinkCardAnonymizationMode IbanAnonymizationMode { get; }

        /// <summary>
        /// Defines the mode of owner anonymization.
        /// </summary>
        /// <value>BlinkCardAnonymizationMode</value>
        BlinkCardAnonymizationMode OwnerAnonymizationMode { get; }
    }

    /// <summary>
    /// Use this to create an instance of IBlinkCardAnonymizationSettings.
    /// </summary>
    public interface IBlinkCardAnonymizationSettingsFactory
    {
        /// <summary>
        /// Creates the blink card anonymization settings
        /// </summary>
        /// <returns>Card number anonymization settings.</returns>
        /// <param name="cardNumberAnonymizationSettings">defines the parameters of card number anonymization.</param>
        /// <param name="cardNumberPrefixAnonymizationMode">defines the mode of card number prefix anonymization.</param>
        /// <param name="cvvAnonymizationMode">defines the mode of CVV anonymization.</param>
        /// <param name="ibanAnonymizationMode">defines the mode of owner anonymization.</param>
        /// <param name="ownerAnonymizationMode">defines the mode of owner anonymization.</param>
        IBlinkCardAnonymizationSettings CreateBlinkCardAnonymizationSettings(ICardNumberAnonymizationSettings cardNumberAnonymizationSettings, BlinkCardAnonymizationMode cardNumberPrefixAnonymizationMode = BlinkCardAnonymizationMode.None, BlinkCardAnonymizationMode cvvAnonymizationMode = BlinkCardAnonymizationMode.None, BlinkCardAnonymizationMode ibanAnonymizationMode = BlinkCardAnonymizationMode.None,BlinkCardAnonymizationMode ownerAnonymizationMode = BlinkCardAnonymizationMode.None);
    }

    /// <summary>
    /// Result of the data matching algorithm for scanned parts/sides of the document.
    /// </summary>
    public enum DataMatchResult
    {
        /// <summary>
        /// Data matching has not been performed.
        /// </summary>
        NotPerformed,
        /// <summary>
        /// Data does not match.
        /// </summary>
        Failed,
        /// <summary>
        /// Data match.
        /// </summary>
        Success
    }

    public interface IImageExtensionFactors
    {
        /// <summary>
        /// Gets the image extension factor relative to full image height in UP direction.
        /// </summary>
        /// <value>Up factor.</value>
        float UpFactor { get; }

        /// <summary>
        /// Gets the image extension factor relative to full image height in RIGHT direction..
        /// </summary>
        /// <value>The right factor.</value>
        float RightFactor { get; }

        /// <summary>
        /// Gets image extension factor relative to full image height in DOWN direction.
        /// </summary>
        /// <value>Down factor.</value>
        float DownFactor { get; }

        /// <summary>
        /// Gets the image extension factor relative to full image height in LEFT direction.
        /// </summary>
        /// <value>The left factor.</value>
        float LeftFactor { get; }
    }

    /// <summary>
    /// Image extension factors factory. Use this to create an instance of IImageExtensionFactors.
    /// </summary>
    public interface IImageExtensionFactorsFactory
    {
        /// <summary>
        /// Creates the image extension factors.
        /// </summary>
        /// <returns>The image extension factors.</returns>
        /// <param name="upFactor">image extension factor relative to full image height in UP direction</param>
        /// <param name="downFactor">image extension factor relative to full image height in DOWN direction</param>
        /// <param name="leftFactor">image extension factor relative to full image width in LEFT direction</param>
        /// <param name="rightFactor">image extension factor relative to full image width in RIGHT direction</param>
        IImageExtensionFactors CreateImageExtensionFactors(float upFactor = 0.0f, float downFactor = 0.0f, float leftFactor = 0.0f, float rightFactor = 0.0f);
    }
}