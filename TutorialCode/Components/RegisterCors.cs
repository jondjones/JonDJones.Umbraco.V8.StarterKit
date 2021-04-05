using Umbraco.Web.Scheduling;
using Umbraco.Core.Logging;
using Umbraco.Core.Composing;
using Umbraco.Core;
using System.Web.Http.Cors;
using System.Web.Http;

namespace TutorialCode.Components
{
    public class EnableCors : IComponent
    {
        public void Initialize()
        {
            var corsAttr = new EnableCorsAttribute("http://www.website.com,http://websitetwo.com", "*", "*");
            GlobalConfiguration.Configuration.EnableCors(corsAttr);
        }

        public void Terminate()
        {
        }
    }
}