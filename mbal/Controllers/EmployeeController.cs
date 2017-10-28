using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mbal.Models;
using Microsoft.EntityFrameworkCore;
using mbal.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mbal.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly UserContext _context;
        public EmployeeController(UserContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Employee> getAll()
        {
            return _context.employees.ToList();
        }
        [HttpGet("getByENumber/{enumber}")]
        public IActionResult getByCode(string enumber)
        {

            var employee = _context.employees.Where(c => c.EmployeeNumber == enumber).Include(c => c.Insurrances).FirstOrDefault();

            if (employee == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.ERROR_NOT_FOUND_EP });
            }
            return new ObjectResult(employee);
        }
        [HttpPost("add")]
        public IActionResult add([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.INVALID_DATA });
            }
            var a = _context.employees.Where(c => c.EmployeeID == employee.EmployeeID || c.EmployeeNumber == employee.EmployeeNumber).FirstOrDefault();
            if (a == null)
            {
                employee.EmployeeID = 0;
                _context.employees.Add(employee);
                _context.SaveChanges();

                return new ObjectResult(new Message { status = StatusMessage.success.ToString(), message = MyMessage.ADD_SUCCESS });
            }
            else
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.ERROR_ADD_EP });
            }
        }
        [HttpDelete("deleteByENumber/{enumber}")]
        public IActionResult delByEnumber(string enumber)
        {
            var employee  = _context.employees.Where(p => p.EmployeeNumber == enumber).FirstOrDefault();
            if (employee == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.ERROR_NOT_FOUND_EP });
            }
            else
            {
                _context.Entry(employee).State = EntityState.Deleted;
                _context.SaveChanges();
                return new ObjectResult(new Message { status = StatusMessage.success.ToString(), message = MyMessage.DEL_SUCCESS_EP + enumber });
            }
        }

        [HttpPost("update")]
        public IActionResult update([FromBody] Employee employee)
        {
            if (!Validator.ValidateEmployee(employee))
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.INVALID_DATA });
            }
            var a = _context.employees.Where(c => c.EmployeeID == employee.EmployeeID || c.EmployeeNumber == employee.EmployeeNumber).FirstOrDefault();
            if (a == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.ERROR_NOT_FOUND_EP });
            }
            else
            {
                a.Address = employee.Address;
                a.Dob = employee.Dob;
                a.Email = employee.Email;
                a.Fullname = employee.Fullname;
                a.PhoneNumber = employee.PhoneNumber;
                _context.Update(a);
                _context.SaveChanges();
                return new ObjectResult(new Message { status = StatusMessage.success.ToString(), message = MyMessage.UPDATE_SUCCES_EP });
            }
        }
    }
}
