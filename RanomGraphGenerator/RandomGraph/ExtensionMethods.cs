using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomGraph
{
    public static class ExtensionMethods
    {
        // http://stackoverflow.com/a/1287572/1033764
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rnd)
        {
            T[] elements = source.ToArray();
            for (var i = elements.Length - 1; i >= 0; i--)
            {
                // Swap element "i" with a random earlier element it (or itself)
                // ... except we don't really need to swap it fully, as we can
                // return it immediately, and afterwards it's irrelevant.
                var swapIndex = rnd.Next(i + 1);
                yield return elements[swapIndex];
                elements[swapIndex] = elements[i];
            }
        }

        // http://stackoverflow.com/a/1300116/1033764
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> knownKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
