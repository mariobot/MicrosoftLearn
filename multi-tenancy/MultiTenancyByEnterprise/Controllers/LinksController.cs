using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiTenancyByEnterprise.Data;
using MultiTenancyByEnterprise.Entities;
using MultiTenancyByEnterprise.Models;
using MultiTenancyByEnterprise.Services;

namespace MultiTenancyByEnterprise.Controllers
{
    [Authorize]
    public class LinksController : Controller
    {

        private readonly ApplicationDbContext context;
        private readonly IUserService userService;
        private readonly IServiceTenant serviceTenant;

        public LinksController(ApplicationDbContext context,
            IUserService userService,
            IServiceTenant serviceTenant)
        {
            this.context = context;
            this.userService = userService;
            this.serviceTenant = serviceTenant;
        }

        public async Task<IActionResult> Index()
        {
            var userId = userService.GetUserId();
            return await RecoveryPendingLinks(userId);
        }

        private async Task<IActionResult> RecoveryPendingLinks(string userId) 
        { 
            var pendingLinks = await context.Links
                .Include(x => x.Enterprise)
                .Where(x => x.Status == Entities.LinkStatus.Pending && x.UserId == userId)
                .ToListAsync();

            return View(pendingLinks);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Guid enterpriseId, LinkStatus linkStatus)
        { 
            var userId = userService.GetUserId();
            var link = await context.Links.FirstOrDefaultAsync(x => x.UserId == userId
                && x.EnterpriseId == enterpriseId
                && x.Status == LinkStatus.Pending);

            if (link == null) 
            {
                ModelState.AddModelError("", "ERROR, enterprise link dont found");
                return await RecoveryPendingLinks(userId);
            }

            if (linkStatus  == LinkStatus.Accepted)
            {
                var permision = new EnterpriseUserPermission()
                {
                    Permission = Permissions.Null,
                    EnterpriseId = enterpriseId,
                    UserId = userId
                };

                context.Add(permision);
            }

            link.Status = linkStatus;
            await context.SaveChangesAsync();

            return RedirectToAction("Change","Enterprise");
        }

        public async Task<IActionResult> Link()
        {
            var enterpriseId = serviceTenant.GetTenant();

            if (string.IsNullOrEmpty(enterpriseId))
            {
                return RedirectToAction("Index", "Home");
            }

            var enterpriseGuidId = new Guid(enterpriseId);

            var enterprise = await context.Enterprise.FirstOrDefaultAsync(x => x.Id == enterpriseGuidId);

            if (enterprise == null) 
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new LinkUser()
            {
                EnterpriseId = enterprise.Id,
                EnterpriseName = enterprise.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Link(LinkUser model)
        { 
            if (!ModelState.IsValid) 
            { 
                return View(model);
            }

            var userToLink = await context.Users.FirstOrDefaultAsync(x => x.Email == model.EmailUser);

            if (userToLink == null) 
            { 
                ModelState.AddModelError(nameof(model.EmailUser), "Not exist the user by that email.");
                return View(model);
            }

            var link = new Link()
            {
                EnterpriseId = model.EnterpriseId,
                UserId = userToLink.Id,
                Status = LinkStatus.Pending,
                CreationDate = DateTime.UtcNow
            };

            context.Add(link);
            await context.SaveChangesAsync();

            return RedirectToAction("LinkedUsers");        
        }

        public IActionResult LinkedUsers() 
        { 
            return View();
        }
    }
}
