using Microsoft.AspNetCore.Mvc;
using BusinessObject.Repository;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using DataAccess;

namespace CinemaWed.Controllers
{
    public class AccountController : Controller
    {
        IAccountRepository accountRepository;

        public AccountController()
        {

            accountRepository = new AccountRepository();
        }
        public ActionResult Login()
        {
            HttpContext.Session.Clear();
            return View();
        }



        public ActionResult CheckLogin(string username, string password)
        {

            Account acc = accountRepository.GetAccounts().FirstOrDefault(a => a.Username == username);

            if (acc == null)
            {
                return RedirectToAction("Login", "Account");
            }
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, acc.Password);
            if (isValidPassword)
            {
                HttpContext.Session.SetString("role", "User");
                HttpContext.Session.SetString("username", username);
                HttpContext.Session.SetInt32("id", acc.AccountId);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Account account)
        {

            try
            {
                accountRepository.InsertAccount(account);

                return View("Login", "Account");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return RedirectToAction("Register", "Account");
            }
            return View();
        }

    }
}
