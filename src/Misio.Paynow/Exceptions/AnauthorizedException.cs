namespace Misio.Paynow.Exceptions
{
    public class AnauthorizedException : PaynowBaseException
    {
        public override string Code => "UNAUTHORIZED";

        public AnauthorizedException() : base("You are not authorized for this operation.")
        {
        }
    }
}