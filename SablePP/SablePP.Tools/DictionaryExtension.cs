using System;
using System.Collections.Generic;

namespace SablePP.Tools
{
    /// <summary>
    /// Provides extension methods for <see cref="IDictionary{T1,T2}"/>.
    /// </summary>
    public static class DictionaryExtension
    {
        /// <summary>
        /// Gets the value whose key is closest to <paramref name="key"/>.
        /// This method always return a value, if the dictionary is not empty.
        /// </summary>
        /// <typeparam name="T">The type of the values contained by the dictionary.</typeparam>
        /// <param name="dict">The dictionary form which a value is extracted.</param>
        /// <param name="key">The key to look for in the dictionary.</param>
        /// <param name="maxDistance">The maximum "distance" allowed when comparing keys.</param>
        /// <returns>The value associated with the key that has the closest edit distance to <paramref name="key"/>.
        /// If the dictionary is empty; <c>default(T)</c>.</returns>
        public static T GetNearest<T>(this IDictionary<string, T> dict, string key, int maxDistance = int.MaxValue)
        {
            if (key == null)
                throw new ArgumentNullException("key");

            if (dict.ContainsKey(key))
                return dict[key];

            int diff = int.MaxValue;
            T t = default(T);
            foreach (var k in dict.Keys)
            {
                int cdiff = editDistance(k, key);
                if (cdiff < diff)
                {
                    diff = cdiff;
                    t = dict[k];
                }
            }

            if (diff > maxDistance)
                return default(T);
            else
                return t;
        }

        /// <summary>
        /// Gets the element that is closest to <paramref name="key"/>.
        /// This method always return a value, if the collection is not empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection from which a value is extracted.</param>
        /// <param name="key">The key to look for in the collection.</param>
        /// <param name="translate">A method that translates an object of type <typeparamref name="T"/> into a key string..</param>
        /// <param name="maxDistance">The maximum "distance" allowed when comparing keys.</param>
        /// <returns>The value associated with the key (translated from objects) that has the closest edit distance to <paramref name="key"/>.
        /// If the collection is empty; <c>default(T)</c>.</returns>
        public static T GetNearest<T>(this IEnumerable<T> collection, string key, Func<T, string> translate, int maxDistance = int.MaxValue)
        {
            if (key == null)
                throw new ArgumentNullException("key");

            int diff = int.MaxValue;
            T t = default(T);
            foreach (var k in collection)
            {
                if (k == null)
                    continue;

                int cdiff = editDistance(translate(k), key);
                if (cdiff < diff)
                {
                    diff = cdiff;
                    t = k;
                }
            }

            if (diff > maxDistance)
                return default(T);
            else
                return t;
        }

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
