using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Controllers.Umbraco
{
    public class HomeController : RenderMvcController
    {
        public override ActionResult Index(ContentModel model)
        {
            return CurrentTemplate(new Home(model.Content));
        }
    }
}
