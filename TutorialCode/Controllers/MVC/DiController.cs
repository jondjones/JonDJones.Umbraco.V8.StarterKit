using System;
using System.Web.Mvc;
using TutorialCode.Composers;
using TutorialCode.ViewModel;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Controllers.Umbraco
{
    public class DiController : Controller
    {
        public DiController(
            TransientExample transientExample, 
            TransientExample transientExample1,
            ScopedExample scopedExample,
            ScopedExample scopedExample1,
            SingltonExample singltonExample,
            SingltonExample singltonExample1,
            RequestExample requestExample,
            RequestExample requestExample1)
        {
            var transientExampleid = transientExample.Id;
            var transientExampleid1 = transientExample1.Id;
            var scopedExampleid = scopedExample.Id;
            var scopedExampleid1 = scopedExample1.Id;
            var singltonExampleid = singltonExample.Id;
            var singltonExampleid1 = singltonExample1.Id;
            var requestExampleid = requestExample.Id;
            var requestExamplid1 = requestExample1.Id;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
