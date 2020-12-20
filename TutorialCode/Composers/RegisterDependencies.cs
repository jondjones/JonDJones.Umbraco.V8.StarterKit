using System;
using TutorialCode.Components;
using TutorialCode.Controllers.MVC;
using TutorialCode.Controllers.Umbraco;
using TutorialCode.Service;
using TutorialCode.ViewModel;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web;

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

            // Vanilla Controllers
            composition.Register<BLockController>(Lifetime.Transient);
            composition.Register<DiController>(Lifetime.Transient);

            // Scheduled Task
            // composition.Components().Append<ReoccurringTasks>();

            // Interfaces
            composition.Register<ISitePages, SettingsService>(Lifetime.Transient);
        }
    }
}