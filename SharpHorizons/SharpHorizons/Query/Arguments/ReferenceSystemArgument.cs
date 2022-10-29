namespace SharpHorizons.Query.Arguments;

using System.ComponentModel;

/// <inheritdoc cref="IReferenceSystemArgument"/>
internal sealed record class ReferenceSystemArgument : IReferenceSystemArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="ReferenceSystemArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    private ReferenceSystemArgument(QueryArgument value)
    {
        Value = value;
    }

    /// <summary>Composes a <see cref="IReferenceSystemArgument"/> describing <paramref name="referenceSystem"/>.</summary>
    /// <param name="referenceSystem">A <see cref="IReferenceSystemArgument"/> is composed based on this <see cref="ReferenceSystem"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public static IReferenceSystemArgument Compose(ReferenceSystem referenceSystem) => new ReferenceSystemArgument(referenceSystem switch
    {
        ReferenceSystem.ICRF => "ICRF",
        ReferenceSystem.B1950 => "B1950",
        _ => throw new InvalidEnumArgumentException(nameof(referenceSystem), (int)referenceSystem, typeof(ReferenceSystem))
    });
}