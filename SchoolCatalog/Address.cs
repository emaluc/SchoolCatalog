using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCatalog
{
    internal class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

        public Address(string city, string street, string number)
        {
            City = city;
            Street = street;
            Number = number;
        }
    }
}
