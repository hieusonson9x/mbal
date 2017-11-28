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

        public List<Payment> getPaymentOfInsurrance(long insurranceId)
        {
            var a = (from p in _context.payments
                     join i in _context.insurrances on p.InsurranceId equals i.InsurranceID
                     where i.InsurranceID == insurranceId
                     select p).ToList();
            return a;
        
        }

        public List<Compensation> getCompensationOfInsurrance(long insurranceId)
        {
            var a = (from c in _context.compensations
                     join i in _context.insurrances on c.InsurranceId equals i.InsurranceID
                     where i.InsurranceID == insurranceId
                     select c).ToList();
            return a;

        }

        public List<Insurrance> getInsuranceinTime(DateTime time1, DateTime time2)
        {
            var insurances = (from i in _context.insurrances where i.Create_at >= time1 && i.Create_at <= time2 select i).ToList();
            return insurances;
        }

    }

}
