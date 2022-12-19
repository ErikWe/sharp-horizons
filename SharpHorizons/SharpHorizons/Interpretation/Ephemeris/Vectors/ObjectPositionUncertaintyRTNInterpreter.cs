namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

using System;

/// <inheritdoc cref="IObjectPositionUncertaintyRTNInterpreter"/>
internal class ObjectPositionUncertaintyRTNInterpreter : AEphemerisEntryInterpreter<MutableObjectPositionUncertaintyRTN, IVectorsHeader>, IObjectPositionUncertaintyRTNInterpreter
{
    /// <inheritdoc cref="ObjectPositionUncertaintyRTNInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="IEphemerisEpochInterpreter" path="/summary"/></param>
    /// <param name="positionUncertaintyComponentInterpreter"><inheritdoc cref="IObjectPositionUncertaintyRTNComponentInterpreter" path="/summary"/></param>
    public ObjectPositionUncertaintyRTNInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectPositionUncertaintyRTNComponentInterpreter positionUncertaintyComponentInterpreter)
        : base(ephemerisInterpretationOptionsProvider, new EphemerisQuantityInterpretationDelegater(ephemerisEpochInterpreter, positionUncertaintyComponentInterpreter)) { }

    protected override MutableObjectPositionUncertaintyRTN CreateEntry() => new();
    protected override bool ValidateEntry(MutableObjectPositionUncertaintyRTN entry) => MutableObjectPositionUncertaintyRTN.Validate(entry);

    Optional<IObjectPositionUncertaintyRTN> IEphemerisEntryInterpreter<IVectorsHeader, IObjectPositionUncertaintyRTN>.Interpret(IVectorsHeader header, QueryResult queryResult)
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

        /// <inheritdoc cref="IObjectPositionUncertaintyRTNComponentInterpreter"/>
        private IObjectPositionUncertaintyRTNComponentInterpreter PositionUncertaintyComponentInterpreter { get; }

        /// <inheritdoc cref="EphemerisQuantityInterpretationDelegater"/>
        /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="EphemerisEpochInterpreter" path="/summary"/></param>
        /// <param name="positionComponentInterpreter"><inheritdoc cref="PositionUncertaintyComponentInterpreter" path="/summary"/></param>
        public EphemerisQuantityInterpretationDelegater(IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectPositionUncertaintyRTNComponentInterpreter positionComponentInterpreter)
        {
            EphemerisEpochInterpreter = ephemerisEpochInterpreter;

            PositionUncertaintyComponentInterpreter = positionComponentInterpreter;
        }

        MutableObjectPositionUncertaintyRTN IEphemerisQuantityInterpretationDelegater.Interpret(EphemerisQuantityIdentifier quantity, EphemerisQuantityTableIndex index, string text, IVectorsHeader header, MutableObjectPositionUncertaintyRTN ephemerisEntry)
        {
            return quantity.Identifier switch
            {
                "JDUT" or "JDTT" or "JDTDB" => Interpret(text, header, ephemerisEntry, EphemerisEpochInterpreter, static (ephemerisEntry, epoch) => ephemerisEntry.Epoch = epoch),
                "R_s" => Interpret(text, header, ephemerisEntry, PositionUncertaintyComponentInterpreter, static (ephemerisEntry, radial) => ephemerisEntry.Radial = radial),
                "T_s" => Interpret(text, header, ephemerisEntry, PositionUncertaintyComponentInterpreter, static (ephemerisEntry, transverse) => ephemerisEntry.Transverse = transverse),
                "N_s" => Interpret(text, header, ephemerisEntry, PositionUncertaintyComponentInterpreter, static (ephemerisEntry, normal) => ephemerisEntry.Normal = normal),
                _ => ephemerisEntry
            };
        }

        /// <summary>Interprets a quantity of the <paramref name="ephemerisEntry"/> from <paramref name="text"/>.</summary>
        /// <typeparam name="TInterpretation">The type of the quantity interpreted by the <paramref name="interpreter"/>.</typeparam>
        /// <param name="text">The quantity of type <typeparamref name="TInterpretation"/> is interpreted from this <see cref="string"/>.</param>
        /// <param name="header">The <see cref="IVectorsHeader"/>, representing the header of the <see cref="QueryResult"/>.</param>
        /// <param name="ephemerisEntry">The <see cref="MutableObjectPositionUncertaintyRTN"/> to which the interpreted quantity is applied, using <paramref name="setter"/>.</param>
        /// <param name="interpreter">The <see cref="IEphemerisQuantityInterpreter{THeader, TInterpretation}"/> responsible for interpreting a quantity from <paramref name="text"/>.</param>
        /// <param name="setter">Delegates applying the quantity to the <paramref name="ephemerisEntry"/>.</param>
        private static MutableObjectPositionUncertaintyRTN Interpret<TInterpretation>(string text, IVectorsHeader header, MutableObjectPositionUncertaintyRTN ephemerisEntry, IEphemerisQuantityInterpreter<IVectorsHeader, TInterpretation> interpreter, Action<MutableObjectPositionUncertaintyRTN, TInterpretation> setter)
        {
            if (interpreter.Interpret(text, header) is { HasValue: true, Value: var interpretation })
            {
                setter(ephemerisEntry, interpretation);
            }

            return ephemerisEntry;
        }
    }
}
