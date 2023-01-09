namespace SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IObjectDataInclusionComposer"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class ObjectDataInclusionComposer : IObjectDataInclusionComposer
{
    IObjectDataInclusionArgument IArgumentComposer<IObjectDataInclusionArgument, ObjectDataInclusion>.Compose(ObjectDataInclusion obj) => new QueryArgument(obj switch
    {
        ObjectDataInclusion.Disable => "NO",
        ObjectDataInclusion.Enable => "YES",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
    });
}
