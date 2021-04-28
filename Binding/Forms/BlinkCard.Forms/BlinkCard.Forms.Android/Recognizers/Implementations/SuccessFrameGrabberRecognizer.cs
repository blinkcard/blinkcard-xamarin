using BlinkCard.Forms.Core.Recognizers;
using BlinkCard.Forms.Droid.Recognizers;
using Xamarin.Forms;

[assembly: Dependency(typeof(SuccessFrameGrabberRecognizerFactory))]
namespace BlinkCard.Forms.Droid.Recognizers
{
    public sealed class SuccessFrameGrabberRecognizer : Recognizer, ISuccessFrameGrabberRecognizer
    {
        Com.Microblink.Blinkcard.Entities.Recognizers.Successframe.SuccessFrameGrabberRecognizer nativeRecognizer;
        Recognizer slaveRecognizer;
        SuccessFrameGrabberRecognizerResult result;

        public SuccessFrameGrabberRecognizer(Recognizer slaveRecognizer)
            : base(new Com.Microblink.Blinkcard.Entities.Recognizers.Successframe.SuccessFrameGrabberRecognizer(slaveRecognizer.NativeRecognizer))
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Blinkcard.Entities.Recognizers.Successframe.SuccessFrameGrabberRecognizer;
            this.slaveRecognizer = slaveRecognizer;
            result = new SuccessFrameGrabberRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Blinkcard.Entities.Recognizers.Successframe.SuccessFrameGrabberRecognizer.Result);
        }

        public IRecognizer SlaveRecognizer => slaveRecognizer;

        public ISuccessFrameGrabberRecognizerResult Result => result;

        public override IRecognizerResult BaseResult => result;
    }

    public sealed class SuccessFrameGrabberRecognizerResult : RecognizerResult, ISuccessFrameGrabberRecognizerResult
    {
        Com.Microblink.Blinkcard.Entities.Recognizers.Successframe.SuccessFrameGrabberRecognizer.Result nativeResult;

        internal SuccessFrameGrabberRecognizerResult(Com.Microblink.Blinkcard.Entities.Recognizers.Successframe.SuccessFrameGrabberRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }

        public ImageSource SuccessFrame => Utils.ConvertAndroidBitmap(nativeResult.SuccessFrame.ConvertToBitmap());
    }

    public sealed class SuccessFrameGrabberRecognizerFactory : ISuccessFrameGrabberRecognizerFactory
    {
        public ISuccessFrameGrabberRecognizer CreateSuccessFrameGrabberRecognizer(IRecognizer slaveRecognizer)
        {
            return new SuccessFrameGrabberRecognizer(slaveRecognizer as Recognizer);
        }
    }

}