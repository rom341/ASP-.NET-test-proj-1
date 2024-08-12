using ASP_.NET_test_proj_1.Data.Interfaces;
using ASP_.NET_test_proj_1.Models;
using ASP_.NET_test_proj_1.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_.NET_test_proj_1.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAccountRepository userAccountRepository;

        public AccountController(IUserAccountRepository userAccountRepository)
        {
            this.userAccountRepository = userAccountRepository;
        }
        // GET: AccountController
        public ActionResult Index()
        {
            var accounts = userAccountRepository.GetAllAsync();
            return View(accounts);
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            var account = userAccountRepository.GetByIdAsync(id);
            return View(account);
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login when button pressed
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register when button pressed
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
