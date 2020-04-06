using System;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core.Composing;

namespace JDJ.Core.Composer
{
    public class RegisterCustomRouteComposer : ComponentComposer<RegisterCustomRouteComponent>
    {
    }

    public class RegisterCustomRouteComponent : IComponent
    {
        public void Initialize()
        {
            //RouteTable.Routes.MapRoute(
            //       "SharedPartial",
            //       "Partial/{action}/{id}",
            //       new
            //       {
            //           controller = "SharedPartial",
            //           action = "Index",
            //           id = UrlParameter.Optional
            //       });
        }

        public void Terminate()
        {
        }
    }
}