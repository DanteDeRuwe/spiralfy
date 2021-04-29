using System;
using System.Collections.Generic;
using System.Linq;

namespace Spiralfy.Core.Utils
{
    public static class Extensions
    {
        public static IDictionary<string, string> ToFragmentDict(this Uri uri)
        {
            var maxLen = Math.Min(1, uri.Fragment.Length);
            return uri.Fragment.Substring(maxLen)
                .Split("&", StringSplitOptions.RemoveEmptyEntries)
                .Select(param => param.Split("=", StringSplitOptions.RemoveEmptyEntries))
                .ToDictionary(param => param[0], param => param[1]);
        }


        public static string ExtractAccessToken(this Uri uri)
        {
            var fragmentDict = uri.ToFragmentDict();
            fragmentDict.TryGetValue("access_token", out var token);
            return token;
        }
    }
}
