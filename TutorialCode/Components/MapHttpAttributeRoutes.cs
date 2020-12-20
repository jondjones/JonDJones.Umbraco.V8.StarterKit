using System.Web.Http;
using Umbraco.Core.Composing;

namespace TutorialCode.Components
{
    public class MapHttpAttributeRoutes : IComponent
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