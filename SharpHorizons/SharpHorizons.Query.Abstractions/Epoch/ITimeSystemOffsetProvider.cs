namespace SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;
using System.ComponentModel;

/// <summary>Provides functionality for computing the offset between different <see cref="TimeSystem"/> at some <see cref="IEpoch"/>.</summary>
public interface ITimeSystemOffsetProvider
{
    /// <summary>Computes the <see cref="Time"/> offset { <paramref name="target"/> - <paramref name="origin"/> } at <paramref name="epoch"/> (<paramref name="epoch"/> is expressed in the <see cref="TimeSystem"/> represented by <paramref name="origin"/>). The resulting <see cref="Time"/> is positive if <paramref name="target"/> is ahead of <paramref name="origin"/>.</summary>
    /// <param name="epoch">The <see cref="IEpoch"/>, expressed in the <see cref="TimeSystem"/> represented by <paramref name="origin"/>, when the <see cref="Time"/> offset between <paramref name="origin"/> and <paramref name="target"/> is computed.</param>
    /// <param name="origin">The <see cref="TimeSystem"/> in which <paramref name="epoch"/> is expressed, and the <see cref="TimeSystem"/> relative to which the <see cref="Time"/> offset of <paramref name="target"/>, at <paramref name="epoch"/>, is computed.</param>
    /// <param name="target">The <see cref="Time"/> offset of this <see cref="TimeSystem"/> relative to <paramref name="origin"/>, at <paramref name="epoch"/>, is computed.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract Time Offset(IEpoch epoch, TimeSystem origin, TimeSystem target);
}
