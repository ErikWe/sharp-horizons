namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation.Ephemeris.Origin;
using SharpHorizons.Interpretation.Ephemeris.Target;

/// <inheritdoc cref="ITargetReferenceEllipsoidInterpreter"/>
internal sealed class ReferenceEllipsoidInterpreter : ITargetReferenceEllipsoidInterpreter, IOriginReferenceEllipsoidInterpreter
{
    /// <summary><inheritdoc cref="IEphemerisInterpretationOptionsProvider.WestPositiveLongitude"/></summary>
    private string WestPositiveLongitude { get; }

    /// <summary><inheritdoc cref="IEphemerisInterpretationOptionsProvider.EastPositiveLongitude"/></summary>
    private string EastPositiveLongitude { get; }

    /// <inheritdoc cref="ReferenceEllipsoidInterpretation"/>
    /// <param name="interpretationKeyProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    public ReferenceEllipsoidInterpreter(IEphemerisInterpretationOptionsProvider interpretationKeyProvider)
    {
        WestPositiveLongitude = FormatLongitudeKey(interpretationKeyProvider.WestPositiveLongitude);
        EastPositiveLongitude = FormatLongitudeKey(interpretationKeyProvider.EastPositiveLongitude);
    }

    Optional<ReferenceEllipsoidInterpretation> IPartInterpreter<ReferenceEllipsoidInterpretation>.TryInterpret(string queryPart)
    {
        if (queryPart.Split(':') is not { Length: > 1 } colonSplit || colonSplit[1].Split('{') is not { Length: > 1 } openBracketSplit || openBracketSplit[1].Split('}') is not { Length: > 1 } closeBracketSplit)
        {
            return new();
        }

        return new ReferenceEllipsoidInterpretation()
        {
            Name = openBracketSplit[0].Trim(),
            LongitudeDefinition = InterpretLongitude(closeBracketSplit[0])
        };
    }

    /// <summary>Interprets <paramref name="text"/> as <see cref="LongitudeInterpretation"/>.</summary>
    /// <param name="text">This <see cref="string"/> is interpreted.</param>
    private LongitudeInterpretation InterpretLongitude(string text)
    {
        var formattedText = FormatLongitudeKey(text);

        if (formattedText == WestPositiveLongitude)
        {
            return LongitudeInterpretation.WestPositive;
        }

        if (formattedText == EastPositiveLongitude)
        {
            return LongitudeInterpretation.EastPositive;
        }

        return LongitudeInterpretation.Unknown;
    }

    /// <summary>Converts <paramref name="key"/> to a format suitable for comparison.</summary>
    /// <param name="key">This <see cref="string"/> is formatted.</param>
    private static string FormatLongitudeKey(string key) => key.Replace(" ", string.Empty).ToUpperInvariant();
}
