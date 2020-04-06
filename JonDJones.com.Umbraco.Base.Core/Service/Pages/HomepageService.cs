using JonDJones.com.Umbraco.Base.Core;
using JDJ.Core.ViewModels.Pages;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.PublishedModels;

namespace JDJ.Core.Service
{
    public class HomepageService
    {
        public HomepageService ()
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