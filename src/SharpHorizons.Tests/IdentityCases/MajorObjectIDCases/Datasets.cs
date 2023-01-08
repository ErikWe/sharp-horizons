namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    public class MajorObjectIDInts : IEnumerable<object?[]>
    {
        public static IEnumerable<int> Items => new int[]
        {
            int.MaxValue,
            int.MinValue,
            0,
            1,
            -1
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class MajorObjectIDs : IEnumerable<object?[]>
    {
        public static IEnumerable<MajorObjectID> Items
        {
            get
            {
                foreach (var id in MajorObjectIDInts.Items)
                {
                    yield return new(id);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
