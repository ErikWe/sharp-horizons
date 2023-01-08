namespace SharpHorizons.Query.Arguments.Composers;

using System;
using System.Runtime.CompilerServices;

/// <summary>Composes <see cref="ICommandArgument"/> that describe <see cref="QueryCommand"/>.</summary>
internal sealed class QueryCommandComposer : ICommandComposer<QueryCommand>
{
    ICommandArgument IArgumentComposer<ICommandArgument, QueryCommand>.Compose(QueryCommand obj)
    {
        ValidateNotEphemeris(obj);

        return new QueryArgument(obj switch
        {
            QueryCommand.Unknown => throw ArgumentExceptionFactory.UnsupportedEnumValue(obj),
            QueryCommand.MajorBodyList => "MB",
            QueryCommand.News => "NEWS",
            _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
        });
    }

    /// <summary>Validates that the <see cref="QueryCommand"/> <paramref name="command"/> does not represent <see cref="QueryCommand.Ephemeris"/>, throwing an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="command">This <see cref="QueryCommand"/> is validated not to represent <see cref="QueryCommand.Ephemeris"/>.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="command"/>.</param>
    /// <exception cref="ArgumentException"/>
    private static void ValidateNotEphemeris(QueryCommand command, [CallerArgumentExpression(nameof(command))] string? argumentExpression = null)
    {
        try
        {
            EphemerisQueryCommandException.ThrowIfEphemeris(command);
        }
        catch (EphemerisQueryCommandException e)
        {
            throw ArgumentExceptionFactory.InvalidState<QueryCommand>(argumentExpression, e);
        }
    }
}
