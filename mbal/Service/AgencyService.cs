using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbal.Models;
using mbal.Repository;

namespace mbal.Service
{

    public class AgencyService
    {
        private UserContext context;
        private readonly AgencyRepository _agencyRepository;

        public AgencyService(UserContext context)
        {
            this.context = context;
            this._agencyRepository = new AgencyRepository(context);
        }

        public List<Insurrance> getInsurranceOfAgency(long idAgency)
        {
            return this._agencyRepository.getInsurranceOfAgency(idAgency);
        }

        public List<Insurrance> getInsurranceOfAgency(String banchCode)
        {
            return this._agencyRepository.getInsurranceOfAgency(banchCode);
        }
    }
}
