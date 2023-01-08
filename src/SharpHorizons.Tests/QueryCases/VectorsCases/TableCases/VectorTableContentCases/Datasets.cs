namespace SharpHorizons.Tests.QueryCases.VectorsCases.TableCases.VectorTableContentCases;

using SharpHorizons.Query.Vectors.Table;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

internal static class Datasets
{
    public class ValidVectorTableQuantities : IEnumerable<object?[]>
    {
        public static IEnumerable<VectorTableQuantities> Items
        {
            get
            {
                for (var i = 0; i < 8; i++)
                {
                    yield return (VectorTableQuantities)i;
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidVectorTableQuantities : IEnumerable<object?[]>
    {
        public static IEnumerable<VectorTableQuantities> Items => new VectorTableQuantities[]
        {
            (VectorTableQuantities)(-1),
            (VectorTableQuantities)8,
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidVectorTableUncertainties : IEnumerable<object?[]>
    {
        public static IEnumerable<VectorTableUncertainties> Items
        {
            get
            {
                for (var i = 0; i < 16; i++)
                {
                    yield return (VectorTableUncertainties)i;
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidVectorTableUncertainties : IEnumerable<object?[]>
    {
        public static IEnumerable<VectorTableUncertainties> Items => new VectorTableUncertainties[]
        {
            (VectorTableUncertainties)(-1),
            (VectorTableUncertainties)16,
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidCombinations : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetWrappers.Permutate(ValidVectorTableQuantities.Items, ValidVectorTableUncertainties.Items)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidCombinations : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator()
        {
            var invalidRHS = DatasetWrappers.Permutate(ValidVectorTableQuantities.Items, InvalidVectorTableUncertainties.Items);
            var invalidLHS = DatasetWrappers.Permutate(InvalidVectorTableQuantities.Items, ValidVectorTableUncertainties.Items);
            var bothInvalid = DatasetWrappers.Permutate(InvalidVectorTableQuantities.Items, InvalidVectorTableUncertainties.Items);

            var eitherInvalid = invalidRHS.Concat(invalidLHS).Concat(bothInvalid);

            return DatasetWrappers.SeparateAndWrap(eitherInvalid).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
