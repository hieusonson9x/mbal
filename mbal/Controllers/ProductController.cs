using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mbal.Models;
using mbal.Common;
using Microsoft.EntityFrameworkCore;

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
            var a = _context.products;
            var data =  a.Include(p => p.Insurrances).ToList();
            return data;
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

        [HttpPost("add", Name = "addproduct")]
        public IActionResult add([FromBody] Product product)
        {
            if (product == null)
            {
                return new ObjectResult( new Message { status = "success", message = "Dữ liệu không hợp lệ" });
            }
             var a = _context.products.Where(p => p.ProductName == "product1").ToList();
            _context.products.Add(product);
            _context.SaveChanges();

            return new ObjectResult(new Message { status = "success", message = "Thêm thành công" });
        }
    }
   
}
