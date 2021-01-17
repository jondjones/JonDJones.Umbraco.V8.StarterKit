using TutorialCode.ContentApps;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace TutorialCode.Composers
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class CustomContentAppComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.ContentApps().Append<MyContentApp>();
        }
    }

}
