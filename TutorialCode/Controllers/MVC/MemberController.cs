using Umbraco.Web.Mvc;

namespace TutorialCode.Controllers.MVC
{
    public class MemberController : SurfaceController
    {
        [UmbracoAuthorize]
        public string Index()
        {

            return "true";
        }
    }
}