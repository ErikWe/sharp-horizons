namespace SharpHorizons.Query.Vectors.Table;

using System;

/// <summary>Represents an <see cref="Exception"/> that occurred when attempting to apply an unsupported <see cref="VectorTableQuantities"/>.</summary>
public sealed class UnsupportedVectorTableQuantitiesException : Exception
{
    /// <inheritdoc cref="UnsupportedVectorTableQuantitiesException"/>
    /// <param name="message">The message that describes the <see cref="UnsupportedVectorTableQuantitiesException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnsupportedVectorTableQuantitiesException"/>.</param>
    public UnsupportedVectorTableQuantitiesException(string? message, Exception? innerException = null) : base(message, innerException) { }
}
