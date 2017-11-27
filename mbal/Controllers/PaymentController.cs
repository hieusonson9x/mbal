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
    public class PaymentController : Controller
    {
        private readonly UserContext _context;
        private readonly PaymentService paymentService;
        public PaymentController(UserContext context)
        {
            this._context = context;
            this.paymentService = new PaymentService(context);
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Payment> Get()
        {
            var data = _context.payments.ToList();
            return data;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.payments.Where(p => p.paymentId == id).FirstOrDefault();
            if (product == null)
            {
                return new ObjectResult(new Message { status = StatusMessage.error.ToString(), message = " ID  không tồn tại" });
            }
            return new ObjectResult(product);
        }

        [HttpDelete("deleteById/{id}", Name = "detelePayment")]
        public IActionResult DeleteById(long id)
        {
            var payment = _context.payments.Where(p => p.paymentId == id).FirstOrDefault();
            if (payment == null)
            {
                return new ObjectResult(new Message { status = "error", message = "ID không tồn tại" });
            }
            else
            {
                _context.Entry(payment).State = EntityState.Deleted;
                _context.SaveChanges();
                return new ObjectResult(new Message { status = "error", message = "Xóa thành công payment  với ID " + id });

            }
        }

        [HttpPost("add", Name = "addpayment")]
        public IActionResult add([FromBody] Payment payment)
        {
            if (payment == null)
            {
                return new ObjectResult(new Message { status = "error", message = "Dữ liệu không hợp lệ" });
            }
            var a = _context.payments.Where(p => p.paymentId == payment.paymentId ).FirstOrDefault();
            if (a == null)
            {
                payment.paymentId = 0;
                _context.payments.Add(payment);
                _context.SaveChanges();

                return new ObjectResult(new Message { status = "success", message = "Thêm thành công" });
            }
            else
            {
                return new ObjectResult(new Message { status = "error", message = "Thêm thất bại" });
            }
        }

        [HttpPost("update", Name = "updatepayment")]
        public IActionResult update([FromBody] Payment payment)
        {
            if (payment == null)
            {
                return new ObjectResult(new Message { status = "error", message = "Dữ liệu không hợp lệ" });
            }
            var a = _context.payments.Where(p => p.paymentId.Equals(payment.paymentId)).FirstOrDefault();
            if (a == null)
            {
                return new ObjectResult(new Message { status = "error", message = "Không tồn tại" });
            }
            else
            {
                a.amountPayment = payment.amountPayment;
                a.customerCode = payment.customerCode;
                a.insurranceId = payment.insurranceId;
                a.createAt = payment.createAt;
                _context.Update(a);
                _context.SaveChanges();
                return new ObjectResult(new Message { status = StatusMessage.success.ToString(), message = "Cập nhật  thành công" });
            }
        }
    }
}
