namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris;
using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

/// <inheritdoc cref="IObjectVelocityUncertaintyPOSEphemerisInterpreter"/>
internal sealed class ObjectVelocityUncertaintyPOSEphemerisInterpreter : AEphemerisInterpreter<IObjectVelocityUncertaintyPOS, IVectorsHeader>, IObjectVelocityUncertaintyPOSEphemerisInterpreter
{
    /// <inheritdoc cref="ObjectVelocityUncertaintyPOSEphemerisInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEntryInterpreter"><inheritdoc cref="IObjectVelocityUncertaintyPOSInterpreter" path="/summary"/></param>
    public ObjectVelocityUncertaintyPOSEphemerisInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IObjectVelocityUncertaintyPOSInterpreter ephemerisEntryInterpreter)
        : base(ephemerisInterpretationOptionsProvider, ephemerisEntryInterpreter) { }

    IEphemeris<IObjectVelocityUncertaintyPOS> IEphemerisInterpreter<IVectorsHeader, IObjectVelocityUncertaintyPOS>.Interpret(IVectorsHeader header, QueryResult queryResult)
    {
        var ephemeris = InterpretEntries(header, queryResult);

        return GenericEphemerisFactory.FromOrdered(ephemeris);
    }
}
