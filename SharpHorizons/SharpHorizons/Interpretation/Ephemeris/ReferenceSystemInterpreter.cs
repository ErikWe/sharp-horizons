namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation;
using SharpHorizons.Query;

/// <inheritdoc cref="IReferenceSystemInterpreter"/>
internal sealed class ReferenceSystemInterpreter : IReferenceSystemInterpreter
{
    Optional<ReferenceSystem> IPartInterpreter<ReferenceSystem>.Interpret(string queryPart)
    {
        if (queryPart.Contains("J2000") || queryPart.Contains("ICRF"))
        {
            return ReferenceSystem.ICRF;
        }

        if (queryPart.Contains("B1950") || queryPart.Contains("FK4"))
        {
            return ReferenceSystem.B1950;
        }

        return new();
    }
}
