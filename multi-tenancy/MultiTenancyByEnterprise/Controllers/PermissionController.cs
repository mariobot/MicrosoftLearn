using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiTenancyByEnterprise.Data;
using MultiTenancyByEnterprise.Entities;
using MultiTenancyByEnterprise.Models;
using MultiTenancyByEnterprise.Security;
using MultiTenancyByEnterprise.Services;
using System.ComponentModel.DataAnnotations;

namespace MultiTenancyByEnterprise.Controllers
{
    [Authorize]
    public class PermissionController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IServiceTenant serviceTenant;

        public PermissionController(ApplicationDbContext context,
            IServiceTenant serviceTenant)
        {
            this.context = context;
            this.serviceTenant = serviceTenant;
        }

        [HaveGrant(Permissions.Permissions_Read)]
        public async Task<IActionResult> Index()
        {
            var tenantId = new Guid(serviceTenant.GetTenant());

            var model = await context.Enterprise
                .Include(x => x.EnterpriseUserPermissions)
                .ThenInclude(x => x.User)
                .Where(x => x.Id == tenantId)
                .Select(x => new IndexPermissionsDto
                {
                    NameEnterprise = x.Name,
                    Users = x.EnterpriseUserPermissions.Select(y => new UserDto
                    {
                        Email = y.User!.Email
                    }).Distinct()
                }).FirstOrDefaultAsync();

            return View(model);
        }

        [HaveGrant(Permissions.Permissions_Read)]
        public async Task<IActionResult> Admin(string email) 
        {
            var tenantId = new Guid(serviceTenant.GetTenant());
            var userId = await context.Users.Where(x => x.Email == email)
                .Select(x => x.Id).FirstOrDefaultAsync();

            if (userId is null)
            {
                return RedirectToAction("Index", "Permission");
            }

            var permissions = await context.EnterpriseUserPermissions
                .Where(x => x.EnterpriseId == tenantId && x.UserId == userId && x.Permission != Permissions.Null)
                .ToListAsync();

            var permissionsUserDictionary = permissions.ToDictionary(x => x.Permission);

            var model = new AdminPermissionDto();
            model.UserId = userId;
            model.Email = email;

            foreach (var permission in Enum.GetValues<Permissions>()) 
            { 
                var field = typeof(Permissions).GetField(permission.ToString())!;
                var hide = field.IsDefined(typeof(HideAttribute), false);  
                
                if (hide) { continue; }

                var description = permission.ToString();

                if (field.IsDefined(typeof(DisplayAttribute), false))
                {
                    var displayAttribute = (DisplayAttribute)Attribute.GetCustomAttribute(field, typeof(DisplayAttribute))!;
                    description = displayAttribute.Description;
                }

                model.Permissions.Add(new PermissionUserDto()
                {
                    Description = description,
                    Permission = permission,
                    HaveAccess = permissionsUserDictionary.ContainsKey(permission)
                });
            }

            return View(model);
        }

        [HaveGrant(Permissions.Permissions_Modify)]
        [HttpPost]
        public async Task<IActionResult> Admin(AdminPermissionDto model)
        {
            var tenantId = new Guid(serviceTenant.GetTenant());

            // Set at default null permission
            model.Permissions.Add(new PermissionUserDto()
            {
                HaveAccess = true,
                Permission = Permissions.Null
            });

            // Delete all the previous permissions from user
            await context.Database.ExecuteSqlInterpolatedAsync($@"DELETE EnterpriseUserPermissions where UserId = {model.UserId} AND EnterpriseId = {tenantId}");

            // Filter the permissions to add
            var filteredPermissions = model.Permissions.Where(x => x.HaveAccess).Select(x => new EnterpriseUserPermission()
            {
                EnterpriseId = tenantId,
                UserId = model.UserId,
                Permission = x.Permission
            });

            // Add records to database
            context.Add(filteredPermissions);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
