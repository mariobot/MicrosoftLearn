namespace MultiTenancyByEnterprise.Services
{
    public interface IChangeTenantService
    {
        Task ReplaceTenant(Guid enterpriseId, string userId);
    }
}
