namespace SharpHorizons.Query.Arguments.Composers;

using SharpHorizons.Query.Target;

using System;

/// <summary>Represents an error caused by attempting to compose <see cref="QueryCommand.Ephemerides"/> as a <see cref="ICommandArgument"/>.</summary>
public sealed class ComposeEphemeridesQueryCommandException : Exception
{
    /// <inheritdoc cref="ComposeEphemeridesQueryCommandException"/>
    public ComposeEphemeridesQueryCommandException() : base($"{QueryCommand.Ephemerides} cannot be used to compose a {typeof(ICommandArgument).FullName}. Instead use the {typeof(ITarget).FullName}.") { }

    /// <inheritdoc cref="ComposeEphemeridesQueryCommandException"/>
    /// <param name="message">The message that describes the error.</param>
    public ComposeEphemeridesQueryCommandException(string? message) : base(message) { }

    /// <inheritdoc cref="ComposeEphemeridesQueryCommandException"/>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current exception.</param>
    public ComposeEphemeridesQueryCommandException(string? message, Exception? innerException) : base(message, innerException) { }
}
