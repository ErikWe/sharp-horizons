namespace SharpHorizons.Interpretation.Ephemeris;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents the (<see cref="int"/> row, <see cref="int"/> column) index associated with an <see cref="EphemerisQuantityIdentifier"/>.</summary>
public readonly record struct EphemerisQuantityTableIndex
{
    /// <summary>The <see cref="int"/> row associated with the <see cref="EphemerisQuantityIdentifier"/>.</summary>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public required int Row
    {
        get => rowField;
        init
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"A positive value should be used to describe the {nameof(Row)} of an {nameof(EphemerisQuantityTableIndex)}.");
            }

            rowField = value;
        }
    }

    /// <summary>The <see cref="int"/> column associated with the <see cref="EphemerisQuantityIdentifier"/>.</summary>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public required int Column
    {
        get => columnField;
        init
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"A positive value should be used to describe the {nameof(Column)} of an {nameof(EphemerisQuantityTableIndex)}.");
            }

            columnField = value;
        }
    }

    /// <inheritdoc cref="EphemerisQuantityTableIndex"/>
    public EphemerisQuantityTableIndex() { }

    /// <inheritdoc cref="EphemerisQuantityTableIndex"/>
    /// <param name="row"><inheritdoc cref="Row" path="/summary"/></param>
    /// <param name="column"><inheritdoc cref="Column" path="/summary"/></param>
    /// <exception cref="ArgumentOutOfRangeException"/>
    [SetsRequiredMembers]
    public EphemerisQuantityTableIndex(int row, int column)
    {
        Row = row;
        Column = column;
    }

    /// <summary>Backing field for <see cref="Row"/>. Should not be used elsewhere.</summary>
    private readonly int rowField;
    /// <summary>Backing field for <see cref="Column"/>. Should not be used elsewhere.</summary>
    private readonly int columnField;
}
