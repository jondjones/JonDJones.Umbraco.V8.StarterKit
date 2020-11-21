using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Core.Models.PublishedContent;

namespace umbraco.local.Controllers
{
    public class HamsterDanceController : RenderMvcController
    {
        // GET: HamsterDance
        public override ActionResult Index(ContentModel item)
        {
            var hamster = new HamsterDance(item.Content);
            return CurrentTemplate(hamster);
        }
    }
}