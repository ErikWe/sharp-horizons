namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

using System;

/// <inheritdoc cref="IObjectPositionUncertaintyXYZInterpreter"/>
internal class ObjectPositionUncertaintyXYZInterpreter : AEphemerisEntryInterpreter<MutableObjectPositionUncertaintyXYZ, IVectorsHeader>, IObjectPositionUncertaintyXYZInterpreter
{
    /// <inheritdoc cref="ObjectPositionUncertaintyXYZInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="IEphemerisEpochInterpreter" path="/summary"/></param>
    /// <param name="positionUncertaintyComponentInterpreter"><inheritdoc cref="IObjectPositionUncertaintyXYZComponentInterpreter" path="/summary"/></param>
    public ObjectPositionUncertaintyXYZInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectPositionUncertaintyXYZComponentInterpreter positionUncertaintyComponentInterpreter)
        : base(ephemerisInterpretationOptionsProvider, new EphemerisQuantityInterpretationDelegater(ephemerisEpochInterpreter, positionUncertaintyComponentInterpreter)) { }

    protected override MutableObjectPositionUncertaintyXYZ CreateEntry() => new();
    protected override bool ValidateEntry(MutableObjectPositionUncertaintyXYZ entry) => MutableObjectPositionUncertaintyXYZ.Validate(entry);

    Optional<IObjectPositionUncertaintyXYZ> IEphemerisEntryInterpreter<IVectorsHeader, IObjectPositionUncertaintyXYZ>.Interpret(IVectorsHeader header, QueryResult queryResult)
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

        /// <inheritdoc cref="IObjectPositionUncertaintyXYZComponentInterpreter"/>
        private IObjectPositionUncertaintyXYZComponentInterpreter PositionUncertaintyComponentInterpreter { get; }

        /// <inheritdoc cref="EphemerisQuantityInterpretationDelegater"/>
        /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="EphemerisEpochInterpreter" path="/summary"/></param>
        /// <param name="positionComponentInterpreter"><inheritdoc cref="PositionUncertaintyComponentInterpreter" path="/summary"/></param>
        public EphemerisQuantityInterpretationDelegater(IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectPositionUncertaintyXYZComponentInterpreter positionComponentInterpreter)
        {
            EphemerisEpochInterpreter = ephemerisEpochInterpreter;

            PositionUncertaintyComponentInterpreter = positionComponentInterpreter;
        }

        MutableObjectPositionUncertaintyXYZ IEphemerisQuantityInterpretationDelegater.Interpret(EphemerisQuantityIdentifier quantity, EphemerisQuantityTableIndex index, string text, IVectorsHeader header, MutableObjectPositionUncertaintyXYZ ephemerisEntry)
        {
            return quantity.Identifier switch
            {
                "JDUT" or "JDTT" or "JDTDB" => Interpret(text, header, ephemerisEntry, EphemerisEpochInterpreter, static (ephemerisEntry, epoch) => ephemerisEntry.Epoch = epoch),
                "X_s" => Interpret(text, header, ephemerisEntry, PositionUncertaintyComponentInterpreter, static (ephemerisEntry, uncertaintyX) => ephemerisEntry.UncertaintyX = uncertaintyX),
                "Y_s" => Interpret(text, header, ephemerisEntry, PositionUncertaintyComponentInterpreter, static (ephemerisEntry, uncertaintyY) => ephemerisEntry.UncertaintyY = uncertaintyY),
                "Z_s" => Interpret(text, header, ephemerisEntry, PositionUncertaintyComponentInterpreter, static (ephemerisEntry, uncertaintyZ) => ephemerisEntry.UncertaintyZ = uncertaintyZ),
                _ => ephemerisEntry
            };
        }

        /// <summary>Interprets a quantity of the <paramref name="ephemerisEntry"/> from <paramref name="text"/>.</summary>
        /// <typeparam name="TInterpretation">The type of the quantity interpreted by the <paramref name="interpreter"/>.</typeparam>
        /// <param name="text">The quantity of type <typeparamref name="TInterpretation"/> is interpreted from this <see cref="string"/>.</param>
        /// <param name="header">The <see cref="IVectorsHeader"/>, representing the header of the <see cref="QueryResult"/>.</param>
        /// <param name="ephemerisEntry">The <see cref="MutableObjectPositionUncertaintyXYZ"/> to which the interpreted quantity is applied, using <paramref name="setter"/>.</param>
        /// <param name="interpreter">The <see cref="IEphemerisQuantityInterpreter{THeader, TInterpretation}"/> responsible for interpreting a quantity from <paramref name="text"/>.</param>
        /// <param name="setter">Delegates applying the quantity to the <paramref name="ephemerisEntry"/>.</param>
        private static MutableObjectPositionUncertaintyXYZ Interpret<TInterpretation>(string text, IVectorsHeader header, MutableObjectPositionUncertaintyXYZ ephemerisEntry, IEphemerisQuantityInterpreter<IVectorsHeader, TInterpretation> interpreter, Action<MutableObjectPositionUncertaintyXYZ, TInterpretation> setter)
        {
            if (interpreter.Interpret(text, header) is { HasValue: true, Value: var interpretation })
            {
                setter(ephemerisEntry, interpretation);
            }

            return ephemerisEntry;
        }
    }
}
