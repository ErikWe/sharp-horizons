namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation;
using SharpHorizons.Query.Result;
using SharpHorizons.Query.Vectors.Table;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IVectorTableContentInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class VectorTableContentInterpreter : IVectorTableContentInterpreter
{
    Optional<VectorTableContent> IInterpreter<VectorTableContent>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        var firstColonIndex = queryResult.Content.IndexOf(':', StringComparison.Ordinal);

        if (firstColonIndex is -1)
        {
            return new();
        }

        if (queryResult.Content[(firstColonIndex + 1)..].Split(' ', StringSplitOptions.RemoveEmptyEntries) is not { Length: > 0 } spaceSplit)
        {
            return new();
        }

        if (InterpretQuantities(spaceSplit[0]) is not VectorTableQuantities quantities || InterpretUncertainties(spaceSplit[0]) is not VectorTableUncertainties uncertainties)
        {
            return new();
        }

        return new VectorTableContent(quantities, uncertainties);
    }

    /// <summary>Attempts to interpret <see cref="VectorTableQuantities"/> from <paramref name="code"/>.</summary>
    /// <param name="code">The <see cref="VectorTableQuantities"/> are interpreted from this <see cref="string"/>, if possible.</param>
    private static VectorTableQuantities? InterpretQuantities(string code)
    {
        if (code.Length is 0)
        {
            return null;
        }

        return code[0] switch
        {
            '1' => VectorTableQuantities.Position,
            '2' => VectorTableQuantities.StateVectors,
            '3' => VectorTableQuantities.StateVectors | VectorTableQuantities.Distance,
            '4' => VectorTableQuantities.Position | VectorTableQuantities.Distance,
            '5' => VectorTableQuantities.Velocity,
            '6' => VectorTableQuantities.Distance,
            _ => null
        };
    }

    /// <summary>Attempts to interpret <see cref="VectorTableUncertainties"/> from <paramref name="code"/>.</summary>
    /// <param name="code">The <see cref="VectorTableUncertainties"/> are interpreted from this <see cref="string"/>, if possible.</param>
    private static VectorTableUncertainties? InterpretUncertainties(string code)
    {
        if (code.Length is 0)
        {
            return null;
        }

        var uncertainties = VectorTableUncertainties.None;

        foreach (var component in code[1..])
        {
            switch (component)
            {
                case 'x':
                    uncertainties |= VectorTableUncertainties.XYZ;
                    break;
                case 'a':
                    uncertainties |= VectorTableUncertainties.ACN;
                    break;
                case 'r':
                    uncertainties |= VectorTableUncertainties.RTN;
                    break;
                case 'p':
                    uncertainties |= VectorTableUncertainties.POS;
                    break;
                default:
                    break;
            }
        }

        return uncertainties;
    }
}
