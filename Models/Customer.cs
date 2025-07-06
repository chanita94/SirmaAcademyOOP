using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Models
{

    public class Customer
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }

        public Customer(string name, string id, DateTime start, DateTime expectedReturn)
        {
            Name = name;
            ID = id;
            RentalStartDate = start;
            ExpectedReturnDate = expectedReturn;
        }

        public override string ToString()
        {
            return $"{Name} (ID: {ID}) - From {RentalStartDate.ToShortDateString()} to {ExpectedReturnDate.ToShortDateString()}";
        }
    }
}


