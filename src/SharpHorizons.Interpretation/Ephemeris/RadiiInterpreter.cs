﻿namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation.Ephemeris.Origin;
using SharpHorizons.Interpretation.Ephemeris.Target;
using SharpHorizons.Query.Result;

using SharpMeasures;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <inheritdoc cref="ITargetRadiiInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class RadiiInterpreter : ITargetRadiiInterpreter, IOriginRadiiInterpreter
{
    /// <inheritdoc cref="IInterpretationOptionsProvider"/>
    private IInterpretationOptionsProvider InterpretationOptionsProvider { get; }

    /// <inheritdoc cref="RadiiInterpreter"/>
    /// <param name="interpretationOptionsProvider"><inheritdoc cref="InterpretationOptionsProvider" path="/summary"/></param>
    public RadiiInterpreter(IInterpretationOptionsProvider interpretationOptionsProvider)
    {
        InterpretationOptionsProvider = interpretationOptionsProvider;
    }

    Optional<ObjectRadiiInterpretation> IInterpreter<ObjectRadiiInterpretation>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        if (queryResult.Content.Contains(InterpretationOptionsProvider.UnavailableText, StringComparison.Ordinal))
        {
            return new();
        }

        if (queryResult.Content.Split(':') is not { Length: > 1 } colonSplit || colonSplit[1].Split('{') is not { Length: > 1 } bracketSplit || bracketSplit[0].Split('x') is not { Length: 3 } xSplit || xSplit[2].Split('k') is not { Length: 2 } unitSplit)
        {
            return new();
        }

        if (TryParse(xSplit[0]) is not int equator || TryParse(xSplit[1]) is not int meridian || TryParse(unitSplit[0]) is not int pole)
        {
            return new();
        }

        return new ObjectRadiiInterpretation()
        {
            Equator = equator * Distance.OneKilometre,
            Meridian = meridian * Distance.OneKilometre,
            Pole = pole * Distance.OneKilometre
        };
    }

    /// <summary>Attempts to parse an <see cref="int"/> from <paramref name="text"/>.</summary>
    /// <param name="text">An <see cref="int"/> is parsed from this <see cref="string"/>, if possible.</param>
    private static int? TryParse(string text)
    {
        var valid = int.TryParse(text, NumberStyles.Number, provider: null, out var value);

        return valid ? value : null;
    }
}
