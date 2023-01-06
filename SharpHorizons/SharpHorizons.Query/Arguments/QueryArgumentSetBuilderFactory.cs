namespace SharpHorizons.Query.Arguments;

using System;

/// <inheritdoc cref="IQueryArgumentSetFactory"/>
internal sealed class QueryArgumentSetBuilderFactory : IQueryArgumentSetFactory
{
    IQueryArgumentSetBuilder IQueryArgumentSetFactory.CreateBuilder(ICommandArgument command)
    {
        QueryArgument.Validate(command);

        return new QueryArgumentSetBuilder(command);
    }

    IQueryArgumentSetBuilder IQueryArgumentSetFactory.CreateBuilder(IQueryArgumentSet argumentSet)
    {
        ArgumentNullException.ThrowIfNull(argumentSet);

        try
        {
            QueryArgument.Validate(argumentSet.Command);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<IQueryArgumentSet>(nameof(argumentSet), e);
        }

        return new QueryArgumentSetBuilder(argumentSet);
    }
}
