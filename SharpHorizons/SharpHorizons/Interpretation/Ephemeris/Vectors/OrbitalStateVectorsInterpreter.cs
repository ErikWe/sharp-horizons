namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Interpretation.Ephemeris;
using SharpHorizons.Query.Result;

using System;

/// <inheritdoc cref="IOrbitalStateVectorsInterpreter"/>
internal sealed class OrbitalStateVectorsInterpreter : AEphemerisInterpreter<MutableOrbitalStateVectors, IVectorsHeader>, IOrbitalStateVectorsInterpreter
{
    /// <inheritdoc cref="IVectorsHeaderInterpreter"/>
    private IVectorsHeaderInterpreter HeaderInterpreter { get; }

    /// <inheritdoc cref="OrbitalStateVectorsInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="headerInterpreter"><inheritdoc cref="HeaderInterpreter" path="/summary"/></param>
    /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="IEphemerisEpochInterpreter" path="/summary"/></param>
    /// <param name="positionXInterpreter"><inheritdoc cref="IPositionXInterpreter" path="/summary"/></param>
    /// <param name="positionYInterpreter"><inheritdoc cref="IPositionYInterpreter" path="/summary"/></param>
    /// <param name="positionZInterpreter"><inheritdoc cref="IPositionZInterpreter" path="/summary"/></param>
    /// <param name="velocityXInterpreter"><inheritdoc cref="IVelocityXInterpreter" path="/summary"/></param>
    /// <param name="velocityYInterpreter"><inheritdoc cref="IVelocityYInterpreter" path="/summary"/></param>
    /// <param name="velocityZInterpreter"><inheritdoc cref="IVelocityZInterpreter" path="/summary"/></param>
    public OrbitalStateVectorsInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IVectorsHeaderInterpreter headerInterpreter, IEphemerisEpochInterpreter ephemerisEpochInterpreter, IPositionXInterpreter positionXInterpreter, IPositionYInterpreter positionYInterpreter, IPositionZInterpreter positionZInterpreter,
        IVelocityXInterpreter velocityXInterpreter, IVelocityYInterpreter velocityYInterpreter, IVelocityZInterpreter velocityZInterpreter)
        : base(ephemerisInterpretationOptionsProvider, new EphemerisQuantityInterpretationDelegater(ephemerisEpochInterpreter, positionXInterpreter, positionYInterpreter, positionZInterpreter, velocityXInterpreter, velocityYInterpreter, velocityZInterpreter))
    {
        HeaderInterpreter = headerInterpreter;
    }

    protected override MutableOrbitalStateVectors CreateEntry() => new();

    protected override bool ValidateEntry(MutableOrbitalStateVectors entry) => MutableOrbitalStateVectors.Validate(entry);

    Optional<IOrbitalStateVectorsEphemeris> IInterpreter<IOrbitalStateVectorsEphemeris>.Interpret(IQueryResult queryResult)
    {
        if (HeaderInterpreter.Interpret(queryResult) is not { HasValue: true, Value: var header })
        {
            return new();
        }

        var ephemeris = InterpretEntries(queryResult, header);

        return OrbitalStateVectorsEphemeris.FromOrdered(ephemeris);
    }

    /// <summary>Handles the invokation of some <see cref="IEphemerisQuantityInterpreter{THeader, TInterpretation}"/> associated with some <see cref="EphemerisQuantityIdentifier"/>.</summary>
    private class EphemerisQuantityInterpretationDelegater : IEphemerisQuantityInterpretationDelegater
    {
        /// <inheritdoc cref="IEphemerisEpochInterpreter"/>
        private IEphemerisEpochInterpreter EphemerisEpochInterpreter { get; }

        /// <inheritdoc cref="IPositionXInterpreter"/>
        private IPositionXInterpreter PositionXInterpreter { get; }

        /// <inheritdoc cref="IPositionYInterpreter"/>
        private IPositionYInterpreter PositionYInterpreter { get; }

        /// <inheritdoc cref="IPositionZInterpreter"/>
        private IPositionZInterpreter PositionZInterpreter { get; }

        /// <inheritdoc cref="IVelocityXInterpreter"/>
        private IVelocityXInterpreter VelocityXInterpreter { get; }

        /// <inheritdoc cref="IVelocityYInterpreter"/>
        private IVelocityYInterpreter VelocityYInterpreter { get; }

        /// <inheritdoc cref="IVelocityZInterpreter"/>
        private IVelocityZInterpreter VelocityZInterpreter { get; }

        /// <inheritdoc cref="EphemerisQuantityInterpretationDelegater"/>
        /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="EphemerisEpochInterpreter" path="/summary"/></param>
        /// <param name="positionXInterpreter"><inheritdoc cref="PositionXInterpreter" path="/summary"/></param>
        /// <param name="positionYInterpreter"><inheritdoc cref="PositionYInterpreter" path="/summary"/></param>
        /// <param name="positionZInterpreter"><inheritdoc cref="PositionZInterpreter" path="/summary"/></param>
        /// <param name="velocityXInterpreter"><inheritdoc cref="VelocityXInterpreter" path="/summary"/></param>
        /// <param name="velocityYInterpreter"><inheritdoc cref="VelocityYInterpreter" path="/summary"/></param>
        /// <param name="velocityZInterpreter"><inheritdoc cref="VelocityZInterpreter" path="/summary"/></param>
        public EphemerisQuantityInterpretationDelegater(IEphemerisEpochInterpreter ephemerisEpochInterpreter, IPositionXInterpreter positionXInterpreter, IPositionYInterpreter positionYInterpreter, IPositionZInterpreter positionZInterpreter,
            IVelocityXInterpreter velocityXInterpreter, IVelocityYInterpreter velocityYInterpreter, IVelocityZInterpreter velocityZInterpreter)
        {
            EphemerisEpochInterpreter = ephemerisEpochInterpreter;

            PositionXInterpreter = positionXInterpreter;
            PositionYInterpreter = positionYInterpreter;
            PositionZInterpreter = positionZInterpreter;

            VelocityXInterpreter = velocityXInterpreter;
            VelocityYInterpreter = velocityYInterpreter;
            VelocityZInterpreter = velocityZInterpreter;
        }

        MutableOrbitalStateVectors IEphemerisQuantityInterpretationDelegater.Interpret(EphemerisQuantityIdentifier quantity, EphemerisQuantityTableIndex index, string text, IVectorsHeader header, MutableOrbitalStateVectors ephemerisEntry)
        {
            return quantity.Identifier switch
            {
                "JDUT" or "JDTT" or "JDTDB" => Interpret(text, header, ephemerisEntry, EphemerisEpochInterpreter, static (ephemerisEntry, epoch) => ephemerisEntry.Epoch = epoch),
                "X" => Interpret(text, header, ephemerisEntry, PositionXInterpreter, static (ephemerisEntry, positionX) => ephemerisEntry.PositionX = positionX),
                "Y" => Interpret(text, header, ephemerisEntry, PositionYInterpreter, static (ephemerisEntry, positionY) => ephemerisEntry.PositionY = positionY),
                "Z" => Interpret(text, header, ephemerisEntry, PositionZInterpreter, static (ephemerisEntry, positionZ) => ephemerisEntry.PositionZ = positionZ),
                "VX" => Interpret(text, header, ephemerisEntry, VelocityXInterpreter, static (ephemerisEntry, velocityX) => ephemerisEntry.VelocityX = velocityX),
                "VY" => Interpret(text, header, ephemerisEntry, VelocityYInterpreter, static (ephemerisEntry, velocityY) => ephemerisEntry.VelocityY = velocityY),
                "VZ" => Interpret(text, header, ephemerisEntry, VelocityZInterpreter, static (ephemerisEntry, velocityZ) => ephemerisEntry.VelocityZ = velocityZ),
                _ => ephemerisEntry
            };
        }

        /// <summary>Interprets a quantity of the <paramref name="ephemerisEntry"/> from <paramref name="text"/>.</summary>
        /// <typeparam name="TInterpretation">The type of the quantity interpreted by the <paramref name="interpreter"/>.</typeparam>
        /// <param name="text">The quantity of type <typeparamref name="TInterpretation"/> is interpreted from this <see cref="string"/>.</param>
        /// <param name="header">The <see cref="IVectorsHeader"/>, representing the header of the <see cref="IQueryResult"/>.</param>
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
