using System.Text;
using System.Text.RegularExpressions;

namespace cacheHW.Base
{
    public static class RelateText
    {
        public static string RemoveSpaceCharacter(this string source)
            => Regex.Replace(source.Trim(), @"\s{2,}", " ");
    }
}
