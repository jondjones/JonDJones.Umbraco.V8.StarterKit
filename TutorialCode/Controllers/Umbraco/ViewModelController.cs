using System;
using System.Web.Mvc;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Controllers.Umbraco
{
    public class ViewModelController : RenderMvcController
    {
        public override ActionResult Index(ContentModel model)
        {
            var page = new ViewModels(model.Content);
            return CurrentTemplate(new ComposedViewModel<ViewModels, DedicatedViewModel>
            {
                Page = page,
                ViewModel = DedicatedViewModelPageService(page)
            });
        }

        private DedicatedViewModel DedicatedViewModelPageService(ViewModels page)
        {
            return new DedicatedViewModel
            {
                HasImage = true,
                ImageUrl = page?.Image?.Url
            };
        }
    }

    // MY SECRET METHOD, SSSHHHHH!!!!
    public class ComposedViewModel<TPage, TViewModel>
        where TPage : PublishedContentModel
    {
        public TPage Page { get; set;  }

        public TViewModel ViewModel { get; set; }
    }

    // Method Two
    public class ViewModelCombined : BaseVM<ViewModels>
    {
        public ViewModelCombined(ViewModels current)
            : base(current)
        { }

        public bool HasImage { get; set; }

        public string ImageUrl { get; set; }
    }

    public class BaseVM<T> where T : PublishedContentModel
    {
        public BaseVM(T currentPage)
        {
            Page = currentPage;
        }

        public T Page { get; set; }
    }

    // Method One
    public class DedicatedViewModel
    {
        public bool HasImage { get; set; }

        public string ImageUrl { get; set; }
    }


}
