using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bigon.Infrastructure.Extension
{
    public static partial class Extension
    {
        static public string ToSlug(this string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
                return null;

            var replaceSet = new Dictionary<string, string>()
            {
      {"Ü|ü","u"},
      {"İ|I|ı","i"},
      {"Ş|ş","s"},
      {"Ö|ö","o"},
      {"Ç|ç","c"},
      {"Ğ|ğ","g"},
      {"Ə|ə","e"},
      {"#","sharp"},
      {@"(\?|/|\|\.|'|`|%|\*|!|@|\+)+","" },
      {@"\$+","and"},
      {@"[^a-z0-9]+","-"}
        };
            return replaceSet.Aggregate(slug, (i, m) => Regex.Replace(i, m.Key, m.Value, RegexOptions.IgnoreCase)).ToLower();

    }
}
}
