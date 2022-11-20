namespace SharpHorizons.Query.Arguments.Composers.Origin;

using SharpHorizons.Query.Origin;

using System;

/// <summary>Composes <see cref="IOriginArgument"/> that describe <see cref="IObservationSiteOrigin"/>.</summary>
internal sealed class ObservationSiteOriginComposer : IOriginComposer<IObservationSiteOrigin>
{
    IOriginArgument IArgumentComposer<IOriginArgument, IObservationSiteOrigin>.Compose(IObservationSiteOrigin obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return new QueryArgument($"{obj.ObservationSiteID}@{obj.OriginObject.ComposeIdentifier()}");
    }
}
