using Examine;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Examine;

namespace JDJ.Core.Utility
{
    public class ExamineSearcher : IExamineSearcher
    {
        private readonly IContentServiceHelper _contentService;

        public ExamineSearcher(
            IContentServiceHelper contentService)
        {
            _contentService = contentService;
        }

        public IEnumerable<IPublishedContent> SearchByDocumentType(string search, List<string> documentTypes)
        {
            if (!ExamineManager.Instance.TryGetIndex("ExternalIndex", out var index) || !(index is IUmbracoIndex umbIndex))
            {
                throw new InvalidOperationException($"No index found by name ExternalIndex or is not of type {typeof(IUmbracoIndex)}");
            }

            var searcher = umbIndex.GetSearcher();
            if (searcher == null)
            {
                return null;
            }

            var qry = searcher.CreateQuery("content").Field("nodeName", search);
            foreach (var documentType in documentTypes)
            {
                qry.Or().Field("__NodeTypeAlias", documentType);

            }

            return qry.Execute().OrderByDescending(x => x.Score).Select(x => _contentService.GetPage(x.Id));
        }

        public IEnumerable<IPublishedContent> GetAllByDocumentType(string documentType)
        {
            if (!ExamineManager.Instance.TryGetIndex("ExternalIndex", out var index) || !(index is IUmbracoIndex umbIndex))
            {
                throw new InvalidOperationException($"No index found by name ExternalIndex or is not of type {typeof(IUmbracoIndex)}");
            }

            var searcher = umbIndex.GetSearcher();
            if (searcher == null)
            {
                return null;
            }

            var qry = searcher.CreateQuery("").Field("__NodeTypeAlias", documentType);
            return qry.Execute().Select(x => _contentService.GetPage(x.Id));
        }
    }
}
