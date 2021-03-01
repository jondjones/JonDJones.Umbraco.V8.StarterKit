using System;
using System.Web.Mvc;
using Umbraco.Core.Composing;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Controllers.Umbraco
{
    public class MyMediaEventComponent : IComponent
    {
        public void Initialize()
        {
            MemberService.Saved += MemberService_Saved;
        }

        private void MemberService_Saved(IMemberService sender, SaveEventArgs<IMember> e)
        {
            throw new NotImplementedException();
        }

        public void Terminate()
        {
            MediaService.Saved -= MediaService_Saved;
        }

        private void MediaService_Saved(IMediaService sender, SaveEventArgs<IMedia> e)
        {
        }
    }

    public class ViewModelsController : RenderMvcController
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
            var url = page?.Image?.Url;
            return new DedicatedViewModel
            {
                HasImage = !string.IsNullOrEmpty(url),
                ImageUrl = url
            };
        }
    }

    // MY SECRET METHOD, SSSHHHHH!!!!
    public class ComposedViewModel<TPage, TViewModel>
        where TPage : PublishedContentModel
    {
        public TPage Page { get; set; }

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