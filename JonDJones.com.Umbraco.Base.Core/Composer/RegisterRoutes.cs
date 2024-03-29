﻿using System.Web.Mvc;
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