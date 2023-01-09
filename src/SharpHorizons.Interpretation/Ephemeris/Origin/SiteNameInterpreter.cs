namespace SharpHorizons.Interpretation.Ephemeris.Origin;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Result;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IOriginSiteNameInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
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

    Optional<ObservationSiteName> IInterpreter<ObservationSiteName>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        if (queryResult.Content.Split(':') is not { Length: > 1 } colonSplit)
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
