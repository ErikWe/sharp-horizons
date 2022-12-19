namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

using System;

/// <inheritdoc cref="IObjectPositionUncertaintyACNInterpreter"/>
internal class ObjectPositionUncertaintyACNInterpreter : AEphemerisEntryInterpreter<MutableObjectPositionUncertaintyACN, IVectorsHeader>, IObjectPositionUncertaintyACNInterpreter
{
    /// <inheritdoc cref="ObjectPositionUncertaintyACNInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="IEphemerisEpochInterpreter" path="/summary"/></param>
    /// <param name="positionUncertaintyComponentInterpreter"><inheritdoc cref="IObjectPositionUncertaintyACNComponentInterpreter" path="/summary"/></param>
    public ObjectPositionUncertaintyACNInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectPositionUncertaintyACNComponentInterpreter positionUncertaintyComponentInterpreter)
        : base(ephemerisInterpretationOptionsProvider, new EphemerisQuantityInterpretationDelegater(ephemerisEpochInterpreter, positionUncertaintyComponentInterpreter)) { }

    protected override MutableObjectPositionUncertaintyACN CreateEntry() => new();
    protected override bool ValidateEntry(MutableObjectPositionUncertaintyACN entry) => MutableObjectPositionUncertaintyACN.Validate(entry);

    Optional<IObjectPositionUncertaintyACN> IEphemerisEntryInterpreter<IVectorsHeader, IObjectPositionUncertaintyACN>.Interpret(IVectorsHeader header, QueryResult queryResult)
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

        /// <inheritdoc cref="IObjectPositionUncertaintyACNComponentInterpreter"/>
        private IObjectPositionUncertaintyACNComponentInterpreter PositionUncertaintyComponentInterpreter { get; }

        /// <inheritdoc cref="EphemerisQuantityInterpretationDelegater"/>
        /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="EphemerisEpochInterpreter" path="/summary"/></param>
        /// <param name="positionComponentInterpreter"><inheritdoc cref="PositionUncertaintyComponentInterpreter" path="/summary"/></param>
        public EphemerisQuantityInterpretationDelegater(IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectPositionUncertaintyACNComponentInterpreter positionComponentInterpreter)
        {
            EphemerisEpochInterpreter = ephemerisEpochInterpreter;

            PositionUncertaintyComponentInterpreter = positionComponentInterpreter;
        }

        MutableObjectPositionUncertaintyACN IEphemerisQuantityInterpretationDelegater.Interpret(EphemerisQuantityIdentifier quantity, EphemerisQuantityTableIndex index, string text, IVectorsHeader header, MutableObjectPositionUncertaintyACN ephemerisEntry)
        {
            return quantity.Identifier switch
            {
                "JDUT" or "JDTT" or "JDTDB" => Interpret(text, header, ephemerisEntry, EphemerisEpochInterpreter, static (ephemerisEntry, epoch) => ephemerisEntry.Epoch = epoch),
                "A_s" => Interpret(text, header, ephemerisEntry, PositionUncertaintyComponentInterpreter, static (ephemerisEntry, alongTrack) => ephemerisEntry.AlongTrack = alongTrack),
                "C_s" => Interpret(text, header, ephemerisEntry, PositionUncertaintyComponentInterpreter, static (ephemerisEntry, crossTrack) => ephemerisEntry.CrossTrack = crossTrack),
                "N_s" => Interpret(text, header, ephemerisEntry, PositionUncertaintyComponentInterpreter, static (ephemerisEntry, normal) => ephemerisEntry.Normal = normal),
                _ => ephemerisEntry
            };
        }

        /// <summary>Interprets a quantity of the <paramref name="ephemerisEntry"/> from <paramref name="text"/>.</summary>
        /// <typeparam name="TInterpretation">The type of the quantity interpreted by the <paramref name="interpreter"/>.</typeparam>
        /// <param name="text">The quantity of type <typeparamref name="TInterpretation"/> is interpreted from this <see cref="string"/>.</param>
        /// <param name="header">The <see cref="IVectorsHeader"/>, representing the header of the <see cref="QueryResult"/>.</param>
        /// <param name="ephemerisEntry">The <see cref="MutableObjectPositionUncertaintyACN"/> to which the interpreted quantity is applied, using <paramref name="setter"/>.</param>
        /// <param name="interpreter">The <see cref="IEphemerisQuantityInterpreter{THeader, TInterpretation}"/> responsible for interpreting a quantity from <paramref name="text"/>.</param>
        /// <param name="setter">Delegates applying the quantity to the <paramref name="ephemerisEntry"/>.</param>
        private static MutableObjectPositionUncertaintyACN Interpret<TInterpretation>(string text, IVectorsHeader header, MutableObjectPositionUncertaintyACN ephemerisEntry, IEphemerisQuantityInterpreter<IVectorsHeader, TInterpretation> interpreter, Action<MutableObjectPositionUncertaintyACN, TInterpretation> setter)
        {
            if (interpreter.Interpret(text, header) is { HasValue: true, Value: var interpretation })
            {
                setter(ephemerisEntry, interpretation);
            }

            return ephemerisEntry;
        }
    }
}
