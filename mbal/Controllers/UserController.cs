using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mbal.Models;
using mbal.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mbal.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserContext _context;
        private readonly UserService userService;

        public UserController(UserContext context)
        {
            _context = context;
            this.userService = new UserService(context);
            if (_context.users.Count() == 0)
            {
                _context.users.Add(new User { username = "hieunm" });
                _context.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _context.users.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _context.users.FirstOrDefault(t => t.id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        [HttpGet("add", Name = "AddUser")]
        public String add()
        {
           _context.users.Add(new Models.User { username = "hieumnmn" });
            _context.SaveChanges();
            
            return "ok";
        }
    }
}
