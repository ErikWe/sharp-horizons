namespace SharpHorizons.Interpretation.Ephemeris.Origin;

using Microsoft.CodeAnalysis;

using System;

/// <inheritdoc cref="IOriginSiteNameInterpreter"/>
internal sealed class SiteNameInterpreter : IOriginSiteNameInterpreter
{
    /// <inheritdoc cref="IOriginInterpretationOptionsProvider"/>
    private IOriginInterpretationOptionsProvider OriginInterpretationOptionsProvider { get; }

    /// <inheritdoc cref="SiteNameInterpreter"/>
    /// <param name="originInterpretationOptionsProvider"><inheritdoc cref="OriginInterpretationOptionsProvider" path="/summary"/></param>
    public SiteNameInterpreter(IOriginInterpretationOptionsProvider originInterpretationOptionsProvider)
    {
        OriginInterpretationOptionsProvider = originInterpretationOptionsProvider;
    }

    Optional<ObservationSiteName> IPartInterpreter<ObservationSiteName>.TryInterpret(string queryPart)
    {
        ArgumentNullException.ThrowIfNull(queryPart);

        if (queryPart.Split(':') is not { Length: > 1 } colonSplit)
        {
            return new();
        }

        var siteName = colonSplit[1].Trim();

        if (siteName == OriginInterpretationOptionsProvider.GeocentricSite || siteName == OriginInterpretationOptionsProvider.CustomSite)
        {
            return new();
        }

        return new ObservationSiteName(siteName);
    }
}
