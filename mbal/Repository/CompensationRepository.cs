using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbal.Models;

namespace mbal.Repository
{
    public class CompensationRepository : BaseRepository<Compensation>
    {
        private readonly UserContext _context;

        public CompensationRepository(UserContext context) : base(context)
        {
            this._context = context;
        }
    }
}
