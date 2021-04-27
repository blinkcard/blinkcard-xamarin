using System;
using BlinkCard.Forms.Core.Recognizers;

namespace BlinkCard.Forms.Core.Overlays
{
    /// <summary>
    /// BlinkCard overlay settings. This overlay is best suited for scanning payment cards.
    /// </summary>
    public interface IBlinkCardOverlaySettings : IOverlaySettings, IScanSoundOverlaySettings
    {
        /// <summary>
        /// User instructions that are shown above camera preview while the first side of the document is being scanned.
        /// If null, default value will be used.
        /// </summary>
        string FirstSideInstructions { get; set; }
        /// <summary>
        /// User instructions that are shown above camera preview while the second side of the document is being scanned.
        /// If null, default value will be used.
        /// </summary>
        string FlipCardInstructions { get; set; }
        /// <summary>
        /// Defines whether glare  warning will be displayed when user turn on a flashlight
        /// Default true
        /// </summary>
        bool ShowFlashlightWarning { get; set; }
    }

    /// <summary>
    /// BlinkCard overlay settings factory. Use this to create an instance of IBlinkCardOverlaySettings.
    /// </summary>
    public interface IBlinkCardOverlaySettingsFactory
    {
        /// <summary>
        /// Creates the BlinkCard overlay settings using provided recognizer collection.
        /// </summary>
        /// <returns>The document verification overlay settings.</returns>
        /// <param name="recognizerCollection">Recognizer collection that will be used for scanning.</param>
        IBlinkCardOverlaySettings CreateBlinkCardOverlaySettings(IRecognizerCollection recognizerCollection);
    }
}