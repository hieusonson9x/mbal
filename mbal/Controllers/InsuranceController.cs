using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mbal.Models;
using Microsoft.EntityFrameworkCore;
using mbal.Common;
using mbal.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mbal.Controllers
{
    [Route("api/[controller]")]
    public class InsuranceController : Controller
    {
        private readonly UserContext _context;
        private readonly InsuranceService insuranceService;
        public InsuranceController(UserContext context)
        {
            this._context = context;
            this.insuranceService = new InsuranceService(context);
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Insurrance> Get()
        {
            var a = _context.insurrances;
            var data = a.Include(i => i.Customer).Include(i=> i.Product).ToList();
            return data;
        }

        [HttpGet("getByCode/{code}")]
        public IActionResult getByCode(string code)
        {

            var insurrance = _context.insurrances.Where(c => c.ContractNumber == code).Include(i => i.Product).Include(i =>i.Employee).Include(c => c.Customer).FirstOrDefault();

            if (insurrance == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = "Số hợp đồng không tồn tại trong hệ thống" });
            }
            return new ObjectResult(insurrance);
        }

        [HttpPost("add")]
        public IActionResult add([FromBody] Insurrance insurrance)
        {
            if (insurrance == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.INVALID_DATA });
            }
            else {
                if(!Validator.ValidateInsurance(insurrance))
                {
                    return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.INVALID_DATA});
                }
                var customer = _context.customers.Where(c => c.CustomerID == insurrance.CustomerID).FirstOrDefault();
                var product = _context.products.Where(p => p.ProductID == insurrance.ProductID).FirstOrDefault();
                var emplyee = _context.employees.Where(e => e.EmployeeID == insurrance.EmployeeID).FirstOrDefault();
                if (product == null || customer == null || emplyee == null)
                {
                    return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.ERROR_INVALID_PRODUCT_OR_CUS });

                }
                else {
                    var a = _context.insurrances.Where(c => c.ContractNumber == insurrance.ContractNumber || c.InsurranceID == insurrance.InsurranceID).FirstOrDefault();
                    if (a == null)
                    {
                        insurrance.InsurranceID = 0;
                        _context.insurrances.Add(insurrance);
                        _context.SaveChanges();

                        return new ObjectResult(new Message { status = StatusMessage.success.ToString(), message = MyMessage.ADD_SUCCESS });
                    }
                    else
                    {
                        return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.ERROR_ADD_INS });
                    }
                }
            }
            
        }

        [HttpPost("update")]
        public IActionResult update([FromBody] Insurrance insurrance)
        {
            if (insurrance == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.INVALID_DATA });
            }
            var customer = _context.customers.Where(c => c.CustomerID == insurrance.CustomerID).FirstOrDefault();
            var product = _context.products.Where(p => p.ProductID == insurrance.ProductID).FirstOrDefault();
            var emplyee = _context.employees.Where(e => e.EmployeeID == insurrance.EmployeeID).FirstOrDefault();
            if (product == null || customer == null || emplyee == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.ERROR_INVALID_PRODUCT_OR_CUS });

            }
            var a = _context.insurrances.Where(c => c.InsurranceID == insurrance.InsurranceID || c.ContractNumber == insurrance.ContractNumber).FirstOrDefault();
            if (a == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.ERROR_NOT_FOUND_INS });
            }
            else
            {
                a.BanhchCode = insurrance.BanhchCode;
                a.CoverageRate = insurrance.CoverageRate;
                a.CustomerID = insurrance.CustomerID;
                a.description = insurrance.description;
                a.DurationOfInsurrance = insurrance.DurationOfInsurrance;
                a.ProductID = insurrance.ProductID;
                a.EmployeeID = insurrance.EmployeeID;
                a.FormOfPayment = insurrance.FormOfPayment;
                a.StatusContract = insurrance.StatusContract;
                a.StatusFee = insurrance.StatusFee;
                a.TimeIn = insurrance.TimeIn;
                a.TimeOut = insurrance.TimeOut;
                _context.Update(a);
                _context.SaveChanges();
                return new ObjectResult(new Message { status = StatusMessage.success.ToString(), message = MyMessage.SUCCESS_UPDATE_INS });
            }
        }

        [HttpDelete("deleteByContactNumber/{contactNumber}", Name = "delIns")]
        public IActionResult delIns(string contactNumber)
        {
            var insurance = _context.insurrances.Where(p => p.ContractNumber == contactNumber).FirstOrDefault();
            if (insurance == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.ERROR_NOT_FOUND_INS });
            }
            else
            {
                _context.Entry(insurance).State = EntityState.Deleted;
                _context.SaveChanges();
                return new ObjectResult(new Message { status = StatusMessage.success.ToString(), message = MyMessage.DELETE_SUCCESS + contactNumber });
            }
        }

        [HttpGet("getByStatusContract/{status}")]
        public IActionResult getByStatusContract(string status)
        {

            var insurrance = _context.insurrances.Where(c => c.StatusContract == status).Include(i => i.Product).Include(i => i.Employee).Include(c => c.Customer).ToList();

            if (insurrance == null)
            {

                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = "không tồn tại hợp đồng thỏa mãn trong hệ thống" });
            }
            return new ObjectResult(insurrance);
        }

        [HttpGet("getByStatusFee/{status}")]
        public IActionResult getByStatusFee(string status)
        {

            var insurrance = _context.insurrances.Where(c => c.StatusFee == status).Include(i => i.Product).Include(i => i.Employee).Include(c => c.Customer).ToList();

            if (insurrance == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = "không tồn tại hợp đồng thỏa mãn trong hệ thống" });
            }
            return new ObjectResult(insurrance);
        }



    }
}
