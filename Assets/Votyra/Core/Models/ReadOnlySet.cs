using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Votyra.Core.Models
{
    public static class ReadOnlySet<T>
    {
        public static readonly IReadOnlySet<T> Empty = new InnerSet();

        private class InnerSet : IReadOnlySet<T>
        {
            public int Count => 0;

            public bool Contains(T value) => false;

            public IEnumerator<T> GetEnumerator() =>
                Enumerable.Empty<T>()
                    .GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() =>
                Enumerable.Empty<T>()
                    .GetEnumerator();
        }
    }
}