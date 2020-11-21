using System;
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
            return CurrentTemplate(new ComposedViewModel<Home, HomeVM>
            {
                Page = home,
                ViewModel = HomePageService(home)
            });
        }

        private HomeVM HomePageService(Home home)
        {
            return new HomeVM
            {
                HasImage = true,
                ImageUrl = home?.Image?.Url
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
    public class HomeViewM : BaseVM<Home>
    {
        public HomeViewM(Home current)
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
    public class HomeVM
    {
        public bool HasImage { get; set; }

        public string ImageUrl { get; set; }
    }


}
