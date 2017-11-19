using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbal.Models;
using mbal.Repository;

namespace mbal.Service
{
    public class EmployeeService
    {
        private UserContext context;
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(UserContext context)
        {
            this.context = context;
            this._employeeRepository = new EmployeeRepository(context);
        }

        public List<Employee> getEmployeeHavenotCustomer()
        {
            return _employeeRepository.getEmployeeHavenotCustomer();
        }

        public List<Customer> getCustomerOfEmployee(string idEmployee)
        {
            return _employeeRepository.getCustomerOfEmployee(idEmployee);
        }

        public List<Insurrance> getInsurranceOfEmployee(String idEmployee)
        {
            return _employeeRepository.getInsurranceOfEmployee(idEmployee);
        }
    }
}
