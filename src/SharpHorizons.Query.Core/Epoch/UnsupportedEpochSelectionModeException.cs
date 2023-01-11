namespace SharpHorizons.Query.Epoch;

using System;

/// <summary>Represents an <see cref="Exception"/> relating to an unsupported <see cref="EpochSelectionMode"/>.</summary>
public sealed class UnsupportedEpochSelectionModeException : Exception
{
    /// <inheritdoc cref="UnsupportedEpochSelectionModeException"/>
    public UnsupportedEpochSelectionModeException() : this((Exception?)null) { }

    /// <inheritdoc cref="UnsupportedEpochSelectionModeException"/>
    /// <param name="message">The message that describes the <see cref="UnsupportedEpochSelectionModeException"/>.</param>
    public UnsupportedEpochSelectionModeException(string? message) : this(message, null) { }

    /// <inheritdoc cref="UnsupportedEpochSelectionModeException"/>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnsupportedEpochSelectionModeException"/>.</param>
    public UnsupportedEpochSelectionModeException(Exception? innerException) : this($"The {nameof(IEpochSelection)} was not performed according to the the expected {nameof(EpochSelectionMode)}.", innerException) { }

    /// <inheritdoc cref="UnsupportedEpochSelectionModeException"/>
    /// <param name="message">The message that describes the <see cref="UnsupportedEpochSelectionModeException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnsupportedEpochSelectionModeException"/>.</param>
    public UnsupportedEpochSelectionModeException(string? message, Exception? innerException) : base(message, innerException) { }

    /// <inheritdoc cref="UnsupportedEpochSelectionModeException"/>
    /// <param name="expectedMode">The expected <see cref="EpochSelectionMode"/>.</param>
    private UnsupportedEpochSelectionModeException(EpochSelectionMode expectedMode) : this(expectedMode, null) { }

    /// <inheritdoc cref="UnsupportedEpochSelectionModeException"/>
    /// <param name="expectedMode">The expected <see cref="EpochSelectionMode"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnsupportedEpochSelectionModeException"/>.</param>
    private UnsupportedEpochSelectionModeException(EpochSelectionMode expectedMode, Exception? innerException) : this($"The {nameof(IEpochSelection)} was not performed according to {nameof(EpochSelectionMode)}.{expectedMode}.", innerException) { }

    /// <summary>Represents an <see cref="Exception"/> relating to a <see cref="IEpochSelection"/> that does not support <see cref="EpochSelectionMode.Collection"/>.</summary>
    public static UnsupportedEpochSelectionModeException EpochSelectionNotCollection() => EpochSelectionNotCollection(null);

    /// <summary>Represents an <see cref="Exception"/> relating to a <see cref="IEpochSelection"/> that does not support <see cref="EpochSelectionMode.Collection"/>.</summary>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnsupportedEpochSelectionModeException"/>.</param>
    public static UnsupportedEpochSelectionModeException EpochSelectionNotCollection(Exception? innerException) => new(EpochSelectionMode.Collection, innerException);

    /// <summary>Represents an <see cref="Exception"/> relating to a <see cref="IEpochSelection"/> that does not support <see cref="EpochSelectionMode.Range"/>.</summary>
    public static UnsupportedEpochSelectionModeException EpochSelectionNotRange() => EpochSelectionNotRange(null);

    /// <summary>Represents an <see cref="Exception"/> relating to a <see cref="IEpochSelection"/> that does not support <see cref="EpochSelectionMode.Range"/>.</summary>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="UnsupportedEpochSelectionModeException"/>.</param>
    public static UnsupportedEpochSelectionModeException EpochSelectionNotRange(Exception? innerException) => new(EpochSelectionMode.Range, innerException);
}
