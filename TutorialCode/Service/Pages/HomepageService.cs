using TutorialCode.ViewModel.Umbraco;
using Umbraco.Core.Models.PublishedContent;

namespace JDJ.Core.Service
{
    public class HomepageService
    {
        public HomepageService()
        {
        }

        public HomepageViewModel GetHomepageViewModel(IPublishedContent content)
        {
            var viewModel = new HomepageViewModel
            {
            };

            return viewModel;
        }
    }
}