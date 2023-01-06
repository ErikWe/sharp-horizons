namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

using System;

/// <inheritdoc cref="IOrbitalStateVectorsInterpreter"/>
internal class OrbitalStateVectorsInterpreter : AEphemerisEntryInterpreter<MutableOrbitalStateVectors, IVectorsHeader>, IOrbitalStateVectorsInterpreter
{
    /// <inheritdoc cref="OrbitalStateVectorsInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="IEphemerisEpochInterpreter" path="/summary"/></param>
    /// <param name="positionComponentInterpreter"><inheritdoc cref="IObjectPositionComponentInterpreter" path="/summary"/></param>
    /// <param name="velocityComponentInterpreter"><inheritdoc cref="IObjectVelocityComponentInterpreter" path="/summary"/></param>
    public OrbitalStateVectorsInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectPositionComponentInterpreter positionComponentInterpreter, IObjectVelocityComponentInterpreter velocityComponentInterpreter)
        : base(ephemerisInterpretationOptionsProvider, new EphemerisQuantityInterpretationDelegater(ephemerisEpochInterpreter, positionComponentInterpreter, velocityComponentInterpreter)) { }

    protected override MutableOrbitalStateVectors CreateEntry() => new();
    protected override bool ValidateEntry(MutableOrbitalStateVectors entry) => MutableOrbitalStateVectors.Validate(entry);

    Optional<IOrbitalStateVectors> IEphemerisEntryInterpreter<IVectorsHeader, IOrbitalStateVectors>.Interpret(IVectorsHeader header, QueryResult queryResult)
    {
        if (Interpret(header, queryResult) is { HasValue: true, Value: var ephemerisEntry })
        {
            return ephemerisEntry;
        }

        return new();
    }

    /// <summary>Handles the invokation of some <see cref="IEphemerisQuantityInterpreter{THeader, TInterpretation}"/> associated with some <see cref="EphemerisQuantityIdentifier"/>.</summary>
    private class EphemerisQuantityInterpretationDelegater : IEphemerisQuantityInterpretationDelegater
    {
        /// <inheritdoc cref="IEphemerisEpochInterpreter"/>
        private IEphemerisEpochInterpreter EphemerisEpochInterpreter { get; }

        /// <inheritdoc cref="IObjectPositionComponentInterpreter"/>
        private IObjectPositionComponentInterpreter PositionComponentInterpreter { get; }

        /// <inheritdoc cref="IObjectVelocityComponentInterpreter"/>
        private IObjectVelocityComponentInterpreter VelocityComponentInterpreter { get; }

        /// <inheritdoc cref="EphemerisQuantityInterpretationDelegater"/>
        /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="EphemerisEpochInterpreter" path="/summary"/></param>
        /// <param name="positionXInterpreter"><inheritdoc cref="PositionComponentInterpreter" path="/summary"/></param>
        /// <param name="velocityXInterpreter"><inheritdoc cref="VelocityComponentInterpreter" path="/summary"/></param>
        public EphemerisQuantityInterpretationDelegater(IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectPositionComponentInterpreter positionXInterpreter, IObjectVelocityComponentInterpreter velocityXInterpreter)
        {
            EphemerisEpochInterpreter = ephemerisEpochInterpreter;

            PositionComponentInterpreter = positionXInterpreter;
            VelocityComponentInterpreter = velocityXInterpreter;
        }

        MutableOrbitalStateVectors IEphemerisQuantityInterpretationDelegater.Interpret(EphemerisQuantityIdentifier quantity, EphemerisQuantityTableIndex index, string text, IVectorsHeader header, MutableOrbitalStateVectors ephemerisEntry)
        {
            return quantity.Identifier switch
            {
                "JDUT" or "JDTT" or "JDTDB" => Interpret(text, header, ephemerisEntry, EphemerisEpochInterpreter, static (ephemerisEntry, epoch) => ephemerisEntry.Epoch = epoch),
                "X" => Interpret(text, header, ephemerisEntry, PositionComponentInterpreter, static (ephemerisEntry, positionX) => ephemerisEntry.PositionX = positionX),
                "Y" => Interpret(text, header, ephemerisEntry, PositionComponentInterpreter, static (ephemerisEntry, positionY) => ephemerisEntry.PositionY = positionY),
                "Z" => Interpret(text, header, ephemerisEntry, PositionComponentInterpreter, static (ephemerisEntry, positionZ) => ephemerisEntry.PositionZ = positionZ),
                "VX" => Interpret(text, header, ephemerisEntry, VelocityComponentInterpreter, static (ephemerisEntry, velocityX) => ephemerisEntry.VelocityX = velocityX),
                "VY" => Interpret(text, header, ephemerisEntry, VelocityComponentInterpreter, static (ephemerisEntry, velocityY) => ephemerisEntry.VelocityY = velocityY),
                "VZ" => Interpret(text, header, ephemerisEntry, VelocityComponentInterpreter, static (ephemerisEntry, velocityZ) => ephemerisEntry.VelocityZ = velocityZ),
                _ => ephemerisEntry
            };
        }

        /// <summary>Interprets a quantity of the <paramref name="ephemerisEntry"/> from <paramref name="text"/>.</summary>
        /// <typeparam name="TInterpretation">The type of the quantity interpreted by the <paramref name="interpreter"/>.</typeparam>
        /// <param name="text">The quantity of type <typeparamref name="TInterpretation"/> is interpreted from this <see cref="string"/>.</param>
        /// <param name="header">The <see cref="IVectorsHeader"/>, representing the header of the <see cref="QueryResult"/>.</param>
        /// <param name="ephemerisEntry">The <see cref="MutableOrbitalStateVectors"/> to which the interpreted quantity is applied, using <paramref name="setter"/>.</param>
        /// <param name="interpreter">The <see cref="IEphemerisQuantityInterpreter{THeader, TInterpretation}"/> responsible for interpreting a quantity from <paramref name="text"/>.</param>
        /// <param name="setter">Delegates applying the quantity to the <paramref name="ephemerisEntry"/>.</param>
        private static MutableOrbitalStateVectors Interpret<TInterpretation>(string text, IVectorsHeader header, MutableOrbitalStateVectors ephemerisEntry, IEphemerisQuantityInterpreter<IVectorsHeader, TInterpretation> interpreter, Action<MutableOrbitalStateVectors, TInterpretation> setter)
        {
            if (interpreter.Interpret(text, header) is { HasValue: true, Value: var interpretation })
            {
                setter(ephemerisEntry, interpretation);
            }

            return ephemerisEntry;
        }
    }
}
