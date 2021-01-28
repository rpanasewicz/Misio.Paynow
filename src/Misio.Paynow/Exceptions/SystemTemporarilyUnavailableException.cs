namespace Misio.Paynow.Exceptions
{
    public class SystemTemporarilyUnavailableException : PaynowException
    {
        public SystemTemporarilyUnavailableException() : base(ErrorCodes.SYSTEM_TEMPORARILY_UNAVAILABLE, "Our Paynow system is temporarily unavailable.")
        {
        }
    }
}