namespace SharpHorizons.Query.Arguments;

using System;

/// <summary>Represents an <see cref="Exception"/> that occurred when attempting to finalize a <see cref="IQueryArgumentSetBuilder"/> without specifying a <see cref="ICommandArgument"/>.</summary>
public sealed class QueryArgumentRequireCommandException : Exception
{
    /// <inheritdoc cref="QueryArgumentRequireCommandException"/>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="QueryArgumentRequireCommandException"/>.</param>
    public QueryArgumentRequireCommandException(Exception? innerException = null) : base($"The {nameof(ICommandArgument)} was never specified by the {nameof(IQueryArgumentSetBuilder)}.", innerException) { }

    /// <inheritdoc cref="QueryArgumentRequireCommandException"/>
    /// <param name="message">The message that describes the <see cref="QueryArgumentRequireCommandException"/>.</param>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="QueryArgumentRequireCommandException"/>.</param>
    public QueryArgumentRequireCommandException(string? message, Exception? innerException = null) : base(message, innerException) { }
}
