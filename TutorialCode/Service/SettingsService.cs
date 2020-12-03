using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Service
{
    public class SettingsService : ISitePages
    {
        private IUmbracoContextFactory _umbracoContextFactory;

        public SettingsService(
            IUmbracoContextFactory umbracoContextFactory)
        {
            _umbracoContextFactory = umbracoContextFactory;
        }

        public Settings SettingsPage => GetSettings();

        public FeatureFlags FeatureFlags => GetFeatureFlag();

        private FeatureFlags GetFeatureFlag()
        {
            var item = SettingsPage
                         .FeatureFlags
                         .Where(x => x.Content.ContentType.Alias == FeatureFlags.ModelTypeAlias)
                         .First();

            return new FeatureFlags(item.Content);
        }

        private Settings GetSettings()
        {
            using (var cref = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var cache = cref.UmbracoContext.Content;
                return cache.GetAtRoot().DescendantsOrSelf<Settings>().First();
            }
        }
    }
}
