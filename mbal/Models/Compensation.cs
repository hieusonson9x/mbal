using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbal.Models
{
    public class Compensation
    {
        public long compensationId { get; set; }
        public Boolean acceptCompensation { get; set; }
        public DateTime compensationDate { get; set; }
        public float compensationMoney { get; set; }
        public DateTime DateOfCompensation { get; set; }
        public string reason { get; set; }
        public string customerCode { get; set; }
        public long insurranceId { get; set; }
    }
}
