using System;
using BlinkCard.Forms.Droid.Recognizers;
using BlinkCard.Forms.Core.Recognizers;

namespace BlinkCard.Forms.Droid.Recognizers
{
    public abstract class Recognizer : IRecognizer
    {
        public Com.Microblink.Blinkcard.Entities.Recognizers.Recognizer NativeRecognizer { get; }
        public abstract IRecognizerResult BaseResult { get; }

        protected Recognizer(Com.Microblink.Blinkcard.Entities.Recognizers.Recognizer nativeRecognizer)
        {
            NativeRecognizer = nativeRecognizer;
        }
    }

    public abstract class RecognizerResult : IRecognizerResult
    {
        public Com.Microblink.Blinkcard.Entities.Recognizers.Recognizer.Result NativeResult { get; }

        protected RecognizerResult(Com.Microblink.Blinkcard.Entities.Recognizers.Recognizer.Result nativeResult)
        {
            NativeResult = nativeResult;
        }

        public RecognizerResultState ResultState => (RecognizerResultState)NativeResult.ResultState.Ordinal();
    }
}