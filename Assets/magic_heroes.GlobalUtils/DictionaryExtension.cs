using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace magic_heroes.GlobalUtils
{
    public static class DictionaryExtension
    {
        public static string ToDebugString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return new StringBuilder()
                .Append("{")
                .Append(string.Join(",", dictionary.Select(kv => kv.Key + "=" + kv.Value).ToArray()))
                .Append("}").ToString();
        }
    }
}