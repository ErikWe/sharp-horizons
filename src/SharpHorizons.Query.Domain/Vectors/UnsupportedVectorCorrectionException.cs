namespace SharpHorizons.Query.Vectors;

using System;

/// <summary>Represents an <see cref="Exception"/> that occurred when attempting to apply an unsupported <see cref="VectorCorrection"/>.</summary>
public sealed class UnsupportedVectorCorrectionException : Exception
{
    /// <inheritdoc cref="UnsupportedVectorCorrectionException"/>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnsupportedVectorCorrectionException"/>.</param>
    public UnsupportedVectorCorrectionException(Exception? innerException = null) : base($"Applying the {nameof(VectorCorrection)} \"{VectorCorrection.Aberration}\" without also applying \"{VectorCorrection.LightTime}\" is not supported.", innerException) { }

    /// <summary>Throws an <see cref="UnsupportedVectorCorrectionException"/> if <paramref name="correction"/> represents <see cref="VectorCorrection.Aberration"/>.</summary>
    /// <param name="correction"><inheritdoc cref="VectorCorrection" path="/summary"/></param>
    /// <exception cref="UnsupportedVectorCorrectionException"/>
    public static void ThrowIfJustAberration(VectorCorrection correction)
    {
        if (correction is VectorCorrection.Aberration)
        {
            throw new UnsupportedVectorCorrectionException();
        }
    }
}
