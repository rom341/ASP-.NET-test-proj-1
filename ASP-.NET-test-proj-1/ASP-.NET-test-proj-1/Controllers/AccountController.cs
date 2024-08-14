using ASP_.NET_test_proj_1.Data.Interfaces;
using ASP_.NET_test_proj_1.Models;
using ASP_.NET_test_proj_1.ViewModels.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<ActionResult> Index()
        {
            var accounts = await userAccountRepository.GetAllAsync();
            var vm = new IndexViewModel(accounts);
            return View(vm);
        }

        // GET: AccountController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var foundAccount = await userAccountRepository.GetByIdAsync(id);
            if (foundAccount == null)
            {
                return NotFound();
            }
            var vm = new DetailsViewModel(foundAccount);
            return View(vm);
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login when button pressed
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var foundUser = await userAccountRepository.GetByLoginAsync(model.Login);
                if (foundUser != null && foundUser.Password == model.Password)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, foundUser.Login),
                        new Claim(ClaimTypes.Email, foundUser.Email ?? string.Empty)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);


                    return RedirectToAction("Login", "Register");
                }
                else
                {
                    ModelState.AddModelError("Login", "Login failed");
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
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
                var foundUser = userAccountRepository.GetByLoginAsync(model.Login);
                if (foundUser.IsFaulted)
                {
                    var newUser = new UserAccount(model.Login, model.Password, model.Email);
                    userAccountRepository.Add(newUser);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Login", "Login is captured. Please, change login and try again.");
                }
            }
            return View(model);
        }
    }
}
