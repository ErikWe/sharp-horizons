namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;

using System;

/// <summary>Composes <see cref="IOriginArgument"/> that describe <see cref="IBodyCentricOrigin"/>.</summary>
internal sealed class BodyCentricOriginComposer : IOriginComposer<IBodyCentricOrigin>
{
    IOriginArgument IArgumentComposer<IOriginArgument, IBodyCentricOrigin>.Compose(IBodyCentricOrigin obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return new QueryArgument($"g@{obj.OriginObject.ComposeIdentifier()}");
    }
}
