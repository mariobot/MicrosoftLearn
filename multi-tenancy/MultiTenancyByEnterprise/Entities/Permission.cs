using MultiTenancyByEnterprise.Services;
using System.ComponentModel.DataAnnotations;

namespace MultiTenancyByEnterprise.Entities
{
    public enum Permissions
    {
        [HideAttribute]
        Null = 0, //Permissions for all members, fundamental role
        [Display(Description = "Could create products")]
        Create_Products = 1,
        [Display(Description = "Could read products")]
        Read_Products = 2,
        Link_Users = 3,
        Permissions_Read = 4,
        Permissions_Modify = 5
    }
}
