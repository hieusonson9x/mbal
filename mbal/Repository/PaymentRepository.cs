﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbal.Models;

namespace mbal.Repository
{
    public class PaymentRepository : BaseRepository<Payment>
    {
        private readonly UserContext _context;
        public PaymentRepository(UserContext context) : base(context)
        {
            this._context = context;
        }
    }
}
