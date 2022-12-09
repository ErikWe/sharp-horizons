namespace SharpHorizons.Ephemeris.Vectors;

using SharpHorizons.Ephemeris;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <inheritdoc cref="IOrbitalStateVectorsEphemeris"/>
internal sealed record class OrbitalStateVectorsEphemeris : IOrbitalStateVectorsEphemeris
{
    /// <summary>Constucts a <see cref="OrbitalStateVectorsEphemeris"/>, representing <paramref name="orbitalStateVectors"/>.</summary>
    /// <param name="orbitalStateVectors"><inheritdoc cref="OrbitalStateVectors" path="/summary"/></param>
    public static OrbitalStateVectorsEphemeris FromOrdered(IReadOnlyList<IOrbitalStateVectors> orbitalStateVectors) => new(orbitalStateVectors);

    /// <summary>Constucts a <see cref="OrbitalStateVectorsEphemeris"/>, representing <paramref name="orbitalStateVectors"/>.</summary>
    /// <param name="orbitalStateVectors"><inheritdoc cref="OrbitalStateVectors" path="/summary"/></param>
    public static OrbitalStateVectorsEphemeris FromUnordered(IReadOnlyList<IOrbitalStateVectors> orbitalStateVectors) => new(orbitalStateVectors.OrderBy(static (entry) => entry.Epoch.ToJulianDay().Day).ToList());

    /// <summary>The <see cref="IOrbitalStateVectors"/> of the <see cref="IEphemeris{TEntry}"/>, ordered by <see cref="IEpoch"/>.</summary>
    private IReadOnlyList<IOrbitalStateVectors> OrbitalStateVectors { get; }

    /// <inheritdoc cref="OrbitalStateVectorsEphemeris"/>
    /// <param name="orbitalStateVectors"><inheritdoc cref="OrbitalStateVectors" path="/summary"/></param>
    private OrbitalStateVectorsEphemeris(IReadOnlyList<IOrbitalStateVectors> orbitalStateVectors)
    {
        OrbitalStateVectors = orbitalStateVectors;
    }

    IOrbitalStateVectors IReadOnlyList<IOrbitalStateVectors>.this[int index] => OrbitalStateVectors[index];
    int IReadOnlyCollection<IOrbitalStateVectors>.Count => OrbitalStateVectors.Count;
    IEnumerator<IOrbitalStateVectors> IEnumerable<IOrbitalStateVectors>.GetEnumerator() => OrbitalStateVectors.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => OrbitalStateVectors.GetEnumerator();
}
