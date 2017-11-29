using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbal.Models;

namespace mbal.Repository
{
    public class AgencyRepository : BaseRepository<Product>
    {
        //public UserContext context;
        private readonly UserContext _context;

        public AgencyRepository(UserContext context) : base(context)
        {
            this._context = context;
        }

        public List<Insurrance> getInsurranceOfAgency(long idAgency)
        {
            var insurrances = (from i in _context.insurrances
                                   join a in _context.agencies on i.BanhchCode equals a.BanhchCode
                                   where a.AgencyID == idAgency
                               select i).ToList();
            return insurrances;
        }

        public List<Insurrance> getInsurranceOfAgency(String BanchCode)
        {
            var insurrances = (from i in _context.insurrances
                               where i.BanhchCode == BanchCode
                               select i).ToList();
            return insurrances;
        }
    }

}
