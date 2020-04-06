using Umbraco.Core.Models.PublishedContent;

namespace JDJ.Core.ViewModel.Base
{
    public class ComposedPageViewModel<TPage, TViewModel>
        where TPage : PublishedContentModel
    {
        public TPage Page { get; set; }

        public TViewModel ViewModel { get; set; }
    }
}
