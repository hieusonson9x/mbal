using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbal.Models;

namespace mbal.Repository
{
    public class EmployeeRepository : BaseRepository<Product>
    {
        //public UserContext context;
        private readonly UserContext _context;

        public EmployeeRepository(UserContext context) : base(context)
        {
            this._context = context;
        }

        public List<Employee> getEmployeeHavenotCustomer()
        {
            var employees = (from e in _context.employees
                             where !(from i in _context.insurrances select i.EmployeeID).Contains(e.EmployeeID) select e).ToList();
            return employees;
        }

        public List<Customer> getCustomerOfEmployee(long idEmployee)
        {
            var customers = (from e in _context.employees
                             join i in _context.insurrances on e.EmployeeID equals i.EmployeeID
                             join c in _context.customers on i.CustomerID equals c.CustomerID
                             where e.EmployeeID == idEmployee
                             select c).ToList();
            return customers;
        }

        public List<Insurrance> getInsurranceOfEmployee(long idEmployee)
        {
            var insurrances = (from e in _context.employees
                               join i in _context.insurrances on e.EmployeeID equals i.EmployeeID
                               where e.EmployeeID == idEmployee
                               select i).ToList();
            return insurrances;
        }
    }
}
