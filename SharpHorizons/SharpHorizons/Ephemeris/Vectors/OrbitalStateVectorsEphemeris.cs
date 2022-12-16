namespace SharpHorizons.Ephemeris.Vectors;

using SharpHorizons.Ephemeris;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>Represents an <see cref="IEphemeris{TEntry}"/> of the <see cref="IOrbitalStateVectors"/> of an object.</summary>
internal sealed record class OrbitalStateVectorsEphemeris : IEphemeris<IOrbitalStateVectors>
{
    /// <summary>Constucts a <see cref="OrbitalStateVectorsEphemeris"/>, representing <paramref name="ephemeris"/>.</summary>
    /// <param name="ephemeris"><inheritdoc cref="Ephemeris" path="/summary"/></param>
    public static OrbitalStateVectorsEphemeris FromOrdered(IReadOnlyList<IOrbitalStateVectors> ephemeris) => new(ephemeris);

    /// <summary>Constucts a <see cref="OrbitalStateVectorsEphemeris"/>, representing <paramref name="ephemeris"/>.</summary>
    /// <param name="ephemeris"><inheritdoc cref="Ephemeris" path="/summary"/></param>
    public static OrbitalStateVectorsEphemeris FromUnordered(IReadOnlyList<IOrbitalStateVectors> ephemeris) => new(ephemeris.OrderBy(static (entry) => entry.Epoch.ToJulianDay().Day).ToList());

    /// <summary>The <see cref="IOrbitalStateVectors"/> of the <see cref="IEphemeris{TEntry}"/>, ordered by <see cref="IEpoch"/>.</summary>
    private IReadOnlyList<IOrbitalStateVectors> Ephemeris { get; }

    /// <inheritdoc cref="OrbitalStateVectorsEphemeris"/>
    /// <param name="ephemeris"><inheritdoc cref="Ephemeris" path="/summary"/></param>
    private OrbitalStateVectorsEphemeris(IReadOnlyList<IOrbitalStateVectors> ephemeris)
    {
        Ephemeris = ephemeris;
    }

    IOrbitalStateVectors IReadOnlyList<IOrbitalStateVectors>.this[int index] => Ephemeris[index];
    int IReadOnlyCollection<IOrbitalStateVectors>.Count => Ephemeris.Count;
    IEnumerator<IOrbitalStateVectors> IEnumerable<IOrbitalStateVectors>.GetEnumerator() => Ephemeris.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => Ephemeris.GetEnumerator();
}
