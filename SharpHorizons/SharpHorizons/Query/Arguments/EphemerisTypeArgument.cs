namespace SharpHorizons.Query.Arguments;

using System.ComponentModel;

/// <inheritdoc cref="IEphemerisTypeArgument"/>
internal sealed record class EphemerisTypeArgument : IEphemerisTypeArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="EphemerisTypeArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    private EphemerisTypeArgument(QueryArgument value)
    {
        Value = value;
    }

    /// <summary>Composes an <see cref="IEphemerisTypeArgument"/> describing <paramref name="ephemerisType"/>.</summary>
    /// <param name="ephemerisType">An <see cref="IEphemerisTypeArgument"/> is composed based on this <see cref="EphemerisType"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public static IEphemerisTypeArgument Compose(EphemerisType ephemerisType) => new EphemerisTypeArgument(ephemerisType switch
    {
        EphemerisType.Observables => "O",
        EphemerisType.Vectors => "V",
        EphemerisType.Elements => "E",
        EphemerisType.CloseApproach => "A",
        _ => throw new InvalidEnumArgumentException(nameof(ephemerisType), (int)ephemerisType, typeof(EphemerisType))
    });
}