using System;
using System.Collections.Generic;
using mbal.Repository;
using System.Linq;
using System.Threading.Tasks;
using mbal.Models;

namespace mbal.Service
{
    public class ProductService
    {

        private readonly ProductRepository _productRepository;
        private  UserContext context;

        public ProductService(UserContext context)
        {
            this.context = context;
            this._productRepository = new ProductRepository(context);
        }

        public List<Product> getProductUse()
        {            
            var results= _productRepository.getProductUse();
            return results;
        }
    }
}
