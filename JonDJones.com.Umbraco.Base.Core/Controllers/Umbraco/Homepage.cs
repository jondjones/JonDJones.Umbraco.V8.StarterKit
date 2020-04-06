using JonDJones.com.Umbraco.Base.Core;
using JDJ.Core.Service;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace JDJ.Core.Controllers.Umbraco
{
    public class HomepageController : RenderMvcController
    {
        public HomepageController()
        {
        }

        public override ActionResult Index(ContentModel model)
        {
            var service = new HomepageService();
            var viewModel = service.GetHomepageViewModel(model.Content);
            return CurrentTemplate(viewModel);
        }
    }
}
