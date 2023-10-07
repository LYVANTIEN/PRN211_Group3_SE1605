using BusinessObject;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly CinemaDbContext _context;
        public AdminController(IConfiguration config, CinemaDbContext context)
        {
            _config = config;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public IActionResult Create(Account acount)
        {
            if (_context.Accounts.Where(u => u.Username == acount.Username).FirstOrDefault() != null)
            {
                return Ok("Already Exist");
            }
            _context.Accounts.Add(acount);
            _context.SaveChanges();
            return Ok("Success");
        }

        [AllowAnonymous]
        [HttpPost("loginUser")]
        public IActionResult Login(Account acount)
        {
            var userAvailable = _context.Accounts.Where(u => u.Username == acount.Username && u.Password == acount.Password).FirstOrDefault();
            if (userAvailable != null)
            {
                return Ok(new JwtService(_config).GenerateToken(
                    userAvailable.AccountId.ToString(),
                    userAvailable.Username,
                    userAvailable.Password,
                    userAvailable.Email,
                    userAvailable.Phone,
                    userAvailable.Role
                    ));
            }
            return Ok("Failure");
        }
    }
}
