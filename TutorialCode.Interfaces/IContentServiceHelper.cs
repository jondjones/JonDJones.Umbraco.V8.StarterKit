using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace TutorialCode.Interfaces
{
    public interface IContentServiceHelper
    {
        bool SavePage(IContent content);

        IPublishedContent GetPage(int id);

        IPublishedContent GetPage(string id);

        IPublishedContent GetCurrentPage();

        IEnumerable<IPublishedContent> GetPagesByAlias(string alias);

        IEnumerable<IPublishedContent> GetPagesByContentTypeId(int id);

        IEnumerable<IPublishedContent> SearchByAlias(string alias);
    }
}
