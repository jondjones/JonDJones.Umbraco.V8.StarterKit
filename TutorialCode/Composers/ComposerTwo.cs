using Umbraco.Core;
using Umbraco.Core.Composing;

namespace TutorialCode.Composers
{
    // [ComposeBefore(typeof(ComposerOne))]
    // [Disable(typeof(ComposerOne))]
    // [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class ComposerTwo : IUserComposer
    {
        public void Compose(Composition composition)
        {
        }
    }
}