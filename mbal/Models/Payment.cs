using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbal.Models
{
    public class Payment
    {
        public long PaymentId { get; set; }
        public float AmountPayment { get; set; }
        public string CustomerCode { get; set; }
        public long InsurranceId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
