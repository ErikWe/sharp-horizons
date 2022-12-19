namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

using System;

/// <inheritdoc cref="IObjectPositionInterpreter"/>
internal class ObjectPositionInterpreter : AEphemerisEntryInterpreter<MutableObjectPosition, IVectorsHeader>, IObjectPositionInterpreter
{
    /// <inheritdoc cref="ObjectPositionInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="IEphemerisEpochInterpreter" path="/summary"/></param>
    /// <param name="positionComponentInterpreter"><inheritdoc cref="IObjectPositionComponentInterpreter" path="/summary"/></param>
    public ObjectPositionInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectPositionComponentInterpreter positionComponentInterpreter)
        : base(ephemerisInterpretationOptionsProvider, new EphemerisQuantityInterpretationDelegater(ephemerisEpochInterpreter, positionComponentInterpreter)) { }

    protected override MutableObjectPosition CreateEntry() => new();
    protected override bool ValidateEntry(MutableObjectPosition entry) => MutableObjectPosition.Validate(entry);

    Optional<IObjectPosition> IEphemerisEntryInterpreter<IVectorsHeader, IObjectPosition>.Interpret(IVectorsHeader header, QueryResult queryResult)
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

        /// <inheritdoc cref="EphemerisQuantityInterpretationDelegater"/>
        /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="EphemerisEpochInterpreter" path="/summary"/></param>
        /// <param name="positionComponentInterpreter"><inheritdoc cref="PositionComponentInterpreter" path="/summary"/></param>
        public EphemerisQuantityInterpretationDelegater(IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectPositionComponentInterpreter positionComponentInterpreter)
        {
            EphemerisEpochInterpreter = ephemerisEpochInterpreter;

            PositionComponentInterpreter = positionComponentInterpreter;
        }

        MutableObjectPosition IEphemerisQuantityInterpretationDelegater.Interpret(EphemerisQuantityIdentifier quantity, EphemerisQuantityTableIndex index, string text, IVectorsHeader header, MutableObjectPosition ephemerisEntry)
        {
            return quantity.Identifier switch
            {
                "JDUT" or "JDTT" or "JDTDB" => Interpret(text, header, ephemerisEntry, EphemerisEpochInterpreter, static (ephemerisEntry, epoch) => ephemerisEntry.Epoch = epoch),
                "X" => Interpret(text, header, ephemerisEntry, PositionComponentInterpreter, static (ephemerisEntry, positionX) => ephemerisEntry.PositionX = positionX),
                "Y" => Interpret(text, header, ephemerisEntry, PositionComponentInterpreter, static (ephemerisEntry, positionY) => ephemerisEntry.PositionY = positionY),
                "Z" => Interpret(text, header, ephemerisEntry, PositionComponentInterpreter, static (ephemerisEntry, positionZ) => ephemerisEntry.PositionZ = positionZ),
                _ => ephemerisEntry
            };
        }

        /// <summary>Interprets a quantity of the <paramref name="ephemerisEntry"/> from <paramref name="text"/>.</summary>
        /// <typeparam name="TInterpretation">The type of the quantity interpreted by the <paramref name="interpreter"/>.</typeparam>
        /// <param name="text">The quantity of type <typeparamref name="TInterpretation"/> is interpreted from this <see cref="string"/>.</param>
        /// <param name="header">The <see cref="IVectorsHeader"/>, representing the header of the <see cref="QueryResult"/>.</param>
        /// <param name="ephemerisEntry">The <see cref="MutableObjectPosition"/> to which the interpreted quantity is applied, using <paramref name="setter"/>.</param>
        /// <param name="interpreter">The <see cref="IEphemerisQuantityInterpreter{THeader, TInterpretation}"/> responsible for interpreting a quantity from <paramref name="text"/>.</param>
        /// <param name="setter">Delegates applying the quantity to the <paramref name="ephemerisEntry"/>.</param>
        private static MutableObjectPosition Interpret<TInterpretation>(string text, IVectorsHeader header, MutableObjectPosition ephemerisEntry, IEphemerisQuantityInterpreter<IVectorsHeader, TInterpretation> interpreter, Action<MutableObjectPosition, TInterpretation> setter)
        {
            if (interpreter.Interpret(text, header) is { HasValue: true, Value: var interpretation })
            {
                setter(ephemerisEntry, interpretation);
            }

            return ephemerisEntry;
        }
    }
}
