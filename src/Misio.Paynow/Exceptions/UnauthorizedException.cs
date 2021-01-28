namespace Misio.Paynow.Exceptions
{
    public class UnauthorizedException : PaynowException
    {
        public UnauthorizedException() : base(ErrorCodes.UNAUTHORIZED, "You are not authorized for this operation.")
        {
        }
    }
}