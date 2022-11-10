namespace SharpHorizons.Query.Arguments.Composers;

using SharpHorizons.Query;
using SharpHorizons.Query.Arguments;
using System.ComponentModel;

/// <inheritdoc cref="IVectorCorrectionComposer"/>
internal sealed class VectorCorrectionComposer : IVectorCorrectionComposer
{
    IVectorCorrectionArgument IArgumentComposer<IVectorCorrectionArgument, VectorCorrection>.Compose(VectorCorrection obj) => new QueryArgument(obj switch
    {
        VectorCorrection.None => "NONE",
        VectorCorrection.LightTime => "LT",
        VectorCorrection.LightTimeAndAberration => "LT+S",
        _ => throw new InvalidEnumArgumentException(nameof(obj), (int)obj, typeof(VectorCorrection))
    });
}
