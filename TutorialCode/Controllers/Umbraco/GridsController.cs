using System.Web.Http;
using System.Web.Mvc;
using TutorialCode.ViewModel.Umbraco;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Controllers.Umbraco
{
    public class GridsController : RenderMvcController
    {
        public override ActionResult Index(ContentModel model)
        {
            var page = new Grids(model.Content);
            return CurrentTemplate(new ComposedViewModel<Grids, EmptyViewModel>
            {
                Page = page,
                ViewModel = new EmptyViewModel()
            });
        }
    }
}