using Umbraco.Core.Models.PublishedContent;

namespace TutorialCode.ViewModel.Base
{
    public class PublishedElementViewModel<TBlock, TViewModel>
        where TBlock : PublishedElementModel
    {
        public TBlock Block { get; set; }

        public TViewModel ViewModel { get; set; }
    }
}