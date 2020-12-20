using System.Web.Mvc;
using TutorialCode.Service;
using TutorialCode.ViewModel.Partials;

namespace TutorialCode.Controllers.MVC
{
    public class SharedPartialController : Controller
    {
        private readonly ISettingsService _sitePages;

        public SharedPartialController(
            ISettingsService sitePages)
        {
            _sitePages = sitePages;
        }

         [OutputCache(Duration = 3600)]
        public ActionResult RenderHeader()
        {
            var viewModel = new HeaderViewModel
            {
                RedPill = _sitePages.FeatureFlags.FeatureFlagOne
            };

            return PartialView("SiteFurniture/Header", viewModel);
        }
    }
}
