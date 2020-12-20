using JDJ.Core.Composer;
using TutorialCode.Components;
using TutorialCode.Controllers.MVC;
using TutorialCode.Controllers.Umbraco;
using TutorialCode.Service;
using TutorialCode.ViewModel;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace TutorialCode.Composers
{
    //[ComposeBefore(typeof(ComposerTwo))]
    [ComposeAfter(typeof(RegisterDependencies))]
    public class ComposerOne : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<ComponentOne>();
        }
    }
}