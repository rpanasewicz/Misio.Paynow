namespace Misio.Paynow.Models
{
    public class PaymentRequest
    {
        public int Amount { get; }
        public string Currency { get; }
        public string ExternalId { get; }
        public string Description { get; }
        public string ContinueUrl { get; }
        public BuyerModel Buyer { get; }

        public PaymentRequest(int amount, string currency, string externalId, string description, string continueUrl, BuyerModel buyer)
        {
            Amount = amount;
            Currency = currency;
            ExternalId = externalId;
            Description = description;
            ContinueUrl = continueUrl;
            Buyer = buyer;
        }

        public class BuyerModel
        {
            public string Email { get; }
            public string FirstName { get; }
            public string LastName { get; }
            public PhoneModel Phone { get; }

            public BuyerModel(string email, string firstName, string lastName, PhoneModel phone)
            {
                Email = email;
                FirstName = firstName;
                LastName = lastName;
                Phone = phone;
            }

            public class PhoneModel
            {
                public string Prefix { get; }
                public string Number { get; }

                public PhoneModel(string prefix, string number)
                {
                    Prefix = prefix;
                    Number = number;
                }
            }
        }
    }
}
