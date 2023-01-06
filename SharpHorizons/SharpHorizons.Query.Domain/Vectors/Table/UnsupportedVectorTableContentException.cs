namespace SharpHorizons.Query.Vectors.Table;

using System;

/// <summary>Represents an <see cref="Exception"/> that occurred when attempting to apply an unsupported <see cref="VectorTableContent"/>.</summary>
public sealed class UnsupportedVectorTableContentException : Exception
{
    /// <inheritdoc cref="UnsupportedVectorTableContentException"/>
    /// <param name="message">The message that describes the <see cref="UnsupportedVectorTableContentException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnsupportedVectorTableContentException"/>.</param>
    public UnsupportedVectorTableContentException(string? message, Exception? innerException = null) : base(message, innerException) { }
}
