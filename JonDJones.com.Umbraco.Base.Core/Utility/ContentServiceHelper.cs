using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Core.Models;
using ClientDependency.Core.Logging;
using Umbraco.Core.Services;
using System.Collections.Generic;
using Examine;
using Umbraco.Examine;
using System.Linq;
using System;
using Serilog.Core;
using Examine.Search;
using JonDJones.com.Umbraco.Base.Core;
using JonDJones.com.Umbraco.Base.Interfaces;

namespace JDJ.Core.Routing
{
    public class ContentServiceHelper : IContentServiceHelper
    {
        private IUmbracoContextFactory _umbracoContextFactory;
        private readonly IContentService _contentService;
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;
        private readonly INotificationService _notificationService;

        public ContentServiceHelper(
            IUmbracoContextFactory umbracoContextFactory,
            IContentService contentService,
            IUmbracoContextAccessor umbracoContextAccessor,
            INotificationService notificationService)
        {
            _umbracoContextFactory = umbracoContextFactory;
            _contentService = contentService;
            _umbracoContextAccessor = umbracoContextAccessor;
            _notificationService = notificationService;
        }

        public IEnumerable<IPublishedContent> GetPagesByAlias(string alias)
        {
            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var content = umbracoContextReference.UmbracoContext.Content;
                return content.GetByXPath("//" + alias);
            }
        }

        public IEnumerable<IPublishedContent> GetPagesByContentTypeId(int id)
        {
            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var contentType = umbracoContextReference.UmbracoContext.Content.GetContentType(id);
                return umbracoContextReference.UmbracoContext.Content.GetByContentType(contentType);
            }
        }

        public IEnumerable<IPublishedContent> SearchByAlias(string alias)
        {
            ExamineManager.Instance.TryGetIndex("ExternalIndex", out var index);
            var searcher = index.GetSearcher();
            var results = searcher
                .CreateQuery()
                .NodeTypeAlias(alias).Execute();

            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {
                return results.Select(x => umbracoContextReference.UmbracoContext.Content.GetById(Convert.ToInt32(x.Id)));
            }
        }

        public bool SavePage(IContent content)
        {
            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var result = _contentService.SaveAndPublish(content);
                if (result.Success)
                    return true;

                return false;
            }
        }

        public IPublishedContent GetPage(int id)
        {
            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var content = umbracoContextReference.UmbracoContext.Content;
                return content.GetById(id);
            }
        }

        public IPublishedContent GetPage(string id)
        {
            using (var umbracoContextReference = _umbracoContextFactory.EnsureUmbracoContext())
            {

                var idAsInt = Convert.ToInt32(id);
                var content = umbracoContextReference.UmbracoContext.Content;
                return content.GetById(idAsInt);
            }
        }

        public IPublishedContent GetCurrentPage()
        {
            return Umbraco.Web.Composing.Current.UmbracoHelper.AssignedContentItem;
        }
    }
}
