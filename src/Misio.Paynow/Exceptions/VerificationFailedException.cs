namespace Misio.Paynow.Exceptions
{
    public class VerificationFailedException : PaynowBaseException
    {
        public override string Code => "VERIFICATION_FAILED";

        public VerificationFailedException() : base("Your signature header is incorrect.")
        {
        }
    }

    public class UnknowErrorException : PaynowBaseException
    {
        public override string Code => "Unknow error.";

        public UnknowErrorException() : base("Unknow error.")
        {
        }
    }
}