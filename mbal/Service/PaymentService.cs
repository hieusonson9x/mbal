using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbal.Models;
using mbal.Repository;

namespace mbal.Service
{
    public class PaymentService
    {
        private UserContext context;
        private readonly PaymentRepository _paymentRepository;

        public PaymentService(UserContext context)
        {
            this.context = context;
            this._paymentRepository = new PaymentRepository(context);
        }
    }
}
