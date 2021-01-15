using System.Web.Mvc;
using TutorialCode.ViewModel.Umbraco;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedCache;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Controllers.Umbraco
{
    public class CheeryQueryController : RenderMvcController
    {
        UmbracoHelper _helper;
        IPublishedContentQuery _publishedContentQuery;
        IContentService _contentService;
        IUmbracoContextFactory _umbracoContextFactory;

        public CheeryQueryController(
            //IPublishedContentCache cache   /// causes an error
            UmbracoHelper helper,
            IPublishedContentQuery publishedContentQuery,
            IContentService contentService,
            IUmbracoContextFactory umbracoContextFactory)
        {
            _helper = helper;
            _publishedContentQuery = publishedContentQuery;
            _contentService = contentService;
            _umbracoContextFactory = umbracoContextFactory;
        }


        public override ActionResult Index(ContentModel model)
        {
            var page = new CheeryQuery(model.Content);
            return CurrentTemplate(new ComposedViewModel<CheeryQuery, CheeryQueryViewModel>
            {
                Page = page,
                ViewModel = new CheeryQueryViewModel
                {
                    FromCacheTime = TimeCacheQuery(),
                    FromDatabaseTime = TimeDatabaseQuery(),
                    CheerleaderUrl = GetMediaFromPublishedContentQuery(),
                    CheerleaderOneUrl = GetMediaFromUmbracoHelper(),
                    CheerleaderTwoUrl = GetMediaFromUmbracoContextFactory(),
                    CheerleaderThreeUrl = GetMediaFromBaseType()
                }
            }); ;
        }

        // Method One
        private string GetMediaFromPublishedContentQuery()
        {
            var willBeEMpty = _publishedContentQuery.Content(2181)?.Url();
            var cheerleaderUrl = _publishedContentQuery.Media(2181)?.Url();

           //  _contentService.GetById(2182).?.Url();  HAS NO URL as it might not be published!!!

            return cheerleaderUrl;
        }

        // Method Two
        private string GetMediaFromUmbracoHelper()
        {
            return _helper.Media(2182)?.Url();
        }

        // Method Three
        private string GetMediaFromUmbracoContextFactory()
        {
            var img = string.Empty;
            using (var cref = _umbracoContextFactory.EnsureUmbracoContext())
            {
                var cache = cref.UmbracoContext.Content;
                var illBeEmpty = cache.GetById(2184)?.Url();

                var mediaCache = cref.UmbracoContext.Media;
                img = mediaCache.GetById(2184)?.Url();
            }

            return img;
        }


        // Method Three
        private string GetMediaFromBaseType()
        {
            // var illBeEmpty = UmbracoContext.Content.GetById(2185)?.Url();
            return UmbracoContext.Media.GetById(2185)?.Url();
        }

        private long TimeDatabaseQuery()
        {
            var watchTwo = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 500; i++)
            {
                _contentService.GetById(1095);
            }
            watchTwo.Stop();
            var getFromDatabaseTime = watchTwo.ElapsedMilliseconds;
            return getFromDatabaseTime;
        }

        private long TimeCacheQuery()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 500; i++)
            {
                _publishedContentQuery.Content(1095);
            }
            watch.Stop();
            var getFromCacheTime = watch.ElapsedMilliseconds;
            return getFromCacheTime;
        }
    }
}
