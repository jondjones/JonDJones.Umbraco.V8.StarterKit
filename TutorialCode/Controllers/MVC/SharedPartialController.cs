using System.Web.Mvc;
using TutorialCode.Service;
using TutorialCode.ViewModel.Partials;

namespace TutorialCode.Controllers.MVC
{
    public class SharedPartialController : Controller
    {
        private readonly ISitePages _sitePages;

        public SharedPartialController(
            ISitePages sitePages)
        {
            _sitePages = sitePages;
        }

        public ActionResult RenderHeader()
        {
            var viewModel = new HeaderViewModel
            {
                RedPill = _sitePages.SettingsPage.BluePillOrTheRedOne
            };

            return PartialView("SiteFurniture/Header", viewModel);
        }
    }
}
