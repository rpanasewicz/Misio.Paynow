namespace Misio.Paynow.Exceptions
{
    public class VerificationFailedException : PaynowException
    {
        public VerificationFailedException() : base(ErrorCodes.VERIFICATION_FAILED, "Your signature header is incorrect.")
        {
        }
    }
}