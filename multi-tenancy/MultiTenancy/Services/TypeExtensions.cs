using Microsoft.AspNetCore.Identity;
using MultiTenancy.Entities;

namespace MultiTenancy.Services
{
    public static class TypeExtensions
    {
        public static bool JumpTenantValidation(this Type t)
        {
            var booleans = new List<bool>()
            {
                t.IsAssignableFrom(typeof(IdentityRole)),
                t.IsAssignableFrom(typeof(IdentityRoleClaim<string>)),
                t.IsAssignableFrom(typeof(IdentityRole)),
                t.IsAssignableFrom(typeof(IdentityUser)),
                t.IsAssignableFrom(typeof(IdentityUserLogin<string>)),
                t.IsAssignableFrom(typeof(IdentityUserRole<string>)),
                t.IsAssignableFrom(typeof(IdentityUserToken<string>)),
                t.IsAssignableFrom(typeof(IdentityUserClaim<string>)),
                typeof(ICommonEntity).IsAssignableFrom(t)
            };

            var result = booleans.Aggregate((b1, b2) => b1 || b2);

            return result;
        }
    }
}
