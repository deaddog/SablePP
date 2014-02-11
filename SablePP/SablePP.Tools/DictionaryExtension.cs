using System;
using System.Collections.Generic;

namespace SablePP.Tools
{
    public static class DictionaryExtension
    {
        private static int editDistance(string s, string t)
        {
            int[,] dist = new int[s.Length + 1, t.Length + 1];
            for (int i = 0; i <= s.Length; i++) dist[i, 0] = i;
            for (int j = 1; j <= t.Length; j++) dist[0, j] = j;
            for (int i = 1; i <= s.Length; i++)
                for (int j = 1; j <= t.Length; j++)
                    if (s[i - 1] == t[j - 1])
                        dist[i, j] = Math.Min(dist[i - 1, j - 1], Math.Min(dist[i - 1, j] + 1, dist[i, j - 1] + 1));
                    else
                        dist[i, j] = 1 + Math.Min(dist[i - 1, j - 1], Math.Min(dist[i - 1, j], dist[i, j - 1]));

            int v = dist[s.Length, t.Length];
            return v;
        }
    }
}
