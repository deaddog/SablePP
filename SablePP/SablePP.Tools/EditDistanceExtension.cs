using System;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Tools
{
    /// <summary>
    /// Provides methods for performing edit distance operations on collections.
    /// </summary>
    public static class EditDistanceExtension
    {
        /// <summary>
        /// Gets the normalized Levenshtein distance between <paramref name="origin"/> and the items in <paramref name="collection"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection that is tested.</typeparam>
        /// <param name="collection">The collection that is tested.</param>
        /// <param name="origin">The <see cref="string"/> that the elements in <paramref name="collection"/> are compared to.</param>
        /// <param name="translate">A method that translates each element in <paramref name="collection"/> into a string which is compared to <paramref name="origin"/>.
        /// If this value is <c>null</c> the objects ToString method will be used.</param>
        /// <returns>A collection of elements representing the distance between <paramref name="origin"/> and the items in <paramref name="collection"/>.
        /// The collection is sorted such that the best match is returned first.</returns>
        public static IEnumerable<EditDistance<T>> GetDistance<T>(this IEnumerable<T> collection, string origin, Func<T, string> translate = null)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            if (origin == null)
                throw new ArgumentNullException(nameof(origin));

            if (translate == null)
                translate = v => v.ToString();

            return collection.Select(x => new EditDistance<T>(origin, x, translate(x))).OrderBy(x => x.Distance);
        }

        /// <summary>
        /// Gets the normalized Levenshtein distance between <paramref name="origin"/> and each key in <paramref name="collection"/>.
        /// </summary>
        /// <typeparam name="TKey">The key type of the elements in the collection.</typeparam>
        /// <typeparam name="TValue">The value type of the elements in the collection.</typeparam>
        /// <param name="collection">The collection that is tested.</param>
        /// <param name="origin">The <see cref="string"/> that the keys in <paramref name="collection"/> are compared to.</param>
        /// <param name="translate">A method that translates each key in <paramref name="collection"/> and the <paramref name="origin"/> into a string for comparison.
        /// If this value is <c>null</c> the key objects ToString method will be used.</param>
        /// <returns>A collection of elements representing the distance between <paramref name="origin"/> and the keys in <paramref name="collection"/> along with the associated value.
        /// The collection is sorted such that the best match is returned first.</returns>
        public static IEnumerable<EditDistance<TValue>> GetDistance<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> collection, TKey origin, Func<TKey, string> translate = null)
        {
            if (translate == null) translate = x => x.ToString();

            return GetDistance(collection, translate(origin), x => translate(x.Key)).Select(x => new EditDistance<TValue>(x.Origin, x.Target.Value, x.TargetString, x.Distance));
        }

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
