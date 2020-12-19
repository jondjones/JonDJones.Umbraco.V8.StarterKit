using System.Web.Mvc;
using TutorialCode.Service;
using TutorialCode.ViewModel.Umbraco;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Controllers.Umbraco
{
    public class CringeSayingsController : RenderMvcController
    {
        private IUmbracoContextFactory _umbracoContextFactory;

        public CringeSayingsController(
            IUmbracoContextFactory umbracoContextFactory)
        {
            _umbracoContextFactory = umbracoContextFactory;
        }

        public override ActionResult Index(ContentModel item)
        {
            var homepageService = new HomepageService(_umbracoContextFactory);
            var featureFlagOne = homepageService.GetSettings().FeatureFlagOne;

            var settingsService = new SettingsService(_umbracoContextFactory);
            var sringeSayings = new CringeSayings(item.Content);

            return CurrentTemplate(new ComposedViewModel<CringeSayings, CringeSayingsViewModel>
            {
                Page = sringeSayings,
                ViewModel = new CringeSayingsViewModel
                {
                    BluePillOrTheRedOne = settingsService.SettingsPage.BluePillOrTheRedOne,
                    DisplayRow = settingsService.FeatureFlags.FeatureFlagOne
                }
            });
        }
    }
}