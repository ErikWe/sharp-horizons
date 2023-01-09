namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IObjectDistanceInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class ObjectDistanceInterpreter : AEphemerisEntryInterpreter<MutableObjectDistance, IVectorsHeader>, IObjectDistanceInterpreter
{
    /// <inheritdoc cref="ObjectDistanceInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="IEphemerisEpochInterpreter" path="/summary"/></param>
    /// <param name="distanceInterpreter"><inheritdoc cref="IDistanceInterpreter" path="/summary"/></param>
    /// <param name="radialSpeedInterpreter"><inheritdoc cref="IRadialSpeedInterpreter" path="/summary"/></param>
    /// <param name="lightTimeInterpreter"><inheritdoc cref="ILightTimeInterpreter" path="/summary"/></param>
    public ObjectDistanceInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IEphemerisEpochInterpreter ephemerisEpochInterpreter, IDistanceInterpreter distanceInterpreter, IRadialSpeedInterpreter radialSpeedInterpreter, ILightTimeInterpreter lightTimeInterpreter)
        : base(ephemerisInterpretationOptionsProvider, new EphemerisQuantityInterpretationDelegater(ephemerisEpochInterpreter, distanceInterpreter, radialSpeedInterpreter, lightTimeInterpreter)) { }

    protected override MutableObjectDistance CreateEntry() => new();
    protected override bool ValidateEntry(MutableObjectDistance entry) => MutableObjectDistance.Validate(entry);

    Optional<IObjectDistance> IEphemerisEntryInterpreter<IVectorsHeader, IObjectDistance>.Interpret(IVectorsHeader header, QueryResult queryResult)
    {
        if (Interpret(header, queryResult) is { HasValue: true, Value: var ephemerisEntry })
        {
            return ephemerisEntry;
        }

        return new();
    }

    /// <summary>Handles the invokation of some <see cref="IEphemerisQuantityInterpreter{THeader, TInterpretation}"/> associated with some <see cref="EphemerisQuantityIdentifier"/>.</summary>
    private sealed class EphemerisQuantityInterpretationDelegater : IEphemerisQuantityInterpretationDelegater
    {
        /// <inheritdoc cref="IEphemerisEpochInterpreter"/>
        private IEphemerisEpochInterpreter EphemerisEpochInterpreter { get; }

        /// <inheritdoc cref="IDistanceInterpreter"/>
        private IDistanceInterpreter DistanceInterpreter { get; }

        /// <inheritdoc cref="IRadialSpeedInterpreter"/>
        private IRadialSpeedInterpreter RadialSpeedInterpreter { get; }

        /// <inheritdoc cref="ILightTimeInterpreter"/>
        private ILightTimeInterpreter LightTimeInterpeter { get; }

        /// <inheritdoc cref="EphemerisQuantityInterpretationDelegater"/>
        /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="EphemerisEpochInterpreter" path="/summary"/></param>
        /// <param name="distanceInterpreter"><inheritdoc cref="IDistanceInterpreter" path="/summary"/></param>
        /// <param name="radialSpeedInterpreter"><inheritdoc cref="IRadialSpeedInterpreter" path="/summary"/></param>
        /// <param name="lightTimeInterpreter"><inheritdoc cref="ILightTimeInterpreter" path="/summary"/></param>
        public EphemerisQuantityInterpretationDelegater(IEphemerisEpochInterpreter ephemerisEpochInterpreter, IDistanceInterpreter distanceInterpreter, IRadialSpeedInterpreter radialSpeedInterpreter, ILightTimeInterpreter lightTimeInterpreter)
        {
            EphemerisEpochInterpreter = ephemerisEpochInterpreter;

            DistanceInterpreter = distanceInterpreter;
            RadialSpeedInterpreter = radialSpeedInterpreter;
            LightTimeInterpeter = lightTimeInterpreter;
        }

        MutableObjectDistance IEphemerisQuantityInterpretationDelegater.Interpret(EphemerisQuantityIdentifier quantity, EphemerisQuantityTableIndex index, string text, IVectorsHeader header, MutableObjectDistance ephemerisEntry)
        {
            return quantity.Identifier switch
            {
                "JDUT" or "JDTT" or "JDTDB" => Interpret(text, header, ephemerisEntry, EphemerisEpochInterpreter, static (ephemerisEntry, epoch) => ephemerisEntry.Epoch = epoch),
                "RG" => Interpret(text, header, ephemerisEntry, DistanceInterpreter, static (ephemerisEntry, distance) => ephemerisEntry.Distance = distance),
                "RR" => Interpret(text, header, ephemerisEntry, RadialSpeedInterpreter, static (ephemerisEntry, radialSpeed) => ephemerisEntry.RadialSpeed = radialSpeed),
                "LT" => Interpret(text, header, ephemerisEntry, LightTimeInterpeter, static (ephemerisEntry, lightTime) => ephemerisEntry.LightTime = lightTime),
                _ => ephemerisEntry
            };
        }

        /// <summary>Interprets a quantity of the <paramref name="ephemerisEntry"/> from <paramref name="text"/>.</summary>
        /// <typeparam name="TInterpretation">The type of the quantity interpreted by the <paramref name="interpreter"/>.</typeparam>
        /// <param name="text">The quantity of type <typeparamref name="TInterpretation"/> is interpreted from this <see cref="string"/>.</param>
        /// <param name="header">The <see cref="IVectorsHeader"/>, representing the header of the <see cref="QueryResult"/>.</param>
        /// <param name="ephemerisEntry">The <see cref="MutableObjectDistance"/> to which the interpreted quantity is applied, using <paramref name="setter"/>.</param>
        /// <param name="interpreter">The <see cref="IEphemerisQuantityInterpreter{THeader, TInterpretation}"/> responsible for interpreting a quantity from <paramref name="text"/>.</param>
        /// <param name="setter">Delegates applying the quantity to the <paramref name="ephemerisEntry"/>.</param>
        private static MutableObjectDistance Interpret<TInterpretation>(string text, IVectorsHeader header, MutableObjectDistance ephemerisEntry, IEphemerisQuantityInterpreter<IVectorsHeader, TInterpretation> interpreter, Action<MutableObjectDistance, TInterpretation> setter)
        {
            if (interpreter.Interpret(text, header) is { HasValue: true, Value: var interpretation })
            {
                setter(ephemerisEntry, interpretation);
            }

            return ephemerisEntry;
        }
    }
}
