using System;

namespace SablePP.Tools
{
    /// <summary>
    /// Represents the comparison of two strings using normalized (see http://www.xavierdupre.fr/blog/documents/edit_distance_normalization.pdf) Levenshtein distance.
    /// </summary>
    public struct EditDistance
    {
        private string origin, target;
        private double distance;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditDistance"/> struct.
        /// </summary>
        /// <param name="origin">The original string in the transformation.</param>
        /// <param name="target">The target string in the transformation.</param>
        /// <param name="distance">The edit distance between the two strings.</param>
        public EditDistance(string origin, string target, double distance)
        {
            if (origin == null)
                throw new ArgumentNullException(nameof(origin));

            if (target == null)
                throw new ArgumentNullException(nameof(target));

            this.origin = origin;
            this.target = target;
            this.distance = distance;
        }

        /// <summary>
        /// Gets the original string.
        /// </summary>
        public string Origin => origin;
        /// <summary>
        /// Gets the string into which <see cref="Origin"/> is being transformed.
        /// </value>
        public string Target => target;

        /// <summary>
        /// Gets the "normalized" edit distance between <see cref="Origin"/> and <see cref="Target"/>. This is value in the range [0; 1.5].
        /// </summary>
        public double Distance => distance;
    }
}
