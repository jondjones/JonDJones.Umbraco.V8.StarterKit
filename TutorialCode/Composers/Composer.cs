using TutorialCode.Components;
using TutorialCode.Controllers.Umbraco;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace TutorialCode.Composers
{
    public class myComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {

            composition.Register<BLockController>(Lifetime.Request);
            composition.Components().Append<RegisterSettingsComponent>();
        }
    }
}