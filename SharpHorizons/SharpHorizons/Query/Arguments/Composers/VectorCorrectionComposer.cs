namespace SharpHorizons.Query.Arguments.Composers;

using SharpHorizons.Query.Vectors;

using System;
using System.Runtime.CompilerServices;

/// <inheritdoc cref="IVectorCorrectionComposer"/>
internal sealed class VectorCorrectionComposer : IVectorCorrectionComposer
{
    IVectorCorrectionArgument IArgumentComposer<IVectorCorrectionArgument, VectorCorrection>.Compose(VectorCorrection obj)
    {
        ValidateNotJustAberration(obj);

        return new QueryArgument(obj switch
        {
            VectorCorrection.None => "NONE",
            VectorCorrection.LightTime => "LT",
            VectorCorrection.All => "LT+S",
            _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
        });
    }

    /// <summary>Validates that the <see cref="VectorCorrection"/> <paramref name="correction"/> does not represent <paramref name="correction"/>, and throws an <see cref="ArgumentException"/> if that is the case.</summary>
    /// <param name="correction">This <see cref="VectorCorrection"/> is validated not to represent <see cref="VectorCorrection.Aberration"/>.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="correction"/>.</param>
    /// <exception cref="ArgumentException"/>
    private static void ValidateNotJustAberration(VectorCorrection correction, [CallerArgumentExpression(nameof(correction))] string? argumentExpression = null)
    {
        try
        {
            UnsupportedVectorCorrectionException.ThrowIfJustAberration(correction);
        }
        catch (UnsupportedVectorCorrectionException e)
        {
            throw ArgumentExceptionFactory.InvalidState<VectorCorrection>(argumentExpression, e);
        }
    }
}
