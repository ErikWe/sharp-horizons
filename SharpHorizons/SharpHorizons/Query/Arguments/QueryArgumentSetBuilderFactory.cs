namespace SharpHorizons.Query.Arguments;

/// <inheritdoc cref="IQueryArgumentSetBuilderFactory"/>
internal sealed class QueryArgumentSetBuilderFactory : IQueryArgumentSetBuilderFactory
{
    IQueryArgumentSetBuilder IQueryArgumentSetBuilderFactory.Create(ICommandArgument command) => new QueryArgumentSetBuilder(command);
}
