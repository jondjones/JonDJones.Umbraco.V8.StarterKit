using Umbraco.Core;
using Umbraco.Core.Composing;

namespace JDJ.Core.Composer
{
    public class RegisterDependencies : IUserComposer
    {
        public void Compose(Composition composition)
        {
            // composition.Register<IWebsiteDependencies, WebsiteDependencies>(Lifetime.Singleton);
        }
    }
}
