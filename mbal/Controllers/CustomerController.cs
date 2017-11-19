using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mbal.Models;
using System.Collections;
using mbal.Common;
using Microsoft.EntityFrameworkCore;
using mbal.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mbal.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly UserContext _context;
        private readonly CustomerService customerService;

        public CustomerController(UserContext context)
        {
            this._context = context;
            this.customerService = new CustomerService(context);
        }

        [HttpGet("getAll")]
        public IEnumerable<Customer> GetAll()
        {
            return _context.customers.ToList();
        }
        [HttpGet("getByCode/{code}")]
        public IActionResult getByCode(string code)
        {
    
            var customer = _context.customers.Where(c => c.CustomerCode==code).Include(c=>c.Insurrances).FirstOrDefault();
          
            if (customer == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message="Mã khách hàng không tồn tại trong hệ thống"});
            }
            return new ObjectResult(customer);
        }

        [HttpPost("add")]
        public IActionResult add([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return new ObjectResult(new Message { status = "error", message = "Dữ liệu không hợp lệ" });
            }
            var a = _context.customers.Where(c => c.CustomerID == customer.CustomerID || c.CustomerCode == customer.CustomerCode).FirstOrDefault();
            if (a == null)
            {
                customer.CustomerID = 0;
                _context.customers.Add(customer);
                _context.SaveChanges();

                return new ObjectResult(new Message { status = "success", message = "Thêm thành công" });
            }
            else
            {
                return new ObjectResult(new Message { status = "error", message = MyMessage.ERROR_ADD_CUSTOMER });
            }
        }

        [HttpPost("update")]
        public IActionResult update([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.INVALID_DATA });
            }
            var a = _context.customers.Where(c => c.CustomerID == customer.CustomerID || c.CustomerCode == customer.CustomerCode).FirstOrDefault();
            if (a == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.ERROR_NOT_FOUND_CUSTOMER });
            }
            else
            {
                a.FullName = customer.FullName;
                a.Dob = customer.Dob;
                a.Cmtnd = customer.Cmtnd;
                a.Sex = customer.Sex;
                a.Address = customer.Address;
                a.Phonenumber = customer.Phonenumber;
                _context.Update(a);
                _context.SaveChanges();
                return new ObjectResult(new Message { status = StatusMessage.success.ToString(), message = MyMessage.SUCCESS_UPDATE_CUSTOMER });
            }
        }

        [HttpDelete("deleteByCode/{code}", Name = "deteleCustomerCode")]
        public IActionResult deleteCustomer(string code)
        {
            var customer = _context.customers.Where(p => p.CustomerCode == code).FirstOrDefault();
            if (customer == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.ERROR_NOT_FOUND_CUSTOMER });
            }
            else
            {
                _context.Entry(customer).State = EntityState.Deleted;
                _context.SaveChanges();
                return new ObjectResult(new Message { status = StatusMessage.success.ToString(), message = MyMessage.DELETE_SUCCESS + code });
            }
        }

    }
}
