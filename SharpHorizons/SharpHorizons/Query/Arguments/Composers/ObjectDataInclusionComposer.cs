namespace SharpHorizons.Query.Arguments.Composers;

/// <inheritdoc cref="IObjectDataInclusionComposer"/>
internal sealed class ObjectDataInclusionComposer : IObjectDataInclusionComposer
{
    IObjectDataInclusionArgument IArgumentComposer<IObjectDataInclusionArgument, ObjectDataInclusion>.Compose(ObjectDataInclusion obj) => new QueryArgument(obj switch
    {
        ObjectDataInclusion.Disable => "NO",
        ObjectDataInclusion.Enable => "YES",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
    });
}
