namespace SharpHorizons.Composers.Arguments.Origin;

using SharpHorizons.Query;
using SharpHorizons.Query.Origin;

using System;
using System.Globalization;

/// <summary>Composes <see cref="IOriginArgument"/> that describe <see cref="IObservationSiteOrigin"/>.</summary>
internal sealed class ObservationSiteOriginComposer : IOriginComposer<IObservationSiteOrigin>
{
    IOriginArgument IArgumentComposer<IOriginArgument, IObservationSiteOrigin>.Compose(IObservationSiteOrigin obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return new QueryArgument($"{obj.ObservationSiteID.ToString(CultureInfo.CurrentCulture)}@{obj.OriginObject.ComposeIdentifier()}");
    }
}
