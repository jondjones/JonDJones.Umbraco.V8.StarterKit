using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Core.Models.ContentEditing;
using Umbraco.Core.Models.Membership;
using Umbraco.Web;

namespace TutorialCode.ContentApps
{
    public class MyContentApp : IContentAppFactory
    {
        public ContentApp GetContentAppFor(object source, IEnumerable<IReadOnlyUserGroup> userGroups)
        {
            if (source is IContent)
            {
                return new ContentApp
                {
                    Alias = "myContentApp",
                    Name = "Rick Roll Me",
                    Icon = "icon-cloud",
                    View = UriUtility.ToAbsolute($"/App_Plugins/MyContentApp/myContentApp.html"),
                    Weight = -100,
                    Active = true
                };
            }

            return null;
        }
    }
}