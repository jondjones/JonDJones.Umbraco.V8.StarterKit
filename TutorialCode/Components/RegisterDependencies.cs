using System;
using TutorialCode.Components;
using TutorialCode.Controllers.MVC;
using TutorialCode.Controllers.Umbraco;
using TutorialCode.Service;
using TutorialCode.ViewModel;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace TutorialCode.Composers
{



public class RegisterDependencies : IUserComposer
    {
        public void Compose(Composition composition)
        {
            // Composer and Components Tutorial
            composition.Register<ScopedExample>(Lifetime.Scope);
            composition.Register<RequestExample>(Lifetime.Request);
            composition.Register<TransientExample>(Lifetime.Transient);
            composition.Register<SingltonExample>(Lifetime.Singleton);

            // Controllers
            composition.Register<BLockController>(Lifetime.Request);
            composition.Register<DiController>(Lifetime.Request);

            composition.Components().Append<RegisterSettingsComponent>();

            // Interfaces
            composition.Register<ISitePages, SettingsService>(Lifetime.Singleton);
        }
    }
}