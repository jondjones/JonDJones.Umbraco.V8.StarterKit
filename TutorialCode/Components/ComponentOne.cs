using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core.Composing;
using Umbraco.Web;
using Umbraco.Web.PublishedModels;
using Umbraco.Core.Logging;
using TutorialCode.Composers;

namespace JDJ.Core.Composer
{
    public class ComponentOne : IComponent
    {
        private IUmbracoContextFactory _umbracoContextFactory;
        private readonly ILogger _logger;

        public ComponentOne(
            IUmbracoContextFactory umbracoContextFactory, ILogger logger)
        {
            _umbracoContextFactory = umbracoContextFactory;
            _logger = logger;
        }

        public void Initialize()
        {
            using (var cref = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var cache = cref.UmbracoContext.Content;
                var test = cache.GetAtRoot().DescendantsOrSelf<Home>().First();
                var home = test.Name;
                _logger.Error<ComponentOne>("ERROR {0}"+ home, home);
            }
        }

        public void Terminate()
        {
        }
    }
}