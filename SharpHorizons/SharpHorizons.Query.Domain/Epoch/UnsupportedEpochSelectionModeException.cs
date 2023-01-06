namespace SharpHorizons.Query.Epoch;

using System;

/// <summary>Represents an <see cref="Exception"/> relating to an unsupported <see cref="EpochSelectionMode"/>.</summary>
public sealed class UnsupportedEpochSelectionModeException : Exception
{
    /// <inheritdoc cref="UnsupportedEpochSelectionModeException"/>
    /// <param name="message">The message that describes the <see cref="UnsupportedEpochSelectionModeException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnsupportedEpochSelectionModeException"/>.</param>
    public UnsupportedEpochSelectionModeException(string? message, Exception? innerException = null) : base(message, innerException) { }

    /// <inheritdoc cref="UnsupportedEpochSelectionModeException"/>
    /// <param name="expectedType">The expected <see cref="EpochSelectionMode"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnsupportedEpochSelectionModeException"/>.</param>
    private UnsupportedEpochSelectionModeException(EpochSelectionMode expectedType, Exception? innerException = null) : base($"The {nameof(IEpochSelection)} was not performed according to {nameof(EpochSelectionMode)}.{expectedType}.", innerException) { }

    /// <summary>Represents an <see cref="Exception"/> relating to a <see cref="IEpochSelection"/> that does not support <see cref="EpochSelectionMode.Collection"/>.</summary>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnsupportedEpochSelectionModeException"/>.</param>
    public static UnsupportedEpochSelectionModeException EpochSelectionNotCollection(Exception? innerException = null) => new(EpochSelectionMode.Collection, innerException);

    /// <summary>Represents an <see cref="Exception"/> relating to a <see cref="IEpochSelection"/> that does not support <see cref="EpochSelectionMode.Range"/>.</summary>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnsupportedEpochSelectionModeException"/>.</param>
    public static UnsupportedEpochSelectionModeException EpochSelectionNotRange(Exception? innerException = null) => new(EpochSelectionMode.Range, innerException);
}
