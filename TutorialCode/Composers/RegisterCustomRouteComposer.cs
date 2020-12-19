using JDJ.Core.Composer;
using TutorialCode.Components;
using Umbraco.Core.Composing;

namespace TutorialCode.Composers
{
    public class RegisterCustomRouteComposer
        : ComponentComposer<RegisterSettingsComponent>, IUserComposer
    {
    }
}
