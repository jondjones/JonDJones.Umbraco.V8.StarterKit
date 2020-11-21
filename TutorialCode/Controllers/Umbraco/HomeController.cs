using System.Web.Mvc;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Controllers.Umbraco
{
    public class HomeController : RenderMvcController
    {
        public override ActionResult Index(ContentModel model)
        {
            var home = new Home(model.Content);
            return CurrentTemplate(new HomeViewModel
            {
                HasImage = !string.IsNullOrEmpty(home?.Image?.Url)
            });
        }
    }


}
