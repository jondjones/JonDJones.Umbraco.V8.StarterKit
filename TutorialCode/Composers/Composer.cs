using TutorialCode.Components;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace TutorialCode.Composers
{
    public class myComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<RegisterSettingsComponent>();
        }
    }
}