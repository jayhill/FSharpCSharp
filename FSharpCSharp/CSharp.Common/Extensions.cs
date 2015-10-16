using System.Collections.Generic;
using System.Linq;

namespace CSharp.Common
{
    public static class Extensions
    {
        public static T Second<T>(this IEnumerable<T> coll)
        {
            if (coll == null || coll.Count() < 2)
            {
                return default(T);
            }

            return coll.Skip(1).First();
        }
    }
}