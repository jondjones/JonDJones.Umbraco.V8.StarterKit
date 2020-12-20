using Moq;
using NUnit.Framework;
using System.Web;
using System.Web.Security;
using TutorialCode.Controllers.MVC;
using Umbraco.Core.Composing;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using  Xania.AspNet.Simulator;
using FluentAssertions;
using Umbraco.Core.Cache;
using Umbraco.Web.Security;
using Umbraco.Web.Security.Providers;
using Umbraco.Web;
using Umbraco.Web.PublishedCache;
using TutorialCode.Tests.Helper;

namespace TutorialCode.Tests.Controllers
{
    [TestFixture]
    public class MemberControllerTests
    {
        private Mock<IFactory> _factory;
        private UmbracoMockDependancyFactory _umbracoMockDependancyFactory;

        [SetUp]
        public void SetUp()
        {
            _umbracoMockDependancyFactory = new UmbracoMockDependancyFactory();
            _factory = new Mock<IFactory>();
            var accessor = new Mock<IUmbracoContextAccessor>();
            _factory.Setup(x => x.GetInstance(typeof(IUmbracoContextAccessor)))
               .Returns(accessor.Object);

            _factory.Setup(x => x.GetInstance(typeof(MembershipHelper)))
                   .Returns(_umbracoMockDependancyFactory.MembershipHelper);

            Current.Factory = _factory.Object;
        }

        [Test]
        public void AnonymousUserIsNotAuthorized()
        {
            var _factory = new UmbracoMockDependancyFactory();
            var controller = new MemberController();
            var action = controller.Action(c => c.Index());

            try
            {
                action.GetAuthorizationResult();
            }
            catch (HttpException ex)
            {
                ex.Message.Should().Contain("Resource restricted:");
            }
        }

        [Test]
        public void Basic_ControllerTest()
        {
            var username = "myUsername";
            var accessor = new Mock<IUmbracoContextAccessor>();

            var member = new Mock<IMember>();
            member.Setup(x => x.Username).Returns(username);

            var memberService = new Mock<IMemberService>();
            memberService.Setup(x => x.GetByUsername(username)).Returns(member.Object);

            var memberCache = new Mock<IPublishedMemberCache>();
            memberCache.Setup(x => x.GetByMember(member.Object)).Returns(Mock.Of<IPublishedContent>());

            var memberTypeService = Mock.Of<IMemberTypeService>();
            var membershipProvider = new MembersMembershipProvider(memberService.Object, memberTypeService);

            var membershipHelper = new MembershipHelper(
                _umbracoMockDependancyFactory.HttpContextBase.Object,
                memberCache.Object,
                membershipProvider,
                Mock.Of<RoleProvider>(),
                memberService.Object,
                Mock.Of<IMemberTypeService>(),
                Mock.Of<IUserService>(), Mock.Of<IPublicAccessService>(), AppCaches.NoCache, Mock.Of<Umbraco.Core.Logging.ILogger>());

            _factory.Setup(x => x.GetInstance(typeof(MembershipHelper))).Returns(membershipHelper);

            var action = new MemberController().Action(c => c.Index()).Authenticate(username, new string[0]);
            var result = action.GetAuthorizationResult();
            result.Should().BeNull();
        }

    }
}
