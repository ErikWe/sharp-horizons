namespace SharpHorizons.Interpretation.Ephemeris.Target;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Result;
using SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System;
using System.Collections.Generic;

/// <inheritdoc cref="ITargetDataInterpreter"/>
internal sealed class TargetDataInterpreter : ITargetDataInterpreter
{
    /// <inheritdoc cref="IInterpretationOptionsProvider"/>
    private IInterpretationOptionsProvider InterpretationOptionsProvider { get; }
    
    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider"/>
    private IEphemerisInterpretationOptionsProvider EphemerisInterpretationOptionsProvider { get; }

    /// <summary>Registered <see cref="IPartInterpreter{TInterpretation}"/> by key.</summary>
    private Dictionary<string, Action<string, MutableTargetDataInterpretation>> Interpreters { get; } = new(5);

    /// <inheritdoc cref="TargetDataInterpreter"/>
    /// <param name="interpretationOptionsProvider"><inheritdoc cref="InterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="EphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="targetInterpretationKeyProvider"><inheritdoc cref="ITargetInterpretationKeyProvider" path="/summary"/></param>
    /// <param name="targetInterpreter"><inheritdoc cref="TargetInterpreter" path="/summary"/>.</param>
    /// <param name="geodeticCoordinateInterpreter">Interprets some part of <see cref="IQueryResult"/> as <see cref="GeodeticCoordinate"/>.</param>
    /// <param name="cylindricalCoordinateInterpreter">Interprets some part of <see cref="IQueryResult"/> as <see cref="CylindricalCoordinate"/>.</param>
    /// <param name="referenceEllipsoidInterpreter"><inheritdoc cref="ReferenceEllipsoidInterpreter" path="/summary"/></param>
    /// <param name="radiiInterpreter"><inheritdoc cref="RadiiInterpreter" path="/summary"/></param>
    public TargetDataInterpreter(IInterpretationOptionsProvider interpretationOptionsProvider, IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, ITargetInterpretationKeyProvider targetInterpretationKeyProvider, ITargetInterpreter targetInterpreter,
        ITargetGeodeticCoordinateInterpreter geodeticCoordinateInterpreter, ITargetCylindricalCoordinateInterpreter cylindricalCoordinateInterpreter, ITargetReferenceEllipsoidInterpreter referenceEllipsoidInterpreter, ITargetRadiiInterpreter radiiInterpreter)
    {
        InterpretationOptionsProvider = interpretationOptionsProvider;
        EphemerisInterpretationOptionsProvider = ephemerisInterpretationOptionsProvider;

        RegisterInterpreter(targetInterpreter, targetInterpretationKeyProvider.BodyName, static (target, interpretation) => interpretation.Target = target);
        RegisterInterpreter(geodeticCoordinateInterpreter, targetInterpretationKeyProvider.GeodeticCoordinate, static (target, interpretation) => interpretation.GeodeticCoordinate = target);
        RegisterInterpreter(cylindricalCoordinateInterpreter, targetInterpretationKeyProvider.CylindricalCoordinate, static (target, interpretation) => interpretation.CylindricalCoordinate = target);
        RegisterInterpreter(referenceEllipsoidInterpreter, targetInterpretationKeyProvider.ReferenceEllipsoid, static (referenceEllipsoid, interpretation) => interpretation.ReferenceEllipsoid = referenceEllipsoid);
        RegisterInterpreter(radiiInterpreter, targetInterpretationKeyProvider.Radii, static (radii, interpretation) => interpretation.Radii = radii);
    }

    /// <summary>Registers <paramref name="interpreter"/> with <see cref="Interpreters"/>.</summary>
    /// <typeparam name="TInterpretation">The type of the result interpreted by <paramref name="interpreter"/>.</typeparam>
    /// <param name="interpreter">This <see cref="IInterpreter{TInterpretation}"/> is registered with <see cref="Interpreters"/>.</param>
    /// <param name="key">The key used to register <paramref name="interpreter"/>.</param>
    /// <param name="setter">Delegate for applying the result of <paramref name="interpreter"/>.</param>
    private void RegisterInterpreter<TInterpretation>(IPartInterpreter<TInterpretation> interpreter, string key, Action<TInterpretation, MutableTargetDataInterpretation> setter)
    {
        Interpreters[FormatKey(key)] = (line, interpretation) => setter(interpreter.Interpret(line), interpretation);
    }

    Optional<ITargetDataInterpretation> IInterpreter<ITargetDataInterpretation>.TryInterpret(IQueryResult queryResult)
    {
        MutableTargetDataInterpretation? interpretatation = new();

        var linesEnumerator = queryResult.Content.SplitLines().GetEnumerator();

        while (linesEnumerator.MoveNext())
        {
            if (linesEnumerator.Current.StartsWith(EphemerisInterpretationOptionsProvider.EphemerisDataStart))
            {
                break;
            }
        }

        int separators = 0;
        int matches = 0;

        while (linesEnumerator.MoveNext())
        {
            if (linesEnumerator.Current.StartsWith(InterpretationOptionsProvider.BlockSeparator))
            {
                separators += 1;

                if (separators == EphemerisInterpretationOptionsProvider.EphemerisDataBlockCount)
                {
                    break;
                }

                continue;
            }

            if (linesEnumerator.Current.Split(':') is { Length: > 1 } colonSplit)
            {
                var key = FormatKey(colonSplit[0]);

                if (Interpreters.TryGetValue(key, out var interpreter))
                {
                    try
                    {
                        interpreter(linesEnumerator.Current, interpretatation);
                    }
                    catch (UnexpectedQueryResultFormatException) { }
                }

                matches += 1;

                if (matches == Interpreters.Count)
                {
                    break;
                }
            }
        }

        if (interpretatation.Target is null)
        {
            return new();
        }

        return interpretatation;
    }

    /// <summary>Converts <paramref name="key"/> to a format suitable for comparison.</summary>
    /// <param name="key">This <see cref="string"/> is formatted.</param>
    private static string FormatKey(string key) => key.Replace(" ", string.Empty).ToUpperInvariant();

    /// <summary>A mutable <see cref="ITargetDataInterpretation"/>.</summary>
    private sealed class MutableTargetDataInterpretation : ITargetDataInterpretation
    {
        public ITarget Target { get; set; } = null!;

        public GeodeticCoordinate? GeodeticCoordinate { get; set; }
        public CylindricalCoordinate? CylindricalCoordinate { get; set; }

        public ReferenceEllipsoidInterpretation? ReferenceEllipsoid { get; set; }

        public ObjectRadiiInterpretation? Radii { get; set; }
    }
}
