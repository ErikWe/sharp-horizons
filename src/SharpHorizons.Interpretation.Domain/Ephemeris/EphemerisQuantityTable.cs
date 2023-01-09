namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Ephemeris;
using SharpHorizons.Query.Result;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents the <see cref="EphemerisQuantityIdentifier"/> present in the <see cref="QueryResult"/> of an ephemeris query, indexed by their <see cref="EphemerisQuantityTableIndex"/>.</summary>
public sealed record class EphemerisQuantityTable : IEnumerable<KeyValuePair<EphemerisQuantityTableIndex, EphemerisQuantityIdentifier>>
{
    /// <summary>The <see cref="EphemerisQuantityIdentifier"/> present in the <see cref="QueryResult"/> of an ephemeris query, indexed by their <see cref="EphemerisQuantityTableIndex"/>.</summary>
    private IReadOnlyDictionary<EphemerisQuantityTableIndex, EphemerisQuantityIdentifier> Identifiers { get; }

    /// <summary>The number of rows per <see cref="IEphemerisEntry"/>.</summary>
    public int RowCount { get; }

    /// <inheritdoc cref="EphemerisQuantityTable"/>
    /// <param name="quantities"><inheritdoc cref="Identifiers" path="/summary"/></param>
    /// <param name="rowCount"><inheritdoc cref="RowCount" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public EphemerisQuantityTable(IReadOnlyDictionary<EphemerisQuantityTableIndex, EphemerisQuantityIdentifier> quantities, int rowCount)
    {
        ArgumentNullException.ThrowIfNull(quantities);

        if (rowCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(rowCount), rowCount, $"A value greater than 0 should be used to describe the {nameof(RowCount)} of a {nameof(EphemerisQuantityTable)}.");
        }

        Identifiers = quantities;
        RowCount = rowCount;
    }

    /// <summary>Determines whether the <see cref="EphemerisQuantityTable"/> contains an <see cref="EphemerisQuantityIdentifier"/> with <see cref="EphemerisQuantityTableIndex"/> <paramref name="key"/>.</summary>
    public bool ContainsKey(EphemerisQuantityTableIndex key) => Identifiers.ContainsKey(key);

    /// <summary>Attempts to retrieve the <see cref="EphemerisQuantityIdentifier"/> with <see cref="EphemerisQuantityTableIndex"/> <paramref name="key"/>.</summary>
    /// <param name="key">The <see cref="EphemerisQuantityTableIndex"/> of the retrieved <see cref="EphemerisQuantityIdentifier"/>, if one exists.</param>
    /// <param name="value">Represents the retrieved <see cref="EphemerisQuantityIdentifier"/>, or <see langword="null"/> if no <see cref="EphemerisQuantityIdentifier"/> could be identified.</param>
    public bool TryGetValue(EphemerisQuantityTableIndex key, [NotNullWhen(true)] out EphemerisQuantityIdentifier? value)
    {
        var success = Identifiers.TryGetValue(key, out var definiteValue);

        if (success is false)
        {
            value = null;

            return false;
        }

        value = definiteValue;

        return true;
    }

    /// <inheritdoc/>
    public IEnumerator<KeyValuePair<EphemerisQuantityTableIndex, EphemerisQuantityIdentifier>> GetEnumerator() => Identifiers.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
