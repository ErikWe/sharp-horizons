namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;

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
