namespace SharpHorizons.Query;

using System;

/// <summary>Represents an error relating to an unsupported <see cref="EpochSelectionMode"/>.</summary>
public sealed class UnsupportedEpochSelectionException : Exception
{
    /// <inheritdoc cref="UnsupportedEpochSelectionException"/>
    public UnsupportedEpochSelectionException() : base($"The {typeof(IEpochSelection).FullName} was not selected according to the expected {typeof(EpochSelectionMode).FullName}.") { }

    /// <inheritdoc cref="UnsupportedEpochSelectionException"/>
    /// <param name="message">The message that describes the error.</param>
    public UnsupportedEpochSelectionException(string? message) : base(message) { }

    /// <inheritdoc cref="UnsupportedEpochSelectionException"/>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current exception.</param>
    public UnsupportedEpochSelectionException(string? message, Exception? innerException) : base(message, innerException) { }

    /// <inheritdoc cref="UnsupportedEpochSelectionException"/>
    /// <param name="expectedType">The expected <see cref="EpochSelectionMode"/>.</param>
    public UnsupportedEpochSelectionException(EpochSelectionMode expectedType) : base($"The {typeof(IEpochSelection).FullName} was not selected according to {typeof(EpochSelectionMode).FullName}.{expectedType}.") { }
}
