namespace Misio.Paynow.Models
{
    public class PaymentRequest
    {
        public int Amount { get; }
        public string Currency { get; }
        public string ExternalId { get; }
        public string Description { get; }
        public string ContinueUrl { get; }
        public string Buyer { get; }

        public class BuyerModel
        {
            public string Email { get; }
            public string FirstName { get; }
            public string LastName { get; }
            public PhoneModel Phone { get; }

            public class PhoneModel
            {
                public string Prefix { get; }
                public string Number { get; }
            }
        }
    }
}
