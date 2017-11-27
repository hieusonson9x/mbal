using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbal.Models
{
    public class Payment
    {
        public long paymentId { get; set; }
        public float amountPayment { get; set; }
        public string customerCode { get; set; }
        public long insurranceId { get; set; }
        public DateTime createAt { get; set; }
    }
}
