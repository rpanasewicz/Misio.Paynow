namespace Misio.Paynow.Exceptions
{
    public class UnauthorizedException : PaynowBaseException
    {
        public override string Code => "UNAUTHORIZED";

        public UnauthorizedException() : base("You are not authorized for this operation.")
        {
        }
    }
}