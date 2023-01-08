namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometCases;

using SharpHorizons.MPC;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

internal static class Datasets
{
    public class ValidMPCCometDesignations : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCCometDesignation> Items => new MPCCometDesignation[]
        {
            new("1P"),
            new("C/1995 O1")
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidMPCCometDesignations : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCCometDesignation> Items => new MPCCometDesignation[]
        {
            default
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidMPCCometNames : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCCometName> Items => new MPCCometName[]
        {
            new("Halley"),
            new("Hale-Bopp")
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidMPCCometNames : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCCometName> Items => new MPCCometName[]
        {
            default
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidCombinations : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetWrappers.Permutate(ValidMPCCometDesignations.Items, ValidMPCCometNames.Items)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidCombinations : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator()
        {
            var invalidRHS = DatasetWrappers.Permutate(ValidMPCCometDesignations.Items, InvalidMPCCometNames.Items);
            var invalidLHS = DatasetWrappers.Permutate(InvalidMPCCometDesignations.Items, ValidMPCCometNames.Items);
            var bothInvalid = DatasetWrappers.Permutate(InvalidMPCCometDesignations.Items, InvalidMPCCometNames.Items);

            var eitherInvalid = invalidRHS.Concat(invalidLHS).Concat(bothInvalid);

            return DatasetWrappers.SeparateAndWrap(eitherInvalid).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
