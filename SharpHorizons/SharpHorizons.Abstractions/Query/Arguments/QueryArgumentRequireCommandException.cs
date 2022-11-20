namespace SharpHorizons.Query.Arguments;

using System;

/// <summary>Represents an error caused by attempting to finalize a <see cref="IQueryArgumentSetBuilder"/> without specifying a <see cref="ICommandArgument"/>.</summary>
public sealed class QueryArgumentRequireCommandException : Exception
{
    /// <inheritdoc cref="QueryArgumentRequireCommandException"/>
    public QueryArgumentRequireCommandException() : base($"The {typeof(ICommandArgument).Name} was never specified by the {typeof(IQueryArgumentSetBuilder).Name}.") { }

    /// <inheritdoc cref="QueryArgumentRequireCommandException"/>
    /// <param name="message">The message that describes the error.</param>
    public QueryArgumentRequireCommandException(string? message) : base(message) { }

    /// <inheritdoc cref="QueryArgumentRequireCommandException"/>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current exception.</param>
    public QueryArgumentRequireCommandException(string? message, Exception? innerException) : base(message, innerException) { }
}
