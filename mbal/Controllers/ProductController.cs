using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mbal.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mbal.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly UserContext _context;

        public ProductController(UserContext context)
        {
            _context = context;

            if (_context.users.Count() == 0)
            {
                _context.users.Add(new User { username = "hieunm" });
                _context.SaveChanges();
            }
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _context.products.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("add", Name = "addproduct")]
        public String add()
        {
            _context.products.Add(new Models.Product { ProductName = "product1" });
            _context.SaveChanges();

            return "ok";
        }
    }
}
