using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbal.Models;

namespace mbal.Common
{
    public class Validator
    {
        public static bool ValidateInsurance(Insurrance insurrance)
        {
            if (insurrance.ContractNumber == null || insurrance.ContractNumber == ""|| insurrance.TimeIn == null || insurrance.TimeOut == null)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateAgency(Agency agency)
        {
            if (agency == null) return false;
            else if (agency.BanhchCode == null || agency.BanhchCode == "")
            { return false; }
            else { return true; }
        }
        public static bool ValidateCustomer(Customer customer)
        {
            return true;
        }
        public static bool ValidateEmployee(Employee employee)
        {
            return true;
        }
        public static bool ValidateProduct(Product product)
        {
            return true;
        }
        public static bool ValidateUser(User user)
        {
            return true;
        }
    }
}
