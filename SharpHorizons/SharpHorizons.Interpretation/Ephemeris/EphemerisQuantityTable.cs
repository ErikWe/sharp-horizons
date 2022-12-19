namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Ephemeris;
using SharpHorizons.Query.Result;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents the <see cref="EphemerisQuantityIdentifier"/> present in the <see cref="QueryResult"/> of an ephemeris query, by their <see cref="EphemerisQuantityTableIndex"/>.</summary>
public sealed record class EphemerisQuantityTable : IReadOnlyDictionary<EphemerisQuantityTableIndex, EphemerisQuantityIdentifier>
{
    /// <summary>The <see cref="EphemerisQuantityIdentifier"/> present in the <see cref="QueryResult"/> of an ephemeris query, by their <see cref="EphemerisQuantityTableIndex"/>.</summary>
    /// <exception cref="ArgumentNullException"/>
    public required IReadOnlyDictionary<EphemerisQuantityTableIndex, EphemerisQuantityIdentifier> Identifiers
    {
        private get => identifiersField;
        init
        {
            ArgumentNullException.ThrowIfNull(value);

            identifiersField = value;
        }
    }

    /// <summary>The number of rows per <see cref="IEphemerisEntry"/>.</summary>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public required int RowCount
    {
        get => rowCountField;
        init
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"A value greater than 0 should be used to describe the {nameof(RowCount)} of a {nameof(EphemerisQuantityTable)}.");
            }

            rowCountField = value;
        }
    }

    /// <inheritdoc/>
    public IEnumerable<EphemerisQuantityTableIndex> Keys => Identifiers.Keys;

    /// <inheritdoc/>
    public IEnumerable<EphemerisQuantityIdentifier> Values => Identifiers.Values;

    /// <inheritdoc/>
    public int Count => Identifiers.Count;

    /// <inheritdoc/>
    public EphemerisQuantityIdentifier this[EphemerisQuantityTableIndex key] => Identifiers[key];

    /// <inheritdoc cref="EphemerisQuantityTable"/>
    public EphemerisQuantityTable() { }

    /// <inheritdoc cref="EphemerisQuantityTable"/>
    /// <param name="quantities"><inheritdoc cref="Identifiers" path="/summary"/></param>
    /// <param name="rowCount"><inheritdoc cref="RowCount" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    [SetsRequiredMembers]
    public EphemerisQuantityTable(IReadOnlyDictionary<EphemerisQuantityTableIndex, EphemerisQuantityIdentifier> quantities, int rowCount)
    {
        Identifiers = quantities;
        RowCount = rowCount;
    }

    /// <summary>Backing field for <see cref="Identifiers"/>. Should not be used elsewhere.</summary>
    private IReadOnlyDictionary<EphemerisQuantityTableIndex, EphemerisQuantityIdentifier> identifiersField = null!;
    /// <summary>Backing field for <see cref="RowCount"/>. Should not be used elsewhere.</summary>
    private readonly int rowCountField;

    /// <inheritdoc/>
    public bool ContainsKey(EphemerisQuantityTableIndex key) => Identifiers.ContainsKey(key);

    /// <inheritdoc/>
    public bool TryGetValue(EphemerisQuantityTableIndex key, [MaybeNullWhen(false)] out EphemerisQuantityIdentifier value) => Identifiers.TryGetValue(key, out value);

    /// <inheritdoc/>
    public IEnumerator<KeyValuePair<EphemerisQuantityTableIndex, EphemerisQuantityIdentifier>> GetEnumerator() => Identifiers.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
