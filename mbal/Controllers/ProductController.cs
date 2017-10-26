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
        public IActionResult GetById(int id)
        {
            var product = _context.products.Where(p => p.ProductID == id).Include(p =>p.Insurrances).FirstOrDefault();
            if(product == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = " ID sản phẩm không tồn tại" });
            }
            return new ObjectResult(product);
        }

        

        // DELETE api/values/5
        [HttpDelete("deleteById/{id}", Name ="deteleproduct")]
        public IActionResult DeleteProductById(long id)
        {
            var product = _context.products.Where(p => p.ProductID == id).FirstOrDefault();
            if(product == null)
            {
                return new ObjectResult(new Message { status="error",message = "ID không tồn tại" });
            }
            else
            {
                _context.Entry(product).State = EntityState.Deleted;
                _context.SaveChanges();
                return new ObjectResult(new Message { status = "error", message = "Xóa thành công sản phẩm với ID " + id });

            }
        }
        [HttpDelete("deleteByCode/{code}", Name = "deteleproductCode")]
        public IActionResult DeleteProductByCode(string code)
        {
            var product = _context.products.Where(p => p.ProductCode == code).FirstOrDefault();
            if (product == null)
            {
                return new ObjectResult(new Message { status = "error", message = "Mã sản phẩm không tồn tại" });
            }
            else
            {
                _context.Entry(product).State = EntityState.Deleted;
                _context.SaveChanges();
                return new ObjectResult(new Message { status = "error", message = "Xóa thành công sản phẩm với mã sản phẩm:  " + code });
            }
        }



        [HttpPost("add", Name = "addproduct")]
        public IActionResult add([FromBody] Product product)
        {
            if (product == null)
            {
                return new ObjectResult( new Message { status = "error", message = "Dữ liệu không hợp lệ" });
            }
             var a = _context.products.Where(p => p.ProductID == product.ProductID || p.ProductCode.Equals(product.ProductCode)).FirstOrDefault();
            if (a == null)
            {
                product.ProductID = 0;
                _context.products.Add(product);
                _context.SaveChanges();

                return new ObjectResult(new Message { status = "success", message = "Thêm thành công" });
            }
            else
            {
                return new ObjectResult(new Message { status = "error", message = "Thêm thất bại, mã sản phẩm đã tồn tại" });
            }
        }

        [HttpPost("update", Name = "updateproduct")]
        public IActionResult update([FromBody] Product product)
        {
            if (product == null)
            {
                return new ObjectResult(new Message { status = "error", message = "Dữ liệu không hợp lệ" });
            }
            var a = _context.products.Where(p => p.ProductCode.Equals(product.ProductCode)).FirstOrDefault();
            if (a == null)
            {
                return new ObjectResult(new Message { status = "error", message = "Không tồn tại sản phẩm" });
            }
            else
            {
                a.Money = product.Money;
                a.ProductName = product.ProductName;
                a.PayMethod = product.PayMethod;
                a.ProductStatus = product.ProductStatus;
                _context.Update(a);
                _context.SaveChanges();
                return new ObjectResult(new Message { status = StatusMessage.success.ToString(), message = "Cập nhật sản phẩm thành công" });
            }
        }
    }
   
}
