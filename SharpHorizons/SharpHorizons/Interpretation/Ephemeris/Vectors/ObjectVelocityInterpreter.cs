namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

using System;

/// <inheritdoc cref="IObjectVelocityInterpreter"/>
internal class ObjectVelocityInterpreter : AEphemerisEntryInterpreter<MutableObjectVelocity, IVectorsHeader>, IObjectVelocityInterpreter
{
    /// <inheritdoc cref="ObjectVelocityInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="IEphemerisEpochInterpreter" path="/summary"/></param>
    /// <param name="velocityComponentInterpreter"><inheritdoc cref="IObjectVelocityComponentInterpreter" path="/summary"/></param>
    public ObjectVelocityInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectVelocityComponentInterpreter velocityComponentInterpreter)
        : base(ephemerisInterpretationOptionsProvider, new EphemerisQuantityInterpretationDelegater(ephemerisEpochInterpreter, velocityComponentInterpreter)) { }

    protected override MutableObjectVelocity CreateEntry() => new();
    protected override bool ValidateEntry(MutableObjectVelocity entry) => MutableObjectVelocity.Validate(entry);

    Optional<IObjectVelocity> IEphemerisEntryInterpreter<IVectorsHeader, IObjectVelocity>.Interpret(IVectorsHeader header, QueryResult queryResult)
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

        /// <inheritdoc cref="IObjectVelocityComponentInterpreter"/>
        private IObjectVelocityComponentInterpreter VelocityComponentInterpreter { get; }

        /// <inheritdoc cref="EphemerisQuantityInterpretationDelegater"/>
        /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="EphemerisEpochInterpreter" path="/summary"/></param>
        /// <param name="velocityComponentInterpreter"><inheritdoc cref="VelocityComponentInterpreter" path="/summary"/></param>
        public EphemerisQuantityInterpretationDelegater(IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectVelocityComponentInterpreter velocityComponentInterpreter)
        {
            EphemerisEpochInterpreter = ephemerisEpochInterpreter;

            VelocityComponentInterpreter = velocityComponentInterpreter;
        }

        MutableObjectVelocity IEphemerisQuantityInterpretationDelegater.Interpret(EphemerisQuantityIdentifier quantity, EphemerisQuantityTableIndex index, string text, IVectorsHeader header, MutableObjectVelocity ephemerisEntry)
        {
            return quantity.Identifier switch
            {
                "JDUT" or "JDTT" or "JDTDB" => Interpret(text, header, ephemerisEntry, EphemerisEpochInterpreter, static (ephemerisEntry, epoch) => ephemerisEntry.Epoch = epoch),
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
        /// <param name="ephemerisEntry">The <see cref="MutableObjectVelocity"/> to which the interpreted quantity is applied, using <paramref name="setter"/>.</param>
        /// <param name="interpreter">The <see cref="IEphemerisQuantityInterpreter{THeader, TInterpretation}"/> responsible for interpreting a quantity from <paramref name="text"/>.</param>
        /// <param name="setter">Delegates applying the quantity to the <paramref name="ephemerisEntry"/>.</param>
        private static MutableObjectVelocity Interpret<TInterpretation>(string text, IVectorsHeader header, MutableObjectVelocity ephemerisEntry, IEphemerisQuantityInterpreter<IVectorsHeader, TInterpretation> interpreter, Action<MutableObjectVelocity, TInterpretation> setter)
        {
            if (interpreter.Interpret(text, header) is { HasValue: true, Value: var interpretation })
            {
                setter(ephemerisEntry, interpretation);
            }

            return ephemerisEntry;
        }
    }
}
