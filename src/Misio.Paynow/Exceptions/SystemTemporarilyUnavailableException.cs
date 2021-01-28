namespace Misio.Paynow.Exceptions
{
    public class SystemTemporarilyUnavailableException : PaynowBaseException
    {
        public override string Code => "SYSTEM_TEMPORARILY_UNAVAILABLE";

        public SystemTemporarilyUnavailableException() : base("Our Paynow system is temporarily unavailable.")
        {
        }
    }
}