using Umbraco.Web.PublishedModels;

namespace TutorialCode.Service
{
    public interface ISitePages
    {
        Settings SettingsPage { get; }

        FeatureFlags FeatureFlags { get; }
    }
}