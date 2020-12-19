using JDJ.Core.Composer;
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

            // Controllers
            composition.Register<BLockController>(Lifetime.Request);
            composition.Register<DiController>(Lifetime.Request);
            composition.Register<SharedPartialController>();

            composition.Components().Append<RegisterSettingsComponent>();
            composition.Components().Append<ComponentOne>();

            // Dependency Injection
            composition.Register<ISitePages, SettingsService>(Lifetime.Singleton);

            // Components
            composition.Components();

            // Content Apps
            composition.ContentApps();

            // Content ContentFinders
            composition.ContentFinders();

            // Dashboards
            composition.Dashboards();

            // Data Editors
            composition.DataEditors();
        }
    }
}