using JonDJones.com.Umbraco.Base.Core.Utility;
using TutorialCode.Interfaces;

namespace JonDJones.com.Umbraco.Base.Core
{
    public class AppSettings : IAppSettings
    {
        private readonly IAppSettingsService _appSettingsService;

        public AppSettings(IAppSettingsService appSettingsService)
        {
            Guard.ValidateObject(appSettingsService);
            _appSettingsService = appSettingsService;
        }

        public int TestNewsletterCampaignId => _appSettingsService.GetInt("TestNewsletterCampaignId");
    }
}