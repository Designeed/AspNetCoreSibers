using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AspNetCoreSibers.Service
{
    public static class Extantions
    {
        public static string RemoveController(this string str)
            => str.Replace("Controller", string.Empty, StringComparison.OrdinalIgnoreCase);

        public static string GetDisplayName(this Enum enumValue)
            =>
            enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()?
            .GetName() ?? enumValue.ToString(); 
    }
}
