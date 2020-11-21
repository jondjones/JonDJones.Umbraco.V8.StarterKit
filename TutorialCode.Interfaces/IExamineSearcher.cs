using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;

namespace TutorialCode.Interfaces
{
    public interface IExamineSearcher
    {
        IEnumerable<IPublishedContent> GetAllByDocumentType(string documentType);

        IEnumerable<IPublishedContent> SearchByDocumentType(string search, List<string> documentTypes);
    }
}
