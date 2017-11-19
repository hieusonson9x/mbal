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
    }
}
