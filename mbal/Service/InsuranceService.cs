using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbal.Models;
using mbal.Repository;

namespace mbal.Service
{
    public class InsuranceService
    {
        private UserContext context;
        private readonly InsuranceRepository _insuranceRepository;

        public InsuranceService(UserContext context)
        {
            this.context = context;
            this._insuranceRepository = new InsuranceRepository(context);
        }

        public List<Payment> getPaymentOfInsurrance(string insurranceId)
        {
            return _insuranceRepository.getPaymentOfInsurrance(insurranceId);
        }

        public List<Compensation> getCompensationOfInsurrance(string insurranceId)
        {
            return _insuranceRepository.getCompensationOfInsurrance(insurranceId);
        }
    }
}
