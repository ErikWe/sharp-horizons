namespace SharpHorizons.Query.Arguments.Composers;

using System.ComponentModel;

/// <summary>Composes <see cref="ICommandArgument"/> that describe <see cref="QueryCommand"/>.</summary>
internal sealed class QueryCommandComposer : ICommandComposer<QueryCommand>
{
    ICommandArgument IArgumentComposer<ICommandArgument, QueryCommand>.Compose(QueryCommand obj) => new QueryArgument(obj switch
    {
        QueryCommand.Ephemerides => throw new ComposeEphemeridesQueryCommandException(),
        QueryCommand.MajorBodyList => "MB",
        QueryCommand.News => "NEWS",
        _ => throw new InvalidEnumArgumentException(nameof(obj), (int)obj, typeof(QueryCommand))
    });
}
