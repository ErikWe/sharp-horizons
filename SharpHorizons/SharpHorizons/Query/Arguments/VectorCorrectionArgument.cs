namespace SharpHorizons.Query.Arguments;

using System.ComponentModel;

/// <inheritdoc cref="IVectorCorrectionArgument"/>
internal sealed record class VectorCorrectionArgument : IVectorCorrectionArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="VectorCorrectionArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    private VectorCorrectionArgument(QueryArgument value)
    {
        Value = value;
    }

    /// <summary>Composes a <see cref="IVectorCorrectionArgument"/> describing <paramref name="vectorCorrection"/>.</summary>
    /// <param name="vectorCorrection">A <see cref="IVectorCorrectionArgument"/> is composed based on this <see cref="VectorCorrection"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public static IVectorCorrectionArgument Compose(VectorCorrection vectorCorrection) => new VectorCorrectionArgument(vectorCorrection switch
    {
        VectorCorrection.None => "NONE",
        VectorCorrection.LightTime => "LT",
        VectorCorrection.LightTimeAndAberration => "LT+S",
        _ => throw new InvalidEnumArgumentException(nameof(vectorCorrection), (int)vectorCorrection, typeof(VectorCorrection))
    });
}