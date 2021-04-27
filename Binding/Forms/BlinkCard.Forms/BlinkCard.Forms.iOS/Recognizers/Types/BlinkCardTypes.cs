using BlinkCard.Forms.iOS.Recognizers;
using BlinkCard.Forms.Core.Recognizers;
using BlinkCard;

[assembly: Xamarin.Forms.Dependency(typeof(CardNumberAnonymizationSettingsFactory))]
[assembly: Xamarin.Forms.Dependency(typeof(BlinkCardAnonymizationSettingsFactory))]
[assembly: Xamarin.Forms.Dependency(typeof(ImageExtensionFactorsFactory))]
namespace BlinkCard.Forms.iOS.Recognizers
{
	public sealed class CardNumberAnonymizationSettings : ICardNumberAnonymizationSettings
    {
        public MBCCardNumberAnonymizationSettings NativeCardNumberAnonymizationSettings { get; }

        public CardNumberAnonymizationSettings(MBCCardNumberAnonymizationSettings nativeCardNumberAnonymizationSettings)
        {
            NativeCardNumberAnonymizationSettings = nativeCardNumberAnonymizationSettings;
        }

        public BlinkCardAnonymizationMode Mode => (BlinkCardAnonymizationMode)NativeCardNumberAnonymizationSettings.Mode;
        public int PrefixDigitsVisible => (int)NativeCardNumberAnonymizationSettings.PrefixDigitsVisible;
        public int SuffixDigitsVisible => (int)NativeCardNumberAnonymizationSettings.SuffixDigitsVisible;
    }

    public sealed class CardNumberAnonymizationSettingsFactory : ICardNumberAnonymizationSettingsFactory
    {
        public ICardNumberAnonymizationSettings CreateCardNumberAnonymizationSettings(BlinkCardAnonymizationMode mode = BlinkCardAnonymizationMode.None, int prefixDigitsVisible = 0, int suffixDigitsVisible = 0)
        {
            MBCCardNumberAnonymizationSettings cardNumberAnonymizationSettings = new MBCCardNumberAnonymizationSettings();
            cardNumberAnonymizationSettings.Mode = (MBCBlinkCardAnonymizationMode)mode;
            cardNumberAnonymizationSettings.PrefixDigitsVisible = prefixDigitsVisible;
            cardNumberAnonymizationSettings.SuffixDigitsVisible = suffixDigitsVisible;

            return new CardNumberAnonymizationSettings(cardNumberAnonymizationSettings);
        }
    }

    public sealed class BlinkCardAnonymizationSettings : IBlinkCardAnonymizationSettings
    {
        public MBCBlinkCardAnonymizationSettings NativeBlinkCardAnonymizationSettings { get; }

        public BlinkCardAnonymizationSettings(MBCBlinkCardAnonymizationSettings nativeBlinkCardAnonymizationSettings)
        {
            NativeBlinkCardAnonymizationSettings = nativeBlinkCardAnonymizationSettings;
        }

        public ICardNumberAnonymizationSettings CardNumberAnonymizationSettings => new CardNumberAnonymizationSettings(NativeBlinkCardAnonymizationSettings.CardNumberAnonymizationSettings);
        public BlinkCardAnonymizationMode CardNumberPrefixAnonymizationMode => (BlinkCardAnonymizationMode)NativeBlinkCardAnonymizationSettings.CardNumberPrefixAnonymizationMode;
        public BlinkCardAnonymizationMode CvvAnonymizationMode => (BlinkCardAnonymizationMode)NativeBlinkCardAnonymizationSettings.CvvAnonymizationMode;
        public BlinkCardAnonymizationMode IbanAnonymizationMode => (BlinkCardAnonymizationMode)NativeBlinkCardAnonymizationSettings.IbanAnonymizationMode;
        public BlinkCardAnonymizationMode OwnerAnonymizationMode => (BlinkCardAnonymizationMode)NativeBlinkCardAnonymizationSettings.OwnerAnonymizationMode;
    }

    public sealed class BlinkCardAnonymizationSettingsFactory : IBlinkCardAnonymizationSettingsFactory
    {
        public IBlinkCardAnonymizationSettings CreateBlinkCardAnonymizationSettings(ICardNumberAnonymizationSettings cardNumberAnonymizationSettings, BlinkCardAnonymizationMode cardNumberPrefixAnonymizationMode = BlinkCardAnonymizationMode.None, BlinkCardAnonymizationMode cvvAnonymizationMode = BlinkCardAnonymizationMode.None, BlinkCardAnonymizationMode ibanAnonymizationMode = BlinkCardAnonymizationMode.None,BlinkCardAnonymizationMode ownerAnonymizationMode = BlinkCardAnonymizationMode.None)
        {
            MBCBlinkCardAnonymizationSettings blinkCardAnonymizationSettings = new MBCBlinkCardAnonymizationSettings();
            MBCCardNumberAnonymizationSettings nativeCardNumberAnonymizationSettings = new MBCCardNumberAnonymizationSettings();
            nativeCardNumberAnonymizationSettings.Mode = (MBCBlinkCardAnonymizationMode)((int)cardNumberAnonymizationSettings.Mode);
            nativeCardNumberAnonymizationSettings.PrefixDigitsVisible = cardNumberAnonymizationSettings.PrefixDigitsVisible;
            nativeCardNumberAnonymizationSettings.SuffixDigitsVisible = cardNumberAnonymizationSettings.SuffixDigitsVisible;

            blinkCardAnonymizationSettings.CardNumberAnonymizationSettings = nativeCardNumberAnonymizationSettings;
            blinkCardAnonymizationSettings.CardNumberPrefixAnonymizationMode = (MBCBlinkCardAnonymizationMode)cardNumberPrefixAnonymizationMode;
            blinkCardAnonymizationSettings.CvvAnonymizationMode = (MBCBlinkCardAnonymizationMode)cvvAnonymizationMode;
            blinkCardAnonymizationSettings.IbanAnonymizationMode = (MBCBlinkCardAnonymizationMode)ibanAnonymizationMode;
            blinkCardAnonymizationSettings.OwnerAnonymizationMode = (MBCBlinkCardAnonymizationMode)ownerAnonymizationMode;

            return new BlinkCardAnonymizationSettings(blinkCardAnonymizationSettings);
        }
    }

    public sealed class ImageExtensionFactors : IImageExtensionFactors
    {
        public MBCImageExtensionFactors NativeFactors { get; }

        public ImageExtensionFactors(MBCImageExtensionFactors nativeFactors)
        {
            NativeFactors = nativeFactors;
        }

        public float UpFactor => (float)NativeFactors.top;
        public float RightFactor => (float)NativeFactors.right;
        public float DownFactor => (float)NativeFactors.bottom;
        public float LeftFactor => (float)NativeFactors.left;
    }

    public sealed class ImageExtensionFactorsFactory : IImageExtensionFactorsFactory
    {
        public IImageExtensionFactors CreateImageExtensionFactors(float upFactor = 0, float downFactor = 0, float leftFactor = 0, float rightFactor = 0)
        {
            return new ImageExtensionFactors(new MBCImageExtensionFactors { top = upFactor, bottom = downFactor, left = leftFactor, right = rightFactor });
        }
    }
}