using clean_arch.common.Domain.Seedwork;
using System.Collections.Generic;

namespace clean_arch.domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string PostalCode { get; private set; }

        public Address()
        {

        }

        public Address(string addressLine1, string addressLine2, string city, string state, string country, string postalCode)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            State = state;
            Country = country;
            PostalCode = postalCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return AddressLine1;
            yield return AddressLine2;
            yield return City;
            yield return State;
            yield return Country;
            yield return PostalCode;
        }
    }

}