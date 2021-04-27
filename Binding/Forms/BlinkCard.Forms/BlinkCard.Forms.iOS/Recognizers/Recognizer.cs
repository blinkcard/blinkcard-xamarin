using BlinkCard.Forms.iOS.Recognizers;
using BlinkCard.Forms.Core.Recognizers;
using BlinkCard;

namespace BlinkCard.Forms.iOS.Recognizers
{
    public abstract class Recognizer : IRecognizer
    {
        public MBCRecognizer NativeRecognizer { get; }
        public abstract IRecognizerResult BaseResult { get; }

        protected Recognizer(MBCRecognizer nativeRecognizer)
        {
            NativeRecognizer = nativeRecognizer;
        }
    }

    public abstract class RecognizerResult : IRecognizerResult
    {
        public MBCRecognizerResult NativeResult { get; }

        protected RecognizerResult(MBCRecognizerResult nativeResult)
        {
            NativeResult = nativeResult;
        }

        public RecognizerResultState ResultState => (RecognizerResultState)NativeResult.ResultState;
    }
}