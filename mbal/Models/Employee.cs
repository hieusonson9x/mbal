using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbal.Models
{
     /**
      * Class tượng trưng cho người khởi tạo hợp đồng, nhân viên khởi tạo hợp đồng
      * */
    public class Employee
    {
        public long EmployeeID { get; set; }
        public String EmployeeNumber { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Dob { get; set; }

        public List<Insurrance> Insurrances { get; set; }

    }
}
