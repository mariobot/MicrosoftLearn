using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiTenancyByEnterprise.Data;
using MultiTenancyByEnterprise.Entities;
using MultiTenancyByEnterprise.Models;
using MultiTenancyByEnterprise.Services;
using System.Transactions;

namespace MultiTenancyByEnterprise.Controllers
{
    [Authorize]
    public class EnterpriseController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IUserService userService;
        private readonly IChangeTenantService changeTenantService;

        public EnterpriseController(ApplicationDbContext context,
            IUserService userService,
            IChangeTenantService changeTenantService)
        {
            this.context = context;
            this.userService = userService;
            this.changeTenantService = changeTenantService;            
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEnterprise createEnterprise)
        {
            if (!ModelState.IsValid)
            { 
                return View(createEnterprise);
            }

            var enterprise = new Enterprise
            {
                Name = createEnterprise.Name,
            };

            var userId = userService.GetUserId();
            enterprise.CreationUserId = userId;
            context.Add(enterprise);
            await context.SaveChangesAsync();

            var userEnterprisePermissions = new List<EnterpriseUserPermission>();

            foreach (var permission in Enum.GetValues<Permissions>())
            {
                userEnterprisePermissions.Add(new EnterpriseUserPermission
                {
                    EnterpriseId = enterprise.Id,
                    UserId = userId,
                    Permission = permission
                });
            }

            context.AddRange(userEnterprisePermissions);
            await context.SaveChangesAsync();

            await changeTenantService.ReplaceTenant(enterprise.Id, userId);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Change()
        {
            var userId = userService.GetUserId();
            var enterprises = await context.EnterpriseUserPermissions
                .Include(x => x.Enterprise)
                .Where(x => x.UserId == userId)
                .Select(x => x.Enterprise!)
                .Distinct()
                .ToListAsync();
            
            return View(enterprises);
        }

        [HttpPost]
        public async Task<IActionResult> Change(Guid Id)
        {
            var userId = userService.GetUserId();
            await changeTenantService.ReplaceTenant(Id, userId);
            return RedirectToAction("Index", "Home");
        }
    }
}
