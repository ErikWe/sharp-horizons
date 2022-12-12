namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Ephemeris;
using SharpHorizons.Query.Result;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents the <see cref="string"/> names of the quantities present in the <see cref="IQueryResult"/> of an ephemeris query, by their (<see cref="int"/> column, <see cref="int"/> row).</summary>
public sealed record class EphemerisQuantities : IReadOnlyDictionary<(int, int), string>
{
    /// <summary>The <see cref="string"/> names of the quantities present in the <see cref="IQueryResult"/> of an ephemeris query, by their (<see cref="int"/> column, <see cref="int"/> row).</summary>
    public required IReadOnlyDictionary<(int, int), string> Quantities { private get; init; }

    /// <summary>The number of rows per <see cref="IEphemerisEntry"/>.</summary>
    public required int RowCount { get; init; }

    /// <inheritdoc/>
    public IEnumerable<(int, int)> Keys => Quantities.Keys;

    /// <inheritdoc/>
    public IEnumerable<string> Values => Quantities.Values;

    /// <inheritdoc/>
    public int Count => Quantities.Count;

    /// <inheritdoc/>
    public string this[(int, int) key] => Quantities[key];

    /// <inheritdoc cref="EphemerisQuantities"/>
    public EphemerisQuantities() { }

    /// <inheritdoc cref="EphemerisQuantities"/>
    /// <param name="quantities"><inheritdoc cref="Quantities" path="/summary"/></param>
    /// <param name="rowCount"><inheritdoc cref="RowCount" path="/summary"/></param>
    [SetsRequiredMembers]
    public EphemerisQuantities(IReadOnlyDictionary<(int, int), string> quantities, int rowCount)
    {
        Quantities = quantities;
        RowCount = rowCount;
    }

    /// <inheritdoc/>
    public bool ContainsKey((int, int) key) => Quantities.ContainsKey(key);

    /// <inheritdoc/>
    public bool TryGetValue((int, int) key, [MaybeNullWhen(false)] out string value) => Quantities.TryGetValue(key, out value);

    /// <inheritdoc/>
    public IEnumerator<KeyValuePair<(int, int), string>> GetEnumerator() => Quantities.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
