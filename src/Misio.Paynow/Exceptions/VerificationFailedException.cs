namespace Misio.Paynow.Exceptions
{
    public class VerificationFailedException : PaynowBaseException
    {
        public override string Code => "VERIFICATION_FAILED";

        public VerificationFailedException() : base("Your signature header is incorrect.")
        {
        }
    }
}