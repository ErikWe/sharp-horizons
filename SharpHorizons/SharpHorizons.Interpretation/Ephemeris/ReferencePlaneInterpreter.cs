namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation;
using SharpHorizons.Query;
using SharpHorizons.Query.Result;

/// <inheritdoc cref="IReferencePlaneInterpreter"/>
internal sealed class ReferencePlaneInterpreter : IReferencePlaneInterpreter
{
    Optional<ReferencePlane> IInterpreter<ReferencePlane>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        if (queryResult.Content.Contains("Ecliptic"))
        {
            return ReferencePlane.Ecliptic;
        }

        if (queryResult.Content.Contains("ICRF") || queryResult.Content.Contains("FK4"))
        {
            return ReferencePlane.Frame;
        }

        if (queryResult.Content.Contains("body equator and node of date"))
        {
            return ReferencePlane.BodyEquator;
        }

        return new();
    }
}
