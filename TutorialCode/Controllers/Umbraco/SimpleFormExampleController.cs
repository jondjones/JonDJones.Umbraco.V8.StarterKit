using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TutorialCode.ViewModel.Umbraco;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Controllers.Umbraco
{
    public class SimpleFormExampleController : RenderMvcController
    {
        public override ActionResult Index(ContentModel item)
        {
            var page = new SimpleFormExample(item.Content);
            return CurrentTemplate(new ComposedViewModel<SimpleFormExample, EmptyViewModel>
            {
                Page = page,
                ViewModel = new EmptyViewModel()
            });
        }
    }
}
