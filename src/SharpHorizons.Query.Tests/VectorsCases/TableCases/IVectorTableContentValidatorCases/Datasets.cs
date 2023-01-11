namespace SharpHorizons.Tests.QueryCases.VectorsCases.TableCases.IVectorTableContentValidatorCases;

using SharpHorizons.Query.Vectors.Table;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

internal static class Datasets
{
    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class SupportedVectorTableContent : IEnumerable<object?[]>
    {
        public static IEnumerable<VectorTableContent> Items => new VectorTableContent[]
        {
            new(VectorTableQuantities.Position, VectorTableUncertainties.None),
            new(VectorTableQuantities.Position, VectorTableUncertainties.XYZ),
            new(VectorTableQuantities.Position, VectorTableUncertainties.XYZ | VectorTableUncertainties.ACN),
            new(VectorTableQuantities.StateVectors, VectorTableUncertainties.None),
            new(VectorTableQuantities.StateVectors, VectorTableUncertainties.XYZ),
            new(VectorTableQuantities.StateVectors, VectorTableUncertainties.XYZ | VectorTableUncertainties.ACN),
            new(VectorTableQuantities.Velocity, VectorTableUncertainties.None),
            new(VectorTableQuantities.Distance, VectorTableUncertainties.None),
            new(VectorTableQuantities.Position | VectorTableQuantities.Distance, VectorTableUncertainties.None),
            new(VectorTableQuantities.All, VectorTableUncertainties.None)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UnsupportedVectorTableContent : IEnumerable<object?[]>
    {
        public static IEnumerable<VectorTableContent> Items => new VectorTableContent[]
        {
            new(VectorTableQuantities.Velocity, VectorTableUncertainties.XYZ),
            new(VectorTableQuantities.Distance, VectorTableUncertainties.XYZ),
            new(VectorTableQuantities.Position | VectorTableQuantities.Distance, VectorTableUncertainties.XYZ),
            new(VectorTableQuantities.All, VectorTableUncertainties.XYZ)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
