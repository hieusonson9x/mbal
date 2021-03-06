﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbal.Models;

namespace mbal.Repository
{
    public class CustomerRepository : BaseRepository<Product>
    {
        //public UserContext context;
        private readonly UserContext _context;

        public CustomerRepository(UserContext context) : base(context)
        {
            this._context = context;
        }

        public List<Insurrance> getInsurranceOfCustomer(long idCustomer)
        {
            var insurrances = (from c in _context.customers
                               join i in _context.insurrances on c.CustomerID equals i.EmployeeID
                               where c.CustomerID == idCustomer
                               select i).ToList();
            return insurrances;
        }

        public float getallMoneyPaymentOfCustomer(string customerCode)
        {
            List<Payment> payments = (from p in _context.payments where p.customerCode == customerCode select p).ToList();
            var sum = 0.0;
            if (payments != null)
            sum = payments.Select(p => p.amountPayment).Sum();
            return (float)sum;
        }

        public float getallMoneyCompensationOfCustomer(string customerCode)
        {
            List<Compensation> compensations = (from c in _context.compensations where c.customerCode== customerCode select c).ToList();
            var sum = 0.0;
            if(compensations !=null)
            sum = compensations.Select(c => c.compensationMoney).Sum();
            return (float)sum;
        }

        public List<Payment>getPaymentOfCustomer(string customerCode)
        {
            var payments = (from p in _context.payments where p.customerCode == customerCode select p).ToList();
            return payments;
        }

        public List<Compensation> getCompensationOfCustomer(string customerCode)
        {
            var compensations = (from c in _context.compensations where c.customerCode == customerCode select c).ToList();
            return compensations;
        }
    }
}
