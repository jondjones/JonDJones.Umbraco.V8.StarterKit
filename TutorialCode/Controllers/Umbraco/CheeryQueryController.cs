﻿using System.Web.Mvc;
using TutorialCode.ViewModel.Umbraco;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Controllers.Umbraco
{
    public class CheeryQueryController : RenderMvcController
    {
        private UmbracoHelper _helper;

        private IPublishedContentQuery _publishedContentQuery;

        private IUmbracoContextFactory _umbracoContextFactory;

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

            var page = helper.Content(2141);
            var otherPage = publishedContentQuery.Content(2141);
            IPublishedContent anotherPage = null;
            using (var cref = umbracoContextFactory.EnsureUmbracoContext())
            {
                var cache = cref.UmbracoContext.Content;
                anotherPage = cache.GetById(2141);
            }
        }

        public IContentService _contentService { get; set; }

        public override ActionResult Index(ContentModel model)
        {
            UmbracoContext.Content.GetById(5);
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

        // Method Three
        private string GetMediaFromBaseType()
        {
            // var illBeEmpty = UmbracoContext.Content.GetById(2185)?.Url();
            return UmbracoContext.Media.GetById(2185)?.Url();
        }

        // Method One
        private string GetMediaFromPublishedContentQuery()
        {
            var willBeEMpty = _publishedContentQuery.Content(2181)?.Url();
            var cheerleaderUrl = _publishedContentQuery.Media(2181)?.Url();

            //  _contentService.GetById(2182).?.Url();  HAS NO URL as it might not be published!!!

            return cheerleaderUrl;
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

        // Method Two
        private string GetMediaFromUmbracoHelper()
        {
            return _helper.Media(2182)?.Url();
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
    }
}