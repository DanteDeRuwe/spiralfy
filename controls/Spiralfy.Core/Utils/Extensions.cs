﻿using System;
using System.Collections.Generic;
using System.Linq;
using SpotifyAPI.Web;

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

        public static T ChooseRandom<T>(this ICollection<T> list, Random random = default)
        {
            var r = random ?? new Random();
            return list.ElementAt(r.Next(list.Count));
        }
        
        public static T ChooseRandom<T>(this IReadOnlyCollection<T> list, Random random = default)
        {
            var r = random ?? new Random();
            return list.ElementAt(r.Next(list.Count));
        }

        public static string GetId(this IPlayableItem item)
        {
            return item switch
            {
                FullEpisode e => e.Id,
                FullTrack t => t.Id,
                _ => throw new ArgumentException()
            };
        }
    }
}
