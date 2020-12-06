using System.Linq;
using Umbraco.Web;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Service
{
    public class HomepageService
    {
        private IUmbracoContextFactory _umbracoContextFactory;

        public HomepageService(
            IUmbracoContextFactory umbracoContextFactory)
        {
            _umbracoContextFactory = umbracoContextFactory;
        }

        public Home GetSettings()
        {
            Home home;
            using (var cref = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var cache = cref.UmbracoContext.Content;
                home = cache.GetAtRoot().DescendantsOrSelf<Home>().First();
            }

            return home;
        }
    }
}
