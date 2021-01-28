namespace Misio.Paynow.Exceptions
{
    public class NotFoundException : PaynowBaseException
    {
        public override string Code => "NOT_FOUND";

        public NotFoundException() : base("Can not find the requested value.")
        {
        }
    }
}