using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiTenancyByEnterprise.Data;
using MultiTenancyByEnterprise.Models;
using MultiTenancyByEnterprise.Services;
using System.Security.Claims;

namespace MultiTenancyByEnterprise.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ApplicationDbContext context;
        private readonly IChangeTenantService changeTenantService;

        public UserController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ApplicationDbContext context,
            IChangeTenantService changeTenantService) 
        { 
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
            this.changeTenantService = changeTenantService;
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
                var user = await userManager.FindByEmailAsync(model.Email);
                var linkedEnterprises = await context.EnterpriseUserPermissions
                    .Where(x => x.UserId == user.Id && x.Permission == Entities.Permissions.Null)
                    .OrderBy(x => x.EnterpriseId)
                    .Take(2)
                    .Select(x => x.EnterpriseId)
                    .ToListAsync();

                if (linkedEnterprises.Count == 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (linkedEnterprises.Count == 1)
                {
                    await changeTenantService.ReplaceTenant(linkedEnterprises[0], user.Id);
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    return RedirectToAction("Change", "Enterprise");
                }
            }
            else 
            {
                ModelState.AddModelError(string.Empty, "Incorrect Email or password");
                return View(model);
            }
        }
    }
}
