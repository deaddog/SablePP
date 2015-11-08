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
    }
}
