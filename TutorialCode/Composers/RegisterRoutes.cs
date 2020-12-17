using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace JDJ.Core.Composer
{
    public class RegisterCustomRouteComposer : ComponentComposer<RegisterCustomRouteComponent>
    {
    }

    public class RegisterCustomRouteComponent : IComponent
    {
        public void Initialize()
        {
            RouteTable.Routes.MapRoute(
               "DI",
               "DI",
               new
               {
                   controller = "Di",
                   action = "Index",
                   id = UrlParameter.Optional
               });

            RouteTable.Routes.MapRoute(
               "SharedPartial",
               "Partial/{action}/{id}",
               new
               {
                   controller = "SharedPartial",
                   action = "Index",
                   id = UrlParameter.Optional
               });

            RouteTable.Routes.MapRoute(
                "BLockController",
                "BLock/{action}/{item}/{alias}",
                new
                {
                    controller = "BLock",
                    action = "Index",
                    item = UrlParameter.Optional,
                    alias = UrlParameter.Optional,
                });
        }

        public void Terminate()
        {
        }
    }
}