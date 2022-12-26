namespace SharpHorizons.Tests.IdentityCases.MajorObjectCases;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    public class MajorObjectIDs : IEnumerable<object?[]>
    {
        public static IEnumerable<MajorObjectID> Items => new MajorObjectID[]
        {
            new(1),
            new(-1)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidMajorObjectNames : IEnumerable<object?[]>
    {
        public static IEnumerable<MajorObjectName> Items => new MajorObjectName[]
        {
            new("Earth"),
            new("Voyager 1 (spacecraft)")
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidMajorObjectNames : IEnumerable<object?[]>
    {
        public static IEnumerable<MajorObjectName> Items => new MajorObjectName[]
        {
            default
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidCombinations : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Permutate(MajorObjectIDs.Items, ValidMajorObjectNames.Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidCombinations : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Permutate(MajorObjectIDs.Items, InvalidMajorObjectNames.Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
