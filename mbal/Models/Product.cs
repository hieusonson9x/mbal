using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbal.Models
{
    public class Product
    {
        public long ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int PayMethod { get; set; }
        public string ProductStatus { get; set; }
        public string Money { set; get; }
        public string description { set; get; }

        public List<Insurrance> Insurrances { get; set; }
    }
}
