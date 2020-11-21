namespace TutorialCode.Interfaces
{
    public interface IAppSettingsService
    {
        bool GetBool(string boolToConvert);

        int GetInt(string intToConvert);

        string GetAppSetting(string appSettingName);
    }
}
