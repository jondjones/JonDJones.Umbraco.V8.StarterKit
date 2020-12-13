using System.Web.Mvc;
using TutorialCode.ViewModel.Umbraco;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Controllers.Umbraco
{
    public class ComposersAndComponentsController : RenderMvcController
    {
        public override ActionResult Index(ContentModel item)
        {
            var page = new ComposersAndComponents(item.Content);
            return CurrentTemplate(new ComposedViewModel<ComposersAndComponents, EmptyViewModel>
            {
                Page = page,
                ViewModel = new EmptyViewModel()
            });
        }
    }
}
