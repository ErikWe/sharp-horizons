namespace SharpHorizons.Tests.QueryCases.VectorsCases.TableCases.IVectorTableQuantitiesValidatorCases;

using SharpHorizons.Query.Vectors.Table;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    public class SupportedVectorTableQuantities : IEnumerable<object?[]>
    {
        public static IEnumerable<VectorTableQuantities> Items => new VectorTableQuantities[]
        {
            VectorTableQuantities.Position,
            VectorTableQuantities.Velocity,
            VectorTableQuantities.Distance,
            VectorTableQuantities.Position | VectorTableQuantities.Distance,
            VectorTableQuantities.StateVectors,
            VectorTableQuantities.All
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class UnsupportedVectorTableQuantities : IEnumerable<object?[]>
    {
        public static IEnumerable<VectorTableQuantities> Items => new VectorTableQuantities[]
        {
            VectorTableQuantities.Velocity | VectorTableQuantities.Distance
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidVectorTableQuantities : IEnumerable<object?[]>
    {
        public static IEnumerable<VectorTableQuantities> Items => new VectorTableQuantities[]
        {
            (VectorTableQuantities)(-1),
            (VectorTableQuantities)8
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
