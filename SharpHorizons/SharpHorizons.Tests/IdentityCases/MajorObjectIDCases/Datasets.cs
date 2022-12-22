namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    internal class MajorObjectIDInts : IEnumerable<object?[]>
    {
        public static IEnumerable<int> Items => new int[]
        {
            int.MaxValue,
            int.MinValue,
            0,
            1,
            -1
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    internal class MajorObjectIDs : IEnumerable<object?[]>
    {
        public static IEnumerable<MajorObjectID> Items
        {
            get
            {
                foreach (var id in MajorObjectIDInts.Items)
                {
                    yield return new MajorObjectID(id);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
