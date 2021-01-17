using Umbraco.Web.PublishedModels;

namespace TutorialCode.Service
{
    public interface ISettingsService
    {
        Settings SettingsPage { get; }

        FeatureFlags FeatureFlags { get; }
    }
}