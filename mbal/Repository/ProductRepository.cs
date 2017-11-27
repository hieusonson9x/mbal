using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using mbal.Models;
using Microsoft.EntityFrameworkCore;

namespace mbal.Repository
{
    public class ProductRepository  : BaseRepository<Product>
    {
        //public UserContext context;
        private readonly UserContext _context;

        public ProductRepository(UserContext context) : base(context)
        {
            this._context = context;
        }


        public List<Product> getProductUse()
        {
            
            context.Database.EnsureCreated();
            var products = (from p in context.products join i in context.insurrances on p.ProductID equals i.ProductID select p).ToList();
            return products;
        }
    }
}
