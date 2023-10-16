using BusinessObject.Repository;
using DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;
using X.PagedList;

namespace CinemaAdmin.Controllers
{
    //[Authorize(Roles ="a")]

    public class AccountController : Controller
    {
        IAccountRepository accountRepository;
        private readonly CinemaDbContext _context;

        public AccountController(CinemaDbContext context)
        { 
            accountRepository = new AccountRepository();
            _context = context;
        }
        public IActionResult Index()
        {
            var account = accountRepository.GetAccounts();
            
            return View(account);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateAccount(Account acc)
        {
            //if (_context.Accounts.Where(u => u.Username == acc.Username).FirstOrDefault() != null)
            //{
            //    return Ok("Already Exist");
            //}
            //_context.Accounts.Add(acc);
            //_context.SaveChanges();

            //return View(acc);

            accountRepository.InsertAccount(acc);
            return RedirectToAction("Index", "Account");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = accountRepository.GetAccountById(id);
            return View(model);
        }

        public IActionResult UpdateAccount(Account acc)
        {
            accountRepository.UpdateAccount(acc);
            return RedirectToAction("Index", "Account");
        }

        public ActionResult Delete(int id)
        {
            var model = accountRepository.GetAccountById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int accId, Account acc)
        {
                accountRepository.DeleteAccount(acc.AccountId);
                return RedirectToAction("Index", "Account");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Account _account)
        {
            var acc = accountRepository.GetAccounts().Where(a => a.Username == _account.Username && a.Password == _account.Password && a.Role == "a").FirstOrDefault();
            if (acc == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, acc.Username),
            new Claim("FullName", acc.Username),
            new Claim(ClaimTypes.Role, acc.Role),
        };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {

                };

                HttpContext.SignInAsync(
                   CookieAuthenticationDefaults.AuthenticationScheme,
                   new ClaimsPrincipal(claimsIdentity),
                   authProperties);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(
              CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = accountRepository.GetAccountById(id.Value);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }


    }
}
