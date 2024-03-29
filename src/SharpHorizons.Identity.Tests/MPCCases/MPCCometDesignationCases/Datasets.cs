﻿namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometDesignationCases;

using SharpHorizons.MPC;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

internal static class Datasets
{
    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidMPCCometDesignationStrings : IEnumerable<object?[]>
    {
        public static IEnumerable<string> Items => new string[]
        {
            "1P",
            "1P/1682 Q1",
            "P/2011 FR143",
            "C/-146 P1",
            "C/1882 R1-A",
            "C/1997 BA6",
            "C/1998 K17",
            "C/1999 XS87",
            "C/2001 OG108",
            "C/2001 OG10812837",
            "C/2001 O10812837",
            "D/1766 G1",
            "D/1993 F2-P1",
            "A/2017 U1",
            "1I",
            "1I/2017 U1"
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class InvalidMPCCometDesignationStrings : IEnumerable<object?[]>
    {
        public static IEnumerable<string> Items => new string[]
        {
            string.Empty,
            " ",
            "  "
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidMPCCometDesignations : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCCometDesignation> Items
        {
            get
            {
                foreach (var designation in ValidMPCCometDesignationStrings.Items)
                {
                    yield return new(designation);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class InvalidMPCCometDesignations : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCCometDesignation> Items => new MPCCometDesignation[]
        {
            default
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
