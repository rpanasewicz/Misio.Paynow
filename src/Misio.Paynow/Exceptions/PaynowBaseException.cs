using System;

namespace Misio.Paynow.Exceptions
{
    public abstract class PaynowBaseException : Exception
    {
        public abstract string Code { get; }

        public PaynowBaseException(string message) : base(message)
        {
        }
    }
}