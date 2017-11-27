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

            //var products = context.products.FromSql("select * from dbo.products").ToList();
            var products = (from p in context.products join i in context.insurrances on p.ProductID equals i.ProductID select p).ToList();
            //var products1 = context.products.Join(context.insurrances,product => product.ProductID,insurrance => insurrance.ProductID,
            //    (product)=>new { Product = product});
            //var cmd = new SqlCommand("SELECT * FROM PRODUCTS", );
            //var p1 = context.Database.SqlQuery<string>;
            //var products1 = context.Database.ExecuteSqlCommand("");
            //context.ExecuteStoreQuery

            return products;
        }
    }
}
