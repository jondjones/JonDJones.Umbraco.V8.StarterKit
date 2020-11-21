using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Controllers.Umbraco
{
    public class HamsterDanceController : RenderMvcController
    {
        public override ActionResult Index(ContentModel item)
        {
            var hamster = new HamsterDance(item.Content);
            return CurrentTemplate(item);
        }
    }
}