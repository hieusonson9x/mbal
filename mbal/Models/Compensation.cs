using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbal.Models
{
    public class Compensation
    {
        public long CompensationId { get; set; }
        public long AcceptCompensation { get; set; }
        public DateTime CompensationDate { get; set; }
        public float CompensationMoney { get; set; }
        public DateTime DateOfCompensation { get; set; }
        public string Reason { get; set; }
        public string CustomerCode { get; set; }
        public long InsurranceId { get; set; }
    }
}
