namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCProvisionalObjectCases;

using SharpHorizons.MPC;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
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

    public class InvalidMPCProvisionalDesignation : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCProvisionalDesignation> Items => new MPCProvisionalDesignation[]
        {
            default
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
