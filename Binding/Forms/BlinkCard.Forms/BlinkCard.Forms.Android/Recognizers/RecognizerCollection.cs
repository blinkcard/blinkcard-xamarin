using BlinkCard.Forms.Droid.Recognizers;
using BlinkCard.Forms.Core.Recognizers;
using Com.Microblink.Blinkcard.Entities.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(RecognizerCollectionFactory))]
namespace BlinkCard.Forms.Droid.Recognizers
{
    public class RecognizerCollection : IRecognizerCollection
    {
        public RecognizerBundle NativeRecognizerBundle { get; }

        IRecognizer[] recognizers;

        public RecognizerCollection(IRecognizer[] recognizers)
        {
            this.recognizers = recognizers;
            Com.Microblink.Blinkcard.Entities.Recognizers.Recognizer[] nativeRecognizers = new Com.Microblink.Blinkcard.Entities.Recognizers.Recognizer[recognizers.Length];
            for (int i = 0; i < recognizers.Length; ++i)
            {
                nativeRecognizers[i] = ((Recognizer)recognizers[i]).NativeRecognizer;
            }
            NativeRecognizerBundle = new RecognizerBundle(nativeRecognizers);
        }

        public bool AllowMultipleResults
        {
            get => NativeRecognizerBundle.ShouldAllowMultipleScanResultsOnSingleImage();
            set => NativeRecognizerBundle.SetAllowMultipleScanResultsOnSingleImage(value);
        }

        public uint MilisecondsBeforeTimeout 
        {
            get => (uint) NativeRecognizerBundle.NumMsBeforeTimeout;
            set => NativeRecognizerBundle.NumMsBeforeTimeout = (int) value;
        }

        public IRecognizer[] Recognizers => recognizers;
    }

    public class RecognizerCollectionFactory : IRecognizerCollectionFactory
    {
        public IRecognizerCollection CreateRecognizerCollection(params IRecognizer[] recognizers)
        {
            return new RecognizerCollection(recognizers);
        }
    }
}