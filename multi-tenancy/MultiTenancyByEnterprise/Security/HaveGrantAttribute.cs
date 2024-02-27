using Microsoft.AspNetCore.Authorization;
using MultiTenancyByEnterprise.Entities;
using MultiTenancyByEnterprise.Services;

namespace MultiTenancyByEnterprise.Security
{
    public class HaveGrantAttribute : AuthorizeAttribute
    {
        public HaveGrantAttribute(Permissions permissions) 
        {
            Permissions = permissions;
        }

        public Permissions Permissions 
        {
            get
            {
                if (Enum.TryParse(typeof(Permissions), Policy!.Substring(ConstantsProject.PrefixPolicy.Length), ignoreCase: true, out var permission))
                {
                    return (Permissions)permission!;
                }

                return Permissions.Null;
            }

            set 
            {
                Policy = $"{ConstantsProject.PrefixPolicy}{value.ToString()}";            
            }
        }
    }
}
