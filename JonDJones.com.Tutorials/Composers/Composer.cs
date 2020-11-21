using Umbraco.Core;
using Umbraco.Core.Composing;

namespace umbraco.local.Code
{
    public class myComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<RegisterSettingsComponent>();
        }
    }
}