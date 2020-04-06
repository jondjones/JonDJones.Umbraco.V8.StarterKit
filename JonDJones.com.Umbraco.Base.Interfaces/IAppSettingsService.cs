using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonDJones.com.Umbraco.Base.Interfaces
{
    public interface IAppSettingsService
    {
        bool GetBool(string boolToConvert);

        int GetInt(string intToConvert);

        string GetAppSetting(string appSettingName);
    }
}
