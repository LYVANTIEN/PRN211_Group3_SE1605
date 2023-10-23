using BusinessObject.Repository;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CinemaAdmin.Controllers
{
    [Authorize(Roles ="a")]

    public class AdminController : Controller
    {
        IAccountRepository accountRepository;
        private readonly CinemaDbContext _context;

        public AdminController(CinemaDbContext context)
        {
            accountRepository = new AccountRepository();
            _context = context;
        }
        public IActionResult Index(string SearchText, int? page)
        {
            var account = accountRepository.GetAccounts();
            var pageSize = 3;
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(SearchText))
            {
                account = account.Where(c => c.Username.ToLower().Contains(SearchText));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            account = account.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            //ViewBag.Movies = movies.ToList().ToPagedList(pageSize, 1);
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
            return RedirectToAction("Index", "Admin");
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
            return RedirectToAction("Index", "Admin");
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
            return RedirectToAction("Index", "Admin");
        }
    }
}
