namespace SharpHorizons.Query.Arguments;

/// <inheritdoc cref="IQueryArgumentSetBuilderFactory"/>
internal sealed class QueryArgumentSetBuilderFactory : IQueryArgumentSetBuilderFactory
{
    IQueryArgumentSetBuilder IQueryArgumentSetBuilderFactory.Create(ICommandArgument command)
    {
        IQueryArgumentSetBuilder builder = new QueryArgumentSetBuilder();

        builder.Specify(command);

        return builder;
    }
}
