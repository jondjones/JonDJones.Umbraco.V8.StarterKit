using Moq;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using Umbraco.Core.Cache;
using Umbraco.Core.Dictionary;
using Umbraco.Core.Logging;
using Umbraco.Core.Mapping;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.PublishedCache;
using Umbraco.Web.Security;
using Umbraco.Web.Security.Providers;

namespace TutorialCode.Tests.Helper
{
    public class UmbracoMockDependancyFactory
    {
        public UmbracoHelper GetUmbracoHelper(
            IPublishedContentQuery publishedContentQuery = null,
            ICultureDictionaryFactory cultureDictionaryFactory = null,
            MembershipHelper membershipHelper = null)
        {
            return new UmbracoHelper(
                Mock.Of<IPublishedContent>(),
                Mock.Of<ITagQuery>(),
                cultureDictionaryFactory ?? CultureDictionaryFactory().Object,
                Mock.Of<IUmbracoComponentRenderer>(),
                publishedContentQuery ?? PublishedContentQuerying.Object,
                SetupMembership());
        }

        public UmbracoMapper UmbracoMapper => new UmbracoMapper(new MapDefinitionCollection(new List<IMapDefinition>()));

        public Mock<HttpContextBase> HttpContextBase => new Mock<HttpContextBase>();

        public ServiceContext ServiceContext => ServiceContext.CreatePartial();

        public Mock<IPublishedContentQuery> PublishedContentQuerying => new Mock<IPublishedContentQuery>();

        public MembershipHelper SetupMembership(IPublishedMemberCache cache = null)
        {
            var memberService = new Mock<IMemberService>();
            var memberTypeService = Mock.Of<IMemberTypeService>();
            var membershipProvider = new MembersMembershipProvider(memberService.Object, memberTypeService);

            var memberCache = new Mock<IPublishedMemberCache>();
            return new MembershipHelper(HttpContextBase.Object, cache ?? memberCache.Object, membershipProvider, Mock.Of<RoleProvider>(), memberService.Object, memberTypeService, Mock.Of<IUserService>(), Mock.Of<IPublicAccessService>(), AppCaches.NoCache, Mock.Of<ILogger>());
        }

        public Mock<ICultureDictionaryFactory> CultureDictionaryFactory(Mock<ICultureDictionary> cultureDictionary = null)
        {
            if (cultureDictionary == null)
            {
                cultureDictionary = new Mock<ICultureDictionary>();
            }

            var cultureDictionaryFactory = new Mock<ICultureDictionaryFactory>();
            cultureDictionaryFactory.Setup(x => x.CreateDictionary()).Returns(cultureDictionary.Object);

            return cultureDictionaryFactory;
        }

        public MembershipHelper MembershipHelper
        {
            get
            {
                var memberService = new Mock<IMemberService>();
                var memberTypeService = Mock.Of<IMemberTypeService>();
                var membershipProvider = new MembersMembershipProvider(memberService.Object, memberTypeService);

                var memberCache = new Mock<IPublishedMemberCache>();
                var membershipHelper = new MembershipHelper(
                    HttpContextBase.Object,
                    memberCache.Object,
                    membershipProvider,
                    Mock.Of<RoleProvider>(),
                    memberService.Object,
                    memberTypeService,
                    Mock.Of<IUserService>(),
                    Mock.Of<IPublicAccessService>(),
                    AppCaches.NoCache,
                    Mock.Of<ILogger>());

                return membershipHelper;
            }
        }

        public void SetupPropertyValue(
            Mock<IPublishedContent> publishedContentMock,
            string alias,
            object value,
            string culture = null,
            string segment = null)
        {
            var property = new Mock<IPublishedProperty>();
            property.Setup(x => x.Alias).Returns(alias);
            property.Setup(x => x.GetValue(culture, segment)).Returns(value);
            property.Setup(x => x.HasValue(culture, segment)).Returns(value != null);
            publishedContentMock.Setup(x => x.GetProperty(alias)).Returns(property.Object);
        }
    }
}
