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
        public EditDistance(string origin, string target)
        {
            if (origin == null)
                throw new ArgumentNullException(nameof(origin));

            if (target == null)
                throw new ArgumentNullException(nameof(target));

            this.origin = origin;
            this.target = target;
            this.distance = editDistanceNormalized(origin, target);
        }

        private static double editDistanceNormalized(string s, string t)
        {
            double I = s.Length;
            double J = t.Length;

            double[,] dist = new double[s.Length + 1, t.Length + 1];
            for (int i = 0; i <= s.Length; i++) dist[i, 0] = i / I;
            for (int j = 1; j <= t.Length; j++) dist[0, j] = j / J;
            for (int i = 1; i <= s.Length; i++)
                for (int j = 1; j <= t.Length; j++)
                    if (s[i - 1] == t[j - 1])
                        dist[i, j] = Math.Min(dist[i - 1, j - 1], Math.Min(dist[i - 1, j] + 1 / I, dist[i, j - 1] + 1 / J));
                    else
                        dist[i, j] = Math.Min(dist[i - 1, j - 1] + 0.5 * (1 / I + 1 / J), Math.Min(dist[i - 1, j] + 1 / I, dist[i, j - 1] + 1 / J));

            return dist[s.Length, t.Length];
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
