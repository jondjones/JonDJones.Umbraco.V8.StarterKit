using System.Web.Mvc;
using Umbraco.Core.Models.Blocks;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Controllers.Umbraco
{
    public class BLockController : Controller
    {
        public ActionResult Index(BlockListItem item, string alias)
        {
            if (alias == "bLock")
            {
                var block = new BLock(item.Content);
                return PartialView("BlockList/Components/" + alias, block);
            }
            return null;
        }
    }
}
