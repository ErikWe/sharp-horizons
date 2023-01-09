namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation;
using SharpHorizons.Query;
using SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IReferencePlaneInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class ReferencePlaneInterpreter : IReferencePlaneInterpreter
{
    Optional<ReferencePlane> IInterpreter<ReferencePlane>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        if (queryResult.Content.Contains("Ecliptic", StringComparison.Ordinal))
        {
            return ReferencePlane.Ecliptic;
        }

        if (queryResult.Content.Contains("ICRF", StringComparison.Ordinal) || queryResult.Content.Contains("FK4", StringComparison.Ordinal))
        {
            return ReferencePlane.Frame;
        }

        if (queryResult.Content.Contains("body equator and node of date", StringComparison.Ordinal))
        {
            return ReferencePlane.BodyEquator;
        }

        return new();
    }
}
