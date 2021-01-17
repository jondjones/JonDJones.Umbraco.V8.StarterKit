using Umbraco.Web.Routing;

namespace TutorialCode.ContentFinder
{
    public class CustomContentFinder : IContentFinder
    {
        public bool TryFindContent(PublishedRequest request)
        {
            return true;
        }
    }
}
