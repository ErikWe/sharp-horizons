namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation.Ephemeris.Origin;
using SharpHorizons.Interpretation.Ephemeris.Target;
using SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="ITargetReferenceEllipsoidInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class ReferenceEllipsoidInterpreter : ITargetReferenceEllipsoidInterpreter, IOriginReferenceEllipsoidInterpreter
{
    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider.WestPositiveLongitude"/>
    private string WestPositiveLongitude { get; }

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider.EastPositiveLongitude"/>
    private string EastPositiveLongitude { get; }

    /// <inheritdoc cref="ReferenceEllipsoidInterpretation"/>
    /// <param name="interpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    public ReferenceEllipsoidInterpreter(IEphemerisInterpretationOptionsProvider interpretationOptionsProvider)
    {
        WestPositiveLongitude = FormatLongitudeKey(interpretationOptionsProvider.WestPositiveLongitude);
        EastPositiveLongitude = FormatLongitudeKey(interpretationOptionsProvider.EastPositiveLongitude);
    }

    Optional<ReferenceEllipsoidInterpretation> IInterpreter<ReferenceEllipsoidInterpretation>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        if (queryResult.Content.Split(':') is not { Length: > 1 } colonSplit || colonSplit[1].Split('{') is not { Length: > 1 } openBracketSplit || openBracketSplit[1].Split('}') is not { Length: > 1 } closeBracketSplit)
        {
            return new();
        }

        return new ReferenceEllipsoidInterpretation()
        {
            Name = openBracketSplit[0].Trim(),
            LongitudeDefinition = InterpretLongitude(closeBracketSplit[0])
        };
    }

    /// <summary>Interprets <paramref name="text"/> as <see cref="LongitudeDefinition"/>.</summary>
    /// <param name="text">This <see cref="string"/> is interpreted.</param>
    private LongitudeDefinition InterpretLongitude(string text)
    {
        var formattedText = FormatLongitudeKey(text);

        if (formattedText == WestPositiveLongitude)
        {
            return LongitudeDefinition.WestPositive;
        }

        if (formattedText == EastPositiveLongitude)
        {
            return LongitudeDefinition.EastPositive;
        }

        return LongitudeDefinition.Unknown;
    }

    /// <summary>Converts <paramref name="key"/> to a format suitable for comparison.</summary>
    /// <param name="key">This <see cref="string"/> is formatted.</param>
    private static string FormatLongitudeKey(string key) => key.Replace(" ", string.Empty, StringComparison.Ordinal).ToUpperInvariant();
}
