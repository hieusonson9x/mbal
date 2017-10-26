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
    public class AgencyController : Controller
    {
        private readonly UserContext _context;
        public AgencyController(UserContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IEnumerable<Agency> getAll()
        {
            return _context.agencies.ToList();
        }
        [HttpGet("getByBanhchCode/{code}")]
        public ActionResult getByBanCode(String code)
        {
            var a = _context.agencies.Where(ag => ag.BanhchCode == code).FirstOrDefault();
            if (a == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.ERROR_NOT_FOUND_AG });
            }
            else return new ObjectResult(a);
        }

        [HttpPost("add")]
        public IActionResult add([FromBody] Agency agency)
        {
            if (!Validator.ValidateAgency(agency))
            {
                return new ObjectResult( new Message { status = StatusMessage.error.ToString(), message = MyMessage.INVALID_DATA });
            }
            else
            {
                var a = _context.agencies.Where(ag => ag.BanhchCode == agency.BanhchCode).FirstOrDefault();
                if(a == null)
                {
                    agency.AgencyID = 0;
                    _context.agencies.Add(agency);
                    _context.SaveChanges();
                    return new ObjectResult(new Message { status = StatusMessage.success.ToString(), message = MyMessage.ADD_SUCCESS });
                }
                else
                {
                    return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message =  MyMessage.ERROR_ADD_AG});
                }
            }
        }

        [HttpDelete("deleteByBanCode/{code}")]
        public IActionResult DeleteAgencyByBanCode(string code)
        {
            var agency = _context.agencies.Where(p => p.BanhchCode == code).FirstOrDefault();
            if (agency == null)
            {
                return new ObjectResult(new Message { status =StatusMessage.error.ToString(), message = MyMessage.ERROR_NOT_FOUND_AG });
            }
            else
            {
                _context.Entry(agency).State = EntityState.Deleted;
                _context.SaveChanges();
                return new ObjectResult(new Message { status = StatusMessage.success.ToString(), message = MyMessage.DEL_SUCCESS_AG + code });
            }
        }

        [HttpPost("update")]
        public IActionResult update([FromBody] Agency agency)
        {
            if (!Validator.ValidateAgency(agency))
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.INVALID_DATA });
            }
            var a = _context.agencies.Where(c => c.BanhchCode == agency.BanhchCode || c.AgencyID == agency.AgencyID).FirstOrDefault();
            if (a == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = MyMessage.ERROR_NOT_FOUND_AG });
            }
            else
            {
                a.Address = agency.Address;
                a.ConsultantName = agency.ConsultantName;
                a.Name = agency.Name;
                a.Phonenumber = agency.Phonenumber;
                _context.Update(a);
                _context.SaveChanges();
                return new ObjectResult(new Message { status = StatusMessage.success.ToString(), message = MyMessage.UPDATE_SUCCESS_AG });
            }
        }
    }
}
