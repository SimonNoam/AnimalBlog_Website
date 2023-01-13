using AnimalsWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsWeb.Controllers
{
    public class AcountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AcountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Login() => View();
       

        [HttpPost]
        public async Task<IActionResult> Login(LoginPage model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.User, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterPage model)
        {

            if (ModelState.IsValid)
            {
                var UserName = new IdentityUser { UserName = model.UserName };
                var ResultNew = await _userManager.CreateAsync(UserName, model.Password);

               // await _userManager.AddToRoleAsync(UserName, "Admin");

                if (ResultNew.Succeeded)
                {
                    await _signInManager.SignInAsync(UserName, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
          
        }
    }
}
