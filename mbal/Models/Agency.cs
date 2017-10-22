using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbal.Models
{
    public class Agency
    {
        public long AgencyID { get; set; }
        public string Name { get; set; }
        public string Phonenumber { get; set; }
        public string ConsultantName { get; set; }
        public string Address { get; set; }
    }
}
