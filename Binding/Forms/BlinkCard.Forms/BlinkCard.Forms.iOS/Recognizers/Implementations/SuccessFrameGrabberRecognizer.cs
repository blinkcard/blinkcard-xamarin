using BlinkCard.Forms.Core.Recognizers;
using BlinkCard.Forms.iOS.Recognizers;
using Xamarin.Forms;

[assembly: Dependency(typeof(SuccessFrameGrabberRecognizerFactory))]
namespace BlinkCard.Forms.iOS.Recognizers
{
    public sealed class SuccessFrameGrabberRecognizer : Recognizer, ISuccessFrameGrabberRecognizer
    {
        MBCSuccessFrameGrabberRecognizer nativeRecognizer;
        Recognizer slaveRecognizer;
        readonly SuccessFrameGrabberRecognizerResult result;

        public SuccessFrameGrabberRecognizer(Recognizer slaveRecognizer)
            : base(new MBCSuccessFrameGrabberRecognizer(slaveRecognizer.NativeRecognizer))
        {
            nativeRecognizer = NativeRecognizer as MBCSuccessFrameGrabberRecognizer;
            this.slaveRecognizer = slaveRecognizer;
            result = new SuccessFrameGrabberRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IRecognizer SlaveRecognizer => slaveRecognizer;

        public ISuccessFrameGrabberRecognizerResult Result => result;
    }

    public sealed class SuccessFrameGrabberRecognizerResult : RecognizerResult, ISuccessFrameGrabberRecognizerResult
    {
        readonly MBCSuccessFrameGrabberRecognizerResult nativeResult;

        internal SuccessFrameGrabberRecognizerResult(MBCSuccessFrameGrabberRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }

        public ImageSource SuccessFrame => Utils.ConvertUIImage(nativeResult.SuccessFrame.Image);
    }

    public sealed class SuccessFrameGrabberRecognizerFactory : ISuccessFrameGrabberRecognizerFactory
    {
        public ISuccessFrameGrabberRecognizer CreateSuccessFrameGrabberRecognizer(IRecognizer slaveRecognizer)
        {
            return new SuccessFrameGrabberRecognizer(slaveRecognizer as Recognizer);
        }
    }
}