using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Dashboards;

namespace TutorialCode.Dashboard
{
    public class RegisterDashboard : IDashboard
    {
        public string[] Sections => new[] { "content" };

        public IAccessRule[] AccessRules
        {
            get
            {
                var rules = new IAccessRule[]
                {
                    new AccessRule {Type = AccessRuleType.Grant, Value = Umbraco.Core.Constants.Security.UserMembershipProviderName}
                };
                return rules;
            }
        }

        public string Alias => "RickRollMe";

        public string View => "/umbraco/backoffice/Plugins/Backend/MyAdmin";
    }
}