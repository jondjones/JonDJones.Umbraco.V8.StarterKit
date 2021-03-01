using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TutorialCode.ViewModel.Umbraco;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedModels;
using Umbraco.Core.Cache;

namespace TutorialCode.Controllers.Umbraco
{
    public class CachingController : RenderMvcController
    {
        private AppCaches _cache;

        public CachingController(AppCaches cache)
        {
            _cache = cache;
            cache
                .RuntimeCache
                .GetCacheItem<DateTime>("jdj", () => DateTime.Now.AddYears(6));
        }

        public override ActionResult Index(ContentModel model)
        {
            var viewModel = new CachingViewModel
            {
                Date = DateTime.Now.ToString("T"),
                DateTwo = _cache.RuntimeCache.GetCacheItem<DateTime>("jdj")
            };

            return CurrentTemplate(viewModel);
        }

        [OutputCache(Duration = 3600)]
        public ActionResult OutputCache()
        {
            var viewModel = new CachingViewModel
            {
                Date = DateTime.Now.AddYears(1).ToString("T")
            };

            return PartialView("~/Views/partial.cshtml", viewModel);
        }

        public ActionResult Partial()
        {
            var viewModel = new CachingViewModel
            {
                Date = DateTime.Now.ToString()
            };

            return PartialView("~/Views/partial.cshtml", viewModel);
        }
    }

    [OutputCache(CacheProfile = "ClientResourceCache")]
    public class CacheBaseController : RenderMvcController
    {
    }
}