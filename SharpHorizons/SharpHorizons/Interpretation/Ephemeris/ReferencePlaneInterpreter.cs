namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation;
using SharpHorizons.Query;

/// <inheritdoc cref="IReferencePlaneInterpreter"/>
internal sealed class ReferencePlaneInterpreter : IReferencePlaneInterpreter
{
    Optional<ReferencePlane> IPartInterpreter<ReferencePlane>.Interpret(string queryPart)
    {
        if (queryPart.Contains("Ecliptic"))
        {
            return ReferencePlane.Ecliptic;
        }

        if (queryPart.Contains("ICRF") || queryPart.Contains("FK4"))
        {
            return ReferencePlane.Frame;
        }

        if (queryPart.Contains("body equator and node of date"))
        {
            return ReferencePlane.BodyEquator;
        }

        return new();
    }
}
