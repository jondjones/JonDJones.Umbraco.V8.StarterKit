using System.Web.Mvc;
using TutorialCode.Service;
using TutorialCode.ViewModel.Umbraco;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Controllers.Umbraco
{
    public class CringeSayingsController : RenderMvcController
    {
        private ISitePages _settings;

        public CringeSayingsController(ISitePages settings)
        {
            _settings = settings;
        }

        public override ActionResult Index(ContentModel item)
        {
            var hamster = new CringeSayings(item.Content);
            return CurrentTemplate(new ComposedViewModel<CringeSayings, CringeSayingsViewModel>
            {
                Page = hamster,
                ViewModel = new CringeSayingsViewModel
                {
                    BluePillOrTheRedOne = _settings.SettingsPage.BluePillOrTheRedOne,
                    DisplayRow = _settings.FeatureFlags.FeatureFlagOne
                }
            });
        }
    }
}