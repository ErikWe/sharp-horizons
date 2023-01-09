namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IObjectVelocityUncertaintyXYZInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class ObjectVelocityUncertaintyXYZInterpreter : AEphemerisEntryInterpreter<MutableObjectVelocityUncertaintyXYZ, IVectorsHeader>, IObjectVelocityUncertaintyXYZInterpreter
{
    /// <inheritdoc cref="ObjectVelocityUncertaintyXYZInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="IEphemerisEpochInterpreter" path="/summary"/></param>
    /// <param name="positionUncertaintyComponentInterpreter"><inheritdoc cref="IObjectVelocityUncertaintyXYZComponentInterpreter" path="/summary"/></param>
    public ObjectVelocityUncertaintyXYZInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectVelocityUncertaintyXYZComponentInterpreter positionUncertaintyComponentInterpreter)
        : base(ephemerisInterpretationOptionsProvider, new EphemerisQuantityInterpretationDelegater(ephemerisEpochInterpreter, positionUncertaintyComponentInterpreter)) { }

    protected override MutableObjectVelocityUncertaintyXYZ CreateEntry() => new();
    protected override bool ValidateEntry(MutableObjectVelocityUncertaintyXYZ entry) => MutableObjectVelocityUncertaintyXYZ.Validate(entry);

    Optional<IObjectVelocityUncertaintyXYZ> IEphemerisEntryInterpreter<IVectorsHeader, IObjectVelocityUncertaintyXYZ>.Interpret(IVectorsHeader header, QueryResult queryResult)
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

        /// <inheritdoc cref="IObjectVelocityUncertaintyXYZComponentInterpreter"/>
        private IObjectVelocityUncertaintyXYZComponentInterpreter VelocityUncertaintyComponentInterpreter { get; }

        /// <inheritdoc cref="EphemerisQuantityInterpretationDelegater"/>
        /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="EphemerisEpochInterpreter" path="/summary"/></param>
        /// <param name="positionComponentInterpreter"><inheritdoc cref="VelocityUncertaintyComponentInterpreter" path="/summary"/></param>
        public EphemerisQuantityInterpretationDelegater(IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectVelocityUncertaintyXYZComponentInterpreter positionComponentInterpreter)
        {
            EphemerisEpochInterpreter = ephemerisEpochInterpreter;

            VelocityUncertaintyComponentInterpreter = positionComponentInterpreter;
        }

        MutableObjectVelocityUncertaintyXYZ IEphemerisQuantityInterpretationDelegater.Interpret(EphemerisQuantityIdentifier quantity, EphemerisQuantityTableIndex index, string text, IVectorsHeader header, MutableObjectVelocityUncertaintyXYZ ephemerisEntry)
        {
            return quantity.Identifier switch
            {
                "JDUT" or "JDTT" or "JDTDB" => Interpret(text, header, ephemerisEntry, EphemerisEpochInterpreter, static (ephemerisEntry, epoch) => ephemerisEntry.Epoch = epoch),
                "VX_s" => Interpret(text, header, ephemerisEntry, VelocityUncertaintyComponentInterpreter, static (ephemerisEntry, uncertaintyX) => ephemerisEntry.UncertaintyX = uncertaintyX),
                "VY_s" => Interpret(text, header, ephemerisEntry, VelocityUncertaintyComponentInterpreter, static (ephemerisEntry, uncertaintyY) => ephemerisEntry.UncertaintyY = uncertaintyY),
                "VZ_s" => Interpret(text, header, ephemerisEntry, VelocityUncertaintyComponentInterpreter, static (ephemerisEntry, uncertaintyZ) => ephemerisEntry.UncertaintyZ = uncertaintyZ),
                _ => ephemerisEntry
            };
        }

        /// <summary>Interprets a quantity of the <paramref name="ephemerisEntry"/> from <paramref name="text"/>.</summary>
        /// <typeparam name="TInterpretation">The type of the quantity interpreted by the <paramref name="interpreter"/>.</typeparam>
        /// <param name="text">The quantity of type <typeparamref name="TInterpretation"/> is interpreted from this <see cref="string"/>.</param>
        /// <param name="header">The <see cref="IVectorsHeader"/>, representing the header of the <see cref="QueryResult"/>.</param>
        /// <param name="ephemerisEntry">The <see cref="MutableObjectVelocityUncertaintyXYZ"/> to which the interpreted quantity is applied, using <paramref name="setter"/>.</param>
        /// <param name="interpreter">The <see cref="IEphemerisQuantityInterpreter{THeader, TInterpretation}"/> responsible for interpreting a quantity from <paramref name="text"/>.</param>
        /// <param name="setter">Delegates applying the quantity to the <paramref name="ephemerisEntry"/>.</param>
        private static MutableObjectVelocityUncertaintyXYZ Interpret<TInterpretation>(string text, IVectorsHeader header, MutableObjectVelocityUncertaintyXYZ ephemerisEntry, IEphemerisQuantityInterpreter<IVectorsHeader, TInterpretation> interpreter, Action<MutableObjectVelocityUncertaintyXYZ, TInterpretation> setter)
        {
            if (interpreter.Interpret(text, header) is { HasValue: true, Value: var interpretation })
            {
                setter(ephemerisEntry, interpretation);
            }

            return ephemerisEntry;
        }
    }
}
