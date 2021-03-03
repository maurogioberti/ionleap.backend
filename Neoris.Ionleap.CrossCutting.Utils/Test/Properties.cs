using System;
using System.Linq;

namespace Neoris.Ionleap.CrossCutting.Utils.Test
{
    public static class Properties
    {
        public static bool PropertiesNullOrDefault<T>(this T objectToInspect, params Func<T, object>[] getters)
        {
            return getters.Any(f => f(objectToInspect) == null || f(objectToInspect) == default);
        }
    }
}
