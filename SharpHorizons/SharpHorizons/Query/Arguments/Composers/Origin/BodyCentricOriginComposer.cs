namespace SharpHorizons.Query.Arguments.Composers.Origin;

using SharpHorizons.Query.Origin;

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
