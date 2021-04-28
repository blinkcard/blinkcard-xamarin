using BlinkCard.Forms.Droid.Recognizers;
using BlinkCard.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(CardNumberAnonymizationSettingsFactory))]
[assembly: Xamarin.Forms.Dependency(typeof(BlinkCardAnonymizationSettingsFactory))]
namespace BlinkCard.Forms.Droid.Recognizers
{

    public sealed class CardNumberAnonymizationSettings : ICardNumberAnonymizationSettings
    {
        public Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.CardNumberAnonymizationSettings NativeSettings { get; }

        public CardNumberAnonymizationSettings(Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.CardNumberAnonymizationSettings nativeSettings)
        {
            NativeSettings = nativeSettings;
        }

        public BlinkCardAnonymizationMode Mode => (BlinkCardAnonymizationMode)NativeSettings.AnonymizationMode.Ordinal();
        public int PrefixDigitsVisible => NativeSettings.PrefixDigitsVisible;
        public int SuffixDigitsVisible => NativeSettings.SuffixDigitsVisible;

    }

    public sealed class CardNumberAnonymizationSettingsFactory : ICardNumberAnonymizationSettingsFactory
    {
        public ICardNumberAnonymizationSettings CreateCardNumberAnonymizationSettings(BlinkCardAnonymizationMode mode = BlinkCardAnonymizationMode.None, int prefixDigitsVisible = 0, int suffixDigitsVisible = 0)
        {
            Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.CardNumberAnonymizationSettings cardNumberAnonymizationSettings = new Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.CardNumberAnonymizationSettings();
            cardNumberAnonymizationSettings.AnonymizationMode = (Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.BlinkCardAnonymizationMode) ((int) mode);
            cardNumberAnonymizationSettings.PrefixDigitsVisible = prefixDigitsVisible;
            cardNumberAnonymizationSettings.SuffixDigitsVisible = suffixDigitsVisible;

            return new CardNumberAnonymizationSettings(cardNumberAnonymizationSettings);
        }
    }

    public sealed class BlinkCardAnonymizationSettings : IBlinkCardAnonymizationSettings
    {
        public Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.BlinkCardAnonymizationSettings NativeSettings { get; }
        public BlinkCardAnonymizationSettings(Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.BlinkCardAnonymizationSettings nativeSettings)
        {
            NativeSettings = nativeSettings;
        }

        public ICardNumberAnonymizationSettings CardNumberAnonymizationSettings => new CardNumberAnonymizationSettings(NativeSettings.CardNumberAnonymizationSettings);
        public BlinkCardAnonymizationMode CardNumberPrefixAnonymizationMode => (BlinkCardAnonymizationMode)NativeSettings.CardNumberPrefixAnonymizationMode.Ordinal();
        public BlinkCardAnonymizationMode CvvAnonymizationMode => (BlinkCardAnonymizationMode)NativeSettings.CvvAnonymizationMode.Ordinal();
        public BlinkCardAnonymizationMode IbanAnonymizationMode => (BlinkCardAnonymizationMode)NativeSettings.IbanAnonymizationMode.Ordinal();
        public BlinkCardAnonymizationMode OwnerAnonymizationMode => (BlinkCardAnonymizationMode)NativeSettings.OwnerAnonymizationMode.Ordinal();
    }

    public sealed class BlinkCardAnonymizationSettingsFactory : IBlinkCardAnonymizationSettingsFactory
    {
        public IBlinkCardAnonymizationSettings CreateBlinkCardAnonymizationSettings(ICardNumberAnonymizationSettings cardNumberAnonymizationSettings, BlinkCardAnonymizationMode cardNumberPrefixAnonymizationMode = BlinkCardAnonymizationMode.None, BlinkCardAnonymizationMode cvvAnonymizationMode = BlinkCardAnonymizationMode.None, BlinkCardAnonymizationMode ibanAnonymizationMode = BlinkCardAnonymizationMode.None,BlinkCardAnonymizationMode ownerAnonymizationMode = BlinkCardAnonymizationMode.None)
        {
            Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.BlinkCardAnonymizationSettings blinkCardAnonymizationSettings = new Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.BlinkCardAnonymizationSettings();
            Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.CardNumberAnonymizationSettings nativeCardNumberAnonymizationSettings = new Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.CardNumberAnonymizationSettings();
            nativeCardNumberAnonymizationSettings.AnonymizationMode = (Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.BlinkCardAnonymizationMode)((int)cardNumberAnonymizationSettings.Mode);
            nativeCardNumberAnonymizationSettings.PrefixDigitsVisible = cardNumberAnonymizationSettings.PrefixDigitsVisible;
            nativeCardNumberAnonymizationSettings.SuffixDigitsVisible = cardNumberAnonymizationSettings.SuffixDigitsVisible;
            blinkCardAnonymizationSettings.CardNumberAnonymizationSettings = nativeCardNumberAnonymizationSettings;
            blinkCardAnonymizationSettings.CardNumberPrefixAnonymizationMode = (Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.BlinkCardAnonymizationMode)(int)cardNumberPrefixAnonymizationMode;
            blinkCardAnonymizationSettings.CvvAnonymizationMode = (Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.BlinkCardAnonymizationMode)(int)cvvAnonymizationMode;
            blinkCardAnonymizationSettings.IbanAnonymizationMode = (Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.BlinkCardAnonymizationMode)(int)ibanAnonymizationMode;
            blinkCardAnonymizationSettings.OwnerAnonymizationMode = (Com.Microblink.Blinkcard.Entities.Recognizers.Blinkcard.BlinkCardAnonymizationMode)(int)ownerAnonymizationMode;
            return new BlinkCardAnonymizationSettings(blinkCardAnonymizationSettings);
        }
    }

}