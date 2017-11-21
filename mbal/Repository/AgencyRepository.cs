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
            var insurrances = (from a in _context.agencies
                               join i in _context.insurrances on a.BanhchCode equals i.BanhchCode
                               where a.AgencyID == idAgency
                               select i).ToList();
            return insurrances;
        }
    }

}
