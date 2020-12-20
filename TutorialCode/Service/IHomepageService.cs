using Umbraco.Web.PublishedModels;

namespace TutorialCode.Service
{
    public interface IHomepageService
    {
        Home GetSettings();
    }
}