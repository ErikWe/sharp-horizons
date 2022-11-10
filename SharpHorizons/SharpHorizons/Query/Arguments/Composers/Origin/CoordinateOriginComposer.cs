namespace SharpHorizons.Query.Arguments.Composers.Origin;

using SharpHorizons.Query.Origin;

using System;

/// <summary>Composes <see cref="IOriginArgument"/> that describe <see cref="ICoordinateOrigin"/>.</summary>
internal sealed class CoordinateOriginComposer : IOriginComposer<ICoordinateOrigin>
{
    IOriginArgument IArgumentComposer<IOriginArgument, ICoordinateOrigin>.Compose(ICoordinateOrigin obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return new QueryArgument($"c@{obj.OriginObject.ComposeIdentifier()}");
    }
}
