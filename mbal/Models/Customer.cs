using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mbal.Models
{
    public class Customer
    {
        public long CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string FullName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public System.DateTime Dob { get; set; }
        public string Cmtnd { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public String Phonenumber { get; set; }

        public List<Insurrance> Insurrances { get; set; }

    }
}
