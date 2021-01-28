using System;
using System.Collections.Generic;
using System.Linq;

namespace Misio.Paynow.Models
{
    public class PaymentStatus : IEquatable<PaymentStatus>
    {
        public static readonly PaymentStatus NEW = new PaymentStatus("NAME");
        public static readonly PaymentStatus PENDING = new PaymentStatus("PENDING");
        public static readonly PaymentStatus CONFIRMED = new PaymentStatus("CONFIRMED");
        public static readonly PaymentStatus REJECTED = new PaymentStatus("REJECTED");
        public static readonly PaymentStatus ERROR = new PaymentStatus("ERROR");

        public string Name { get; }

        private PaymentStatus(string name)
        {
            Name = name;
        }

        public static IEnumerable<PaymentStatus> GetAll()
        {
            yield return NEW;
            yield return PENDING;
            yield return CONFIRMED;
            yield return REJECTED;
            yield return ERROR;
        }

        public static PaymentStatus Parse(string name)
        {
            return GetAll().FirstOrDefault(item => item.Name.ToLower() == name.ToLower());
        }

        public bool Equals(PaymentStatus other) => Name.Equals(other.Name);

        public override bool Equals(object obj) => Name.Equals((obj as PaymentStatus).Name);
        public override int GetHashCode() => Name.GetHashCode();
    }
}
