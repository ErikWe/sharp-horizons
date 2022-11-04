namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;

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
