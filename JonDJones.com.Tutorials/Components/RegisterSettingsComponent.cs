using System.Web.Http;
using Umbraco.Core.Composing;

namespace umbraco.local.Code
{
    public class RegisterSettingsComponent : IComponent
    {
        public void Initialize()
        {
            GlobalConfiguration.Configuration.MapHttpAttributeRoutes();
        }

        public void Terminate()
        {
        }
    }
}