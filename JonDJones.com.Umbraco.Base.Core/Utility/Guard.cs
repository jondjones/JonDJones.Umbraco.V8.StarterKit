using System;

namespace JonDJones.com.Umbraco.Base.Core.Utility
{
    public static class Guard
    {
        public static void ValidateObject(object objecttoTest)
        {
            if (objecttoTest == null)
                throw new ArgumentNullException($"{nameof(objecttoTest)} passed in has not been instantiated.");
        }
    }
}
