using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mbal.Models;
using Microsoft.EntityFrameworkCore;
using mbal.Common;
using mbal.Service;

namespace mbal.Controllers
{
    [Route("api/[controller]")]
    public class CompensationController: Controller
    {
        private readonly UserContext _context;
        private readonly CompensationService compensationService;
        public CompensationController(UserContext context)
        {
            this._context = context;
            this.compensationService = new CompensationService(context);
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Compensation> Get()
        {
            var data = _context.compensations.ToList();
            return data;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var compensation = _context.compensations.Where(p => p.compensationId == id).FirstOrDefault();
            if (compensation == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = " ID  không tồn tại" });
            }
            return new ObjectResult(compensation);
        }

        [HttpDelete("deleteById/{id}", Name = "deteleCompensation")]
        public IActionResult DeleteById(long id)
        {
            var compensation = _context.compensations.Where(p => p.compensationId == id).FirstOrDefault();
            if (compensation == null)
            {
                return new ObjectResult(new Message { status = "error", message = "ID không tồn tại" });
            }
            else
            {
                _context.Entry(compensation).State = EntityState.Deleted;
                _context.SaveChanges();
                return new ObjectResult(new Message { status = "error", message = "Xóa thành công Compensation  với ID " + id });

            }
        }

        [HttpPost("add", Name = "addCompensation")]
        public IActionResult add([FromBody] Compensation compensation)
        {
            if (compensation == null)
            {
                return new ObjectResult(new Message { status = "error", message = "Dữ liệu không hợp lệ" });
            }
            var a = _context.compensations.Where(p => p.compensationId == compensation.compensationId).FirstOrDefault();
            if (a == null)
            {
                compensation.compensationId = 0;
                _context.compensations.Add(compensation);
                _context.SaveChanges();

                return new ObjectResult(new Message { status = "success", message = "Thêm thành công" });
            }
            else
            {
                return new ObjectResult(new Message { status = "error", message = "Thêm thất bại" });
            }
        }

        [HttpPost("update", Name = "updateCompensation")]
        public IActionResult update([FromBody] Compensation compensation)
        {
            if (compensation == null)
            {
                return new ObjectResult(new Message { status = "error", message = "Dữ liệu không hợp lệ" });
            }
            var a = _context.compensations.Where(p => p.compensationId.Equals(compensation.compensationId)).FirstOrDefault();
            if (a == null)
            {
                return new ObjectResult(new Message { status = "error", message = "Không tồn tại" });
            }
            else
            {
                a.compensationId = compensation.compensationId;
                a.compensationMoney = compensation.compensationMoney;
                a.customerCode = compensation.customerCode;
                a.insurranceId = compensation.insurranceId;
                a.reason = compensation.reason;
                _context.Update(a);
                _context.SaveChanges();
                return new ObjectResult(new Message { status = StatusMessage.success.ToString(), message = "Cập nhật  thành công" });
            }
        }
    }
}
