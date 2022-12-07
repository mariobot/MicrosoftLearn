#nullable disable
namespace AdvWorksAPI.Components
{
    public class RouterBase
    {
        public string UrlFragment;
        protected ILogger Logger;

        public virtual void AddRoutes(WebApplication app)
        {
        }
    }
}
