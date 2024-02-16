using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MultiTenancy.Models;
using MultiTenancy.Services;
using System.Security.Claims;

namespace MultiTenancy.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public UserController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager) 
        { 
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new IdentityUser { Email = model.Email, UserName = model.Email };

            var result = await userManager.CreateAsync(user, model.Password);

            var personalClaims = new List<Claim>
            {
                new Claim(ConstantsProject.ClaimTenantId, user.Id)
            };

            await userManager.AddClaimsAsync(user, personalClaims);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, true);
                return RedirectToAction("Index", "Home");
            }
            else 
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Login()
        { 
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        { 
            if (!ModelState.IsValid) 
            { 
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.Rememberme, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else 
            {
                ModelState.AddModelError(string.Empty, "Incorrect Email or password");
                return View(model);
            }
        }
    }
}
