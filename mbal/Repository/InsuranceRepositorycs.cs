using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbal.Models;

namespace mbal.Repository
{
    public class InsuranceRepository : BaseRepository<Product>
    {
        //public UserContext context;
        private readonly UserContext _context;

        public InsuranceRepository(UserContext context) : base(context)
        {
            this._context = context;
        }

        public List<Payment> getPaymentOfInsurrance(string insurranceId)
        {
            var a = (from p in _context.payments
                     join i in _context.insurrances on p.insurranceId equals i.InsurranceID
                     select p).ToList();
            return a;
        
        }

        public List<Compensation> getCompensationOfInsurrance(string insurranceId)
        {
            var a = (from c in _context.compensations
                     join i in _context.insurrances on c.insurranceId equals i.InsurranceID
                     select c).ToList();
            return a;

        }

    }

}
