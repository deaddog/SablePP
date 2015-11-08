using System;
using System.Collections.Generic;
using System.Linq;

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
        /// <typeparam name="TKey">The type of the keys contained by the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values contained by the dictionary.</typeparam>
        /// <param name="collection">The dictionary form which a value is extracted.</param>
        /// <param name="key">The key to look for in the dictionary.</param>
        /// <param name="translate">A method that translates an object of type <typeparamref name="TKey"/> into a key string.
        /// Wehn set to <c>null</c>, the objects ToString method is used instead.</param>
        /// <returns>The value associated with the key that has the closest edit distance to <paramref name="key"/>.
        /// If the dictionary is empty; <c>default(<typeparamref name="TValue"/>)</c>.</returns>
        public static TValue GetNearest<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> collection, TKey key, Func<TKey, string> translate = null)
        {
            if (translate == null) translate = x => x.ToString();

            return GetNearest(collection, translate(key), x => translate(x.Key)).Value;
        }

        /// <summary>
        /// Gets the element that is closest to <paramref name="key"/>.
        /// This method always return a value, if the collection is not empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection from which a value is extracted.</param>
        /// <param name="key">The key to look for in the collection.</param>
        /// <param name="translate">A method that translates an object of type <typeparamref name="T"/> into a key string.
        /// Wehn set to <c>null</c>, the objects ToString method is used instead.</param>
        /// <returns>The value associated with the key (translated from objects) that has the closest edit distance to <paramref name="key"/>.
        /// If the collection is empty; <c>default(T)</c>.</returns>
        public static T GetNearest<T>(this IEnumerable<T> collection, string key, Func<T, string> translate = null)
        {
            var first = collection.GetDistance(key, translate).Cast<EditDistance<T>?>().FirstOrDefault();
            return first.HasValue ? first.Value.Target : default(T);
        }
    }
}
