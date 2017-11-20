using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbal.Models;
using mbal.Repository;

namespace mbal.Service
{
    public class CustomerService
    {
        private UserContext context;
        private readonly CustomerRepository _customerRepository;

        public CustomerService(UserContext context)
        {
            this.context = context;
            this._customerRepository = new CustomerRepository(context);
        }

        public List<Insurrance> getInsurranceOfCustomer(string idCustomer)
        {
            return _customerRepository.getInsurranceOfCustomer(idCustomer);
        }

        public float getallMoneyPaymentOfCustomer(string customerCode)
        {
            return _customerRepository.getallMoneyPaymentOfCustomer(customerCode);
        }

        public float getallMoneyCompensationOfCustomer(string customerCode)
        {
            return _customerRepository.getallMoneyCompensationOfCustomer(customerCode);
        }

        public List<Payment> getPaymentOfCustomer(string customerCode)
        {
            return _customerRepository.getPaymentOfCustomer(customerCode);
        }

        public List<Compensation> getCompensationOfCustomer(string customerCode)
        {
            return _customerRepository.getCompensationOfCustomer(customerCode);
        }
    }
}
