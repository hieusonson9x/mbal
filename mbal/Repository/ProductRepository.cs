using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using mbal.Models;
using Microsoft.EntityFrameworkCore;
using mbal.DAO;

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
            
            _context.Database.EnsureCreated();
            var products = (from p in _context.products join i in _context.insurrances on p.ProductID equals i.ProductID select p).ToList();
            return products;
        }

        public List<TopSellProduct> getTopProduct()
        {
            var product = (from i in _context.insurrances group i by i.ProductID into g
                           orderby g.Count() descending
                           select new TopSellProduct {
                               ProductId=g.First().ProductID.ToString(),
                               Quantity = g.Count().ToString()
                           }).Take(3).ToList();
            return product;
        }
    }
}
