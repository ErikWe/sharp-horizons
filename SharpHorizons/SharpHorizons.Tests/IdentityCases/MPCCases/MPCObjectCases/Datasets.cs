namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCObjectCases;

using SharpHorizons.MPC;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

internal static class Datasets
{
    public class ValidMPCSequentialNumbers : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCSequentialNumber> Items => new MPCSequentialNumber[]
        {
            new(int.MaxValue),
            new(1)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidMPCSequentialNumbers : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCSequentialNumber> Items => new MPCSequentialNumber[]
        {
            default
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidMPCNames : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCName> Items => new MPCName[]
        {
            new("Ceres"),
            new("Vesta")
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidMPCNames : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCName> Items => new MPCName[]
        {
            default
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidMPCProvisionalDesignations : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCProvisionalDesignation> Items => new MPCProvisionalDesignation[]
        {
            new("A801 AA"),
            new("A807 FA")
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidMPCProvisionalDesignations : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCProvisionalDesignation> Items => new MPCProvisionalDesignation[]
        {
            default
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidNumberNameCombinations : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetWrappers.Permutate(ValidMPCSequentialNumbers.Items, ValidMPCNames.Items)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidNumberDesignationCombinations : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetWrappers.Permutate(ValidMPCSequentialNumbers.Items, ValidMPCProvisionalDesignations.Items)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidNumberNameDesignationCombinations : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetWrappers.Permutate(ValidMPCSequentialNumbers.Items, ValidMPCNames.Items, ValidMPCProvisionalDesignations.Items)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidNumberNameCombinations : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator()
        {
            var invalidRHS = DatasetWrappers.Permutate(ValidMPCSequentialNumbers.Items, InvalidMPCNames.Items);
            var invalidLHS = DatasetWrappers.Permutate(InvalidMPCSequentialNumbers.Items, ValidMPCNames.Items);
            var bothInvalid = DatasetWrappers.Permutate(InvalidMPCSequentialNumbers.Items, InvalidMPCNames.Items);

            var eitherInvalid = invalidRHS.Concat(invalidLHS).Concat(bothInvalid);

            return DatasetWrappers.SeparateAndWrap(eitherInvalid).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidNumberDesignationCombinations : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator()
        {
            var invalidRHS = DatasetWrappers.Permutate(ValidMPCSequentialNumbers.Items, InvalidMPCProvisionalDesignations.Items);
            var invalidLHS = DatasetWrappers.Permutate(InvalidMPCSequentialNumbers.Items, ValidMPCProvisionalDesignations.Items);
            var bothInvalid = DatasetWrappers.Permutate(InvalidMPCSequentialNumbers.Items, InvalidMPCProvisionalDesignations.Items);

            var eitherInvalid = invalidRHS.Concat(invalidLHS).Concat(bothInvalid);

            return DatasetWrappers.SeparateAndWrap(eitherInvalid).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidNumberNameDesignationCombinations : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator()
        {
            var invalidDesignations = DatasetWrappers.Permutate(ValidMPCSequentialNumbers.Items, ValidMPCNames.Items, InvalidMPCProvisionalDesignations.Items);
            var invalidNames = DatasetWrappers.Permutate(InvalidMPCSequentialNumbers.Items, ValidMPCNames.Items, ValidMPCProvisionalDesignations.Items);
            var invalidNumbers = DatasetWrappers.Permutate(InvalidMPCSequentialNumbers.Items, ValidMPCNames.Items, ValidMPCProvisionalDesignations.Items);
            var invalidDesignationsAndNames = DatasetWrappers.Permutate(ValidMPCSequentialNumbers.Items, InvalidMPCNames.Items, InvalidMPCProvisionalDesignations.Items);
            var invalidDesignationsAndNumbers = DatasetWrappers.Permutate(InvalidMPCSequentialNumbers.Items, ValidMPCNames.Items, InvalidMPCProvisionalDesignations.Items);
            var invalidNamesAndNumbers = DatasetWrappers.Permutate(InvalidMPCSequentialNumbers.Items, InvalidMPCNames.Items, ValidMPCProvisionalDesignations.Items);
            var allInvalid = DatasetWrappers.Permutate(InvalidMPCSequentialNumbers.Items, InvalidMPCNames.Items, InvalidMPCProvisionalDesignations.Items);

            var anyInvalid = invalidDesignations.Concat(invalidNames).Concat(invalidNumbers).Concat(invalidDesignationsAndNames).Concat(invalidDesignationsAndNumbers).Concat(invalidNamesAndNumbers).Concat(allInvalid);

            return DatasetWrappers.SeparateAndWrap(anyInvalid).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
