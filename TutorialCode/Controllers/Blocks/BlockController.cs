using System.Web.Mvc;
using TutorialCode.ViewModel.Base;
using TutorialCode.ViewModel.Partials;
using Umbraco.Core.Models.Blocks;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Controllers.Umbraco
{
    public class BLockController : Controller
    {
        public ActionResult Index(IPublishedElement item, string alias)
        {
            if (alias == "redBlock")
            {
                return GenerateRedBlockViewModel(item, alias);
            }
            else if (alias == "blackBlock")
            {
                var block = new BlackBlock(item);
                return PartialView("BlockList/Components/" + alias, block);
            }
            else if (alias == "blueBlock")
            {
                var block = new BlueBlock(item);
                return PartialView("BlockList/Components/" + alias, block);
            }

            return null;
        }

        private ActionResult GenerateRedBlockViewModel(IPublishedElement item, string alias)
        {
            var block = new RedBlock(item);
            return PartialView("BlockList/Components/" + alias, new PublishedElementViewModel<RedBlock, RedViewModel>
            {
                Block = block,
                ViewModel = new RedViewModel
                {
                    DisplayTitle = !string.IsNullOrEmpty(block.Title)
                }
            });
        }
    }
}