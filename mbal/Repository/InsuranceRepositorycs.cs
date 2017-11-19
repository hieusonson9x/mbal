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
    }

}
