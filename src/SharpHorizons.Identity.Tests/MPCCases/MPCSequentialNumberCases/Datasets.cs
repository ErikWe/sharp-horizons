﻿namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCSequentialNumberCases;

using SharpHorizons.MPC;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

internal static class Datasets
{
    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidMPCSequentialNumberInt32s : IEnumerable<object?[]>
    {
        public static IEnumerable<int> Items => new int[]
        {
            int.MaxValue,
            1
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class InvalidMPCSequentialNumberInt32s : IEnumerable<object?[]>
    {
        public static IEnumerable<int> Items => new int[]
        {
            int.MinValue,
            0,
            -1
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidMPCSequentialNumbers : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCSequentialNumber> Items
        {
            get
            {
                foreach (var number in ValidMPCSequentialNumberInt32s.Items)
                {
                    yield return new(number);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class InvalidMPCSequentialNumbers : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCSequentialNumber> Items => new MPCSequentialNumber[]
        {
            default
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
