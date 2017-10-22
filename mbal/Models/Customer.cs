using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbal.Models
{
    public class Customer
    {
        public long CustomerID { get; set; }
        public string FullName { get; set; }
        public System.DateTime Dob { get; set; }
        public string Cmtnd { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public String Phonenumber { get; set; }

        public List<Insurrance> Insurrances { get; set; }

    }
}
