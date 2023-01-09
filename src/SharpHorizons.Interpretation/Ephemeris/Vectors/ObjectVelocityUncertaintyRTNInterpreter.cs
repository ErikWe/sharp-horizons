namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IObjectVelocityUncertaintyRTNInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class ObjectVelocityUncertaintyRTNInterpreter : AEphemerisEntryInterpreter<MutableObjectVelocityUncertaintyRTN, IVectorsHeader>, IObjectVelocityUncertaintyRTNInterpreter
{
    /// <inheritdoc cref="ObjectVelocityUncertaintyRTNInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="IEphemerisEpochInterpreter" path="/summary"/></param>
    /// <param name="positionUncertaintyComponentInterpreter"><inheritdoc cref="IObjectVelocityUncertaintyRTNComponentInterpreter" path="/summary"/></param>
    public ObjectVelocityUncertaintyRTNInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectVelocityUncertaintyRTNComponentInterpreter positionUncertaintyComponentInterpreter)
        : base(ephemerisInterpretationOptionsProvider, new EphemerisQuantityInterpretationDelegater(ephemerisEpochInterpreter, positionUncertaintyComponentInterpreter)) { }

    protected override MutableObjectVelocityUncertaintyRTN CreateEntry() => new();
    protected override bool ValidateEntry(MutableObjectVelocityUncertaintyRTN entry) => MutableObjectVelocityUncertaintyRTN.Validate(entry);

    Optional<IObjectVelocityUncertaintyRTN> IEphemerisEntryInterpreter<IVectorsHeader, IObjectVelocityUncertaintyRTN>.Interpret(IVectorsHeader header, QueryResult queryResult)
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

        /// <inheritdoc cref="IObjectVelocityUncertaintyRTNComponentInterpreter"/>
        private IObjectVelocityUncertaintyRTNComponentInterpreter VelocityUncertaintyComponentInterpreter { get; }

        /// <inheritdoc cref="EphemerisQuantityInterpretationDelegater"/>
        /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="EphemerisEpochInterpreter" path="/summary"/></param>
        /// <param name="positionComponentInterpreter"><inheritdoc cref="VelocityUncertaintyComponentInterpreter" path="/summary"/></param>
        public EphemerisQuantityInterpretationDelegater(IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectVelocityUncertaintyRTNComponentInterpreter positionComponentInterpreter)
        {
            EphemerisEpochInterpreter = ephemerisEpochInterpreter;

            VelocityUncertaintyComponentInterpreter = positionComponentInterpreter;
        }

        MutableObjectVelocityUncertaintyRTN IEphemerisQuantityInterpretationDelegater.Interpret(EphemerisQuantityIdentifier quantity, EphemerisQuantityTableIndex index, string text, IVectorsHeader header, MutableObjectVelocityUncertaintyRTN ephemerisEntry)
        {
            return quantity.Identifier switch
            {
                "JDUT" or "JDTT" or "JDTDB" => Interpret(text, header, ephemerisEntry, EphemerisEpochInterpreter, static (ephemerisEntry, epoch) => ephemerisEntry.Epoch = epoch),
                "VR_s" => Interpret(text, header, ephemerisEntry, VelocityUncertaintyComponentInterpreter, static (ephemerisEntry, radial) => ephemerisEntry.Radial = radial),
                "VT_s" => Interpret(text, header, ephemerisEntry, VelocityUncertaintyComponentInterpreter, static (ephemerisEntry, transverse) => ephemerisEntry.Transverse = transverse),
                "VN_s" => Interpret(text, header, ephemerisEntry, VelocityUncertaintyComponentInterpreter, static (ephemerisEntry, normal) => ephemerisEntry.Normal = normal),
                _ => ephemerisEntry
            };
        }

        /// <summary>Interprets a quantity of the <paramref name="ephemerisEntry"/> from <paramref name="text"/>.</summary>
        /// <typeparam name="TInterpretation">The type of the quantity interpreted by the <paramref name="interpreter"/>.</typeparam>
        /// <param name="text">The quantity of type <typeparamref name="TInterpretation"/> is interpreted from this <see cref="string"/>.</param>
        /// <param name="header">The <see cref="IVectorsHeader"/>, representing the header of the <see cref="QueryResult"/>.</param>
        /// <param name="ephemerisEntry">The <see cref="MutableObjectVelocityUncertaintyRTN"/> to which the interpreted quantity is applied, using <paramref name="setter"/>.</param>
        /// <param name="interpreter">The <see cref="IEphemerisQuantityInterpreter{THeader, TInterpretation}"/> responsible for interpreting a quantity from <paramref name="text"/>.</param>
        /// <param name="setter">Delegates applying the quantity to the <paramref name="ephemerisEntry"/>.</param>
        private static MutableObjectVelocityUncertaintyRTN Interpret<TInterpretation>(string text, IVectorsHeader header, MutableObjectVelocityUncertaintyRTN ephemerisEntry, IEphemerisQuantityInterpreter<IVectorsHeader, TInterpretation> interpreter, Action<MutableObjectVelocityUncertaintyRTN, TInterpretation> setter)
        {
            if (interpreter.Interpret(text, header) is { HasValue: true, Value: var interpretation })
            {
                setter(ephemerisEntry, interpretation);
            }

            return ephemerisEntry;
        }
    }
}
