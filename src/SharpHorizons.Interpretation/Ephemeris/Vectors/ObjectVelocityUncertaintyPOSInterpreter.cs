namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IObjectVelocityUncertaintyPOSInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class ObjectVelocityUncertaintyPOSInterpreter : AEphemerisEntryInterpreter<MutableObjectVelocityUncertaintyPOS, IVectorsHeader>, IObjectVelocityUncertaintyPOSInterpreter
{
    /// <inheritdoc cref="ObjectVelocityUncertaintyPOSInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="IEphemerisEpochInterpreter" path="/summary"/></param>
    /// <param name="positionUncertaintyComponentInterpreter"><inheritdoc cref="IObjectVelocityUncertaintyPOSComponentInterpreter" path="/summary"/></param>
    public ObjectVelocityUncertaintyPOSInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectVelocityUncertaintyPOSComponentInterpreter positionUncertaintyComponentInterpreter)
        : base(ephemerisInterpretationOptionsProvider, new EphemerisQuantityInterpretationDelegater(ephemerisEpochInterpreter, positionUncertaintyComponentInterpreter)) { }

    protected override MutableObjectVelocityUncertaintyPOS CreateEntry() => new();
    protected override bool ValidateEntry(MutableObjectVelocityUncertaintyPOS entry) => MutableObjectVelocityUncertaintyPOS.Validate(entry);

    Optional<IObjectVelocityUncertaintyPOS> IEphemerisEntryInterpreter<IVectorsHeader, IObjectVelocityUncertaintyPOS>.Interpret(IVectorsHeader header, QueryResult queryResult)
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

        /// <inheritdoc cref="IObjectVelocityUncertaintyPOSComponentInterpreter"/>
        private IObjectVelocityUncertaintyPOSComponentInterpreter VelocityUncertaintyComponentInterpreter { get; }

        /// <inheritdoc cref="EphemerisQuantityInterpretationDelegater"/>
        /// <param name="ephemerisEpochInterpreter"><inheritdoc cref="EphemerisEpochInterpreter" path="/summary"/></param>
        /// <param name="positionComponentInterpreter"><inheritdoc cref="VelocityUncertaintyComponentInterpreter" path="/summary"/></param>
        public EphemerisQuantityInterpretationDelegater(IEphemerisEpochInterpreter ephemerisEpochInterpreter, IObjectVelocityUncertaintyPOSComponentInterpreter positionComponentInterpreter)
        {
            EphemerisEpochInterpreter = ephemerisEpochInterpreter;

            VelocityUncertaintyComponentInterpreter = positionComponentInterpreter;
        }

        MutableObjectVelocityUncertaintyPOS IEphemerisQuantityInterpretationDelegater.Interpret(EphemerisQuantityIdentifier quantity, EphemerisQuantityTableIndex index, string text, IVectorsHeader header, MutableObjectVelocityUncertaintyPOS ephemerisEntry)
        {
            return quantity.Identifier switch
            {
                "JDUT" or "JDTT" or "JDTDB" => Interpret(text, header, ephemerisEntry, EphemerisEpochInterpreter, static (ephemerisEntry, epoch) => ephemerisEntry.Epoch = epoch),
                "VR_s" => Interpret(text, header, ephemerisEntry, VelocityUncertaintyComponentInterpreter, static (ephemerisEntry, radial) => ephemerisEntry.Radial = radial),
                "VA_RA_s" => Interpret(text, header, ephemerisEntry, VelocityUncertaintyComponentInterpreter, static (ephemerisEntry, rightAscension) => ephemerisEntry.RightAscension = rightAscension),
                "VD_DEC_s" => Interpret(text, header, ephemerisEntry, VelocityUncertaintyComponentInterpreter, static (ephemerisEntry, declination) => ephemerisEntry.Declination = declination),
                _ => ephemerisEntry
            };
        }

        /// <summary>Interprets a quantity of the <paramref name="ephemerisEntry"/> from <paramref name="text"/>.</summary>
        /// <typeparam name="TInterpretation">The type of the quantity interpreted by the <paramref name="interpreter"/>.</typeparam>
        /// <param name="text">The quantity of type <typeparamref name="TInterpretation"/> is interpreted from this <see cref="string"/>.</param>
        /// <param name="header">The <see cref="IVectorsHeader"/>, representing the header of the <see cref="QueryResult"/>.</param>
        /// <param name="ephemerisEntry">The <see cref="MutableObjectVelocityUncertaintyPOS"/> to which the interpreted quantity is applied, using <paramref name="setter"/>.</param>
        /// <param name="interpreter">The <see cref="IEphemerisQuantityInterpreter{THeader, TInterpretation}"/> responsible for interpreting a quantity from <paramref name="text"/>.</param>
        /// <param name="setter">Delegates applying the quantity to the <paramref name="ephemerisEntry"/>.</param>
        private static MutableObjectVelocityUncertaintyPOS Interpret<TInterpretation>(string text, IVectorsHeader header, MutableObjectVelocityUncertaintyPOS ephemerisEntry, IEphemerisQuantityInterpreter<IVectorsHeader, TInterpretation> interpreter, Action<MutableObjectVelocityUncertaintyPOS, TInterpretation> setter)
        {
            if (interpreter.Interpret(text, header) is { HasValue: true, Value: var interpretation })
            {
                setter(ephemerisEntry, interpretation);
            }

            return ephemerisEntry;
        }
    }
}
