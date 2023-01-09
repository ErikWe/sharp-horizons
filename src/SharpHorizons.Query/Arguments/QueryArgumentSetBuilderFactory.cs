namespace SharpHorizons.Query.Arguments;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IQueryArgumentSetFactory"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class QueryArgumentSetBuilderFactory : IQueryArgumentSetFactory
{
    IQueryArgumentSetBuilder IQueryArgumentSetFactory.CreateBuilder(ICommandArgument command) => new QueryArgumentSetBuilder(command);
    IQueryArgumentSetBuilder IQueryArgumentSetFactory.CreateBuilder(IQueryArgumentSet argumentSet) => new QueryArgumentSetBuilder(argumentSet);
}
