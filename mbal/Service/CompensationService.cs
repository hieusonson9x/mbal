using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbal.Models;
using mbal.Repository;

namespace mbal.Service
{
    public class CompensationService
    {
        private UserContext context;
        private readonly CompensationRepository _compensationRepository;

        public CompensationService(UserContext context)
        {
            this.context = context;
            this._compensationRepository = new CompensationRepository(context);
        }
    }
}
