using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace TutorialCode.Controllers.MVC
{
    public class BackendController : UmbracoAuthorizedController
    {
        public ActionResult MyAdmin()
        {
            return View("MyAdmin");
        }
    }
}