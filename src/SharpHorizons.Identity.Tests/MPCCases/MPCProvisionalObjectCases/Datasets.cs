namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCProvisionalObjectCases;

using SharpHorizons.MPC;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

internal static class Datasets
{
    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidMPCProvisionalDesignations : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCProvisionalDesignation> Items => new MPCProvisionalDesignation[]
        {
            new("A801 AA"),
            new("A807 FA")
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class InvalidMPCProvisionalDesignation : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCProvisionalDesignation> Items => new MPCProvisionalDesignation[]
        {
            default
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
