namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

using System;

/// <inheritdoc cref="IObjectVelocityUncertaintyACNInterpreter"/>
internal class ObjectVelocityUncertaintyACNInterpreter : AEphemerisEntryInterpreter<MutableObjectVelocityUncertaintyACN, IVectorsHeader>, IObjectVelocityUncertaintyACNInterpreter
{
    /// <inheritdoc cref="ObjectVelocityUncertaintyACNInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="IEphemerisEpochInterpreter" path="/summary"/></param>
    /// <param name="positionUncertaintyComponentInterpreter"><inheritdoc cref="IObjectVelocityUncertaintyACNComponentInterpreter" path="/summary"/></param>
    public ObjectVelocityUncertaintyACNInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectVelocityUncertaintyACNComponentInterpreter positionUncertaintyComponentInterpreter)
        : base(ephemerisInterpretationOptionsProvider, new EphemerisQuantityInterpretationDelegater(ephemerisEpochInterpreter, positionUncertaintyComponentInterpreter)) { }

    protected override MutableObjectVelocityUncertaintyACN CreateEntry() => new();
    protected override bool ValidateEntry(MutableObjectVelocityUncertaintyACN entry) => MutableObjectVelocityUncertaintyACN.Validate(entry);

    Optional<IObjectVelocityUncertaintyACN> IEphemerisEntryInterpreter<IVectorsHeader, IObjectVelocityUncertaintyACN>.Interpret(IVectorsHeader header, QueryResult queryResult)
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

        /// <inheritdoc cref="IObjectVelocityUncertaintyACNComponentInterpreter"/>
        private IObjectVelocityUncertaintyACNComponentInterpreter VelocityUncertaintyComponentInterpreter { get; }

        /// <inheritdoc cref="EphemerisQuantityInterpretationDelegater"/>
        /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="EphemerisEpochInterpreter" path="/summary"/></param>
        /// <param name="positionComponentInterpreter"><inheritdoc cref="VelocityUncertaintyComponentInterpreter" path="/summary"/></param>
        public EphemerisQuantityInterpretationDelegater(IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectVelocityUncertaintyACNComponentInterpreter positionComponentInterpreter)
        {
            EphemerisEpochInterpreter = ephemerisEpochInterpreter;

            VelocityUncertaintyComponentInterpreter = positionComponentInterpreter;
        }

        MutableObjectVelocityUncertaintyACN IEphemerisQuantityInterpretationDelegater.Interpret(EphemerisQuantityIdentifier quantity, EphemerisQuantityTableIndex index, string text, IVectorsHeader header, MutableObjectVelocityUncertaintyACN ephemerisEntry)
        {
            return quantity.Identifier switch
            {
                "JDUT" or "JDTT" or "JDTDB" => Interpret(text, header, ephemerisEntry, EphemerisEpochInterpreter, static (ephemerisEntry, epoch) => ephemerisEntry.Epoch = epoch),
                "VA_s" => Interpret(text, header, ephemerisEntry, VelocityUncertaintyComponentInterpreter, static (ephemerisEntry, alongTrack) => ephemerisEntry.AlongTrack = alongTrack),
                "VC_s" => Interpret(text, header, ephemerisEntry, VelocityUncertaintyComponentInterpreter, static (ephemerisEntry, crossTrack) => ephemerisEntry.CrossTrack = crossTrack),
                "VN_s" => Interpret(text, header, ephemerisEntry, VelocityUncertaintyComponentInterpreter, static (ephemerisEntry, normal) => ephemerisEntry.Normal = normal),
                _ => ephemerisEntry
            };
        }

        /// <summary>Interprets a quantity of the <paramref name="ephemerisEntry"/> from <paramref name="text"/>.</summary>
        /// <typeparam name="TInterpretation">The type of the quantity interpreted by the <paramref name="interpreter"/>.</typeparam>
        /// <param name="text">The quantity of type <typeparamref name="TInterpretation"/> is interpreted from this <see cref="string"/>.</param>
        /// <param name="header">The <see cref="IVectorsHeader"/>, representing the header of the <see cref="QueryResult"/>.</param>
        /// <param name="ephemerisEntry">The <see cref="MutableObjectVelocityUncertaintyACN"/> to which the interpreted quantity is applied, using <paramref name="setter"/>.</param>
        /// <param name="interpreter">The <see cref="IEphemerisQuantityInterpreter{THeader, TInterpretation}"/> responsible for interpreting a quantity from <paramref name="text"/>.</param>
        /// <param name="setter">Delegates applying the quantity to the <paramref name="ephemerisEntry"/>.</param>
        private static MutableObjectVelocityUncertaintyACN Interpret<TInterpretation>(string text, IVectorsHeader header, MutableObjectVelocityUncertaintyACN ephemerisEntry, IEphemerisQuantityInterpreter<IVectorsHeader, TInterpretation> interpreter, Action<MutableObjectVelocityUncertaintyACN, TInterpretation> setter)
        {
            if (interpreter.Interpret(text, header) is { HasValue: true, Value: var interpretation })
            {
                setter(ephemerisEntry, interpretation);
            }

            return ephemerisEntry;
        }
    }
}
