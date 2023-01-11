namespace SharpHorizons.Query.Vectors;

using System;

/// <summary>Represents an <see cref="Exception"/> that occurred when attempting to apply an unsupported <see cref="VectorCorrection"/>.</summary>
public sealed class UnsupportedVectorCorrectionException : Exception
{
    /// <inheritdoc cref="UnsupportedVectorCorrectionException"/>
    public UnsupportedVectorCorrectionException() : this((Exception?)null) { }

    /// <inheritdoc cref="UnsupportedVectorCorrectionException"/>
    /// <param name="message">The message that describes the <see cref="UnsupportedVectorCorrectionException"/>.</param>
    public UnsupportedVectorCorrectionException(string? message) : this(message, null) { }

    /// <inheritdoc cref="UnsupportedVectorCorrectionException"/>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnsupportedVectorCorrectionException"/>.</param>
    public UnsupportedVectorCorrectionException(Exception? innerException) : this($"A {nameof(VectorCorrection)} represents a configuration not supported by Horizons.", innerException) { }

    /// <inheritdoc cref="UnsupportedVectorCorrectionException"/>
    /// <param name="message">The message that describes the <see cref="UnsupportedVectorCorrectionException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnsupportedVectorCorrectionException"/>.</param>
    public UnsupportedVectorCorrectionException(string? message, Exception? innerException) : base(message, innerException) { }
}
