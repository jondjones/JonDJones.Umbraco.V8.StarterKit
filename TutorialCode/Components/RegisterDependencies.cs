using TutorialCode.Components;
using TutorialCode.Controllers.MVC;
using TutorialCode.Controllers.Umbraco;
using TutorialCode.Service;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace TutorialCode.Composers
{
    public class RegisterDependencies : IUserComposer
    {
        public void Compose(Composition composition)
        {
            // Composer and Components Tutorial
            // https://www.lightinject.net/
            composition.Register<SharedPartialController>();
            composition.Register<SharedPartialController>(Lifetime.Request);
            composition.Register<SharedPartialController>(Lifetime.Singleton);
            composition.Register<SharedPartialController>(Lifetime.Scope);
            composition.Register<SharedPartialController>(Lifetime.Transient);

            // Controllers
            composition.Register<BLockController>(Lifetime.Request);
            composition.Components().Append<RegisterSettingsComponent>();

            // Interfaces
            composition.Register<ISitePages, SettingsService>(Lifetime.Singleton);
        }
    }
}