using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbal.Models
{
    public class Insurrance
    {
        public long InsurranceID { get; set; }
        //mã chi nhánh tạo hợp đồng
        public string BanhchCode {get; set;}
        //Số hợp đồng
        public string ContractNumber { get; set; }
        // tỷ phí % phí bảo hiểm
        public string CoverageRate { get; set; }

        public string StatusFee { get; set; }
        public string StatusContract { get; set; }
        public int FormOfPayment { get; set; }
        public int DurationOfInsurrance { get; set; }

        public string Create_by { get; set; }
        public DateTime Create_at { get; set; }

        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
