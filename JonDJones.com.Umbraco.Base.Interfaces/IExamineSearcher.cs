using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;

namespace JonDJones.com.Umbraco.Base.Interfaces
{
    public interface IExamineSearcher
    {
        IEnumerable<IPublishedContent> GetAllByDocumentType(string documentType);

        IEnumerable<IPublishedContent> SearchByDocumentType(string search, List<string> documentTypes);
    }
}
