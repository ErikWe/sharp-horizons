namespace SharpHorizons.Query.VectorTable;

using System;

/// <summary>Represents an error caused by attempting to apply an unsupported <see cref="VectorTableContent"/>.</summary>
public sealed class UnsupportedVectorTableException : Exception
{
    /// <inheritdoc cref="UnsupportedVectorTableException"/>
    public UnsupportedVectorTableException() : base($"The {typeof(VectorTableContent).Name} does not represent a configuration supported by Horizons.") { }

    /// <inheritdoc cref="UnsupportedVectorTableException"/>
    /// <param name="message">The message that describes the error.</param>
    public UnsupportedVectorTableException(string? message) : base(message) { }

    /// <inheritdoc cref="UnsupportedVectorTableException"/>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current exception.</param>
    public UnsupportedVectorTableException(string? message, Exception? innerException) : base(message, innerException) { }
}
