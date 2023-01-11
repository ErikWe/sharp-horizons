namespace SharpHorizons.Query.Arguments;

using SharpHorizons.Query.Target;

using System;

/// <summary>Represents an <see cref="Exception"/> caused by attempting to compose <see cref="QueryCommand.Ephemeris"/> as a <see cref="ICommandArgument"/>.</summary>
public sealed class EphemerisQueryCommandException : Exception
{
    /// <inheritdoc cref="EphemerisQueryCommandException"/>
    public EphemerisQueryCommandException() : this((Exception?)null) { }

    /// <inheritdoc cref="EphemerisQueryCommandException"/>
    /// <param name="message">The message that describes the <see cref="EphemerisQueryCommandException"/>.</param>
    public EphemerisQueryCommandException(string? message) : this(message, null) { }

    /// <inheritdoc cref="EphemerisQueryCommandException"/>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="EphemerisQueryCommandException"/>.</param>
    public EphemerisQueryCommandException(Exception? innerException) : this($"A {nameof(ICommandArgument)} cannot describe {QueryCommand.Ephemeris}. Instead compose a {nameof(ICommandArgument)} using the {nameof(ITarget)} object.", innerException) { }

    /// <inheritdoc cref="EphemerisQueryCommandException"/>
    /// <param name="message">The message that describes the <see cref="EphemerisQueryCommandException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="EphemerisQueryCommandException"/>.</param>
    public EphemerisQueryCommandException(string? message, Exception? innerException) : base(message, innerException) { }

    /// <summary>Throws an <see cref="EphemerisQueryCommandException"/> if <paramref name="command"/> represents <see cref="QueryCommand.Ephemeris"/>.</summary>
    /// <param name="command"><inheritdoc cref="QueryCommand" path="/summary"/></param>
    /// <exception cref="EphemerisQueryCommandException"/>
    public static void ThrowIfEphemeris(QueryCommand command)
    {
        if (command is QueryCommand.Ephemeris)
        {
            throw new EphemerisQueryCommandException();
        }
    }
}
