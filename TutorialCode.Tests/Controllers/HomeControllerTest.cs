using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Kernel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Tests
{
    [TestFixture]
    public class HomeControllerTest
    {
        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var objectWithPopulatedDaa = fixture.Create<IPublishedContent>();

            var frf = objectWithPopulatedDaa.Name;

            fixture.Register<IPublishedContent>(() => new FakeIPublishedContent());
            var test = fixture.Create<IPublishedContent>();
        }

        [Test]
        public void TestMethod()
        {
        }
    }

    public class FakeIPublishedContent : IPublishedContent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UrlSegment { get; set; }

        public int SortOrder { get; set; }

        public int Level { get; set; }

        public string Path { get; set; }

        public int? TemplateId { get; set; }

        public int CreatorId { get; set; }

        public string CreatorName { get; set; }

        public System.DateTime CreateDate { get; set; }

        public int WriterId { get; set; }

        public string WriterName { get; set; }

        public System.DateTime UpdateDate { get; set; }

        public string Url { get; set; }

        public IReadOnlyDictionary<string, PublishedCultureInfo> Cultures { get; set; }

        public PublishedItemType ItemType { get; set; }

        public IPublishedContent Parent { get; set; }

        public IEnumerable<IPublishedContent> Children { get; set; }

        public IEnumerable<IPublishedContent> ChildrenForAllCultures => throw new System.NotImplementedException();

        public IPublishedContentType ContentType => throw new System.NotImplementedException();

        public System.Guid Key => throw new System.NotImplementedException();

        public IEnumerable<IPublishedProperty> Properties => throw new System.NotImplementedException();

        public IPublishedProperty GetProperty(string alias)
        {
            throw new System.NotImplementedException();
        }

        public bool IsDraft(string culture = null)
        {
            throw new System.NotImplementedException();
        }

        public bool IsPublished(string culture = null)
        {
            throw new System.NotImplementedException();
        }
    }
}