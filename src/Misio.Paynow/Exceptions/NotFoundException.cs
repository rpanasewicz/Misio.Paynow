namespace Misio.Paynow.Exceptions
{
    public class NotFoundException : PaynowException
    {
        public NotFoundException() : base(ErrorCodes.NOT_FOUND, "Can not find the requested value.")
        {
        }
    }
}