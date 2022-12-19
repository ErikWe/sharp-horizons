namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris;
using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

/// <inheritdoc cref="IObjectVelocityUncertaintyRTNEphemerisInterpreter"/>
internal sealed class ObjectVelocityUncertaintyRTNEphemerisInterpreter : AEphemerisInterpreter<IObjectVelocityUncertaintyRTN, IVectorsHeader>, IObjectVelocityUncertaintyRTNEphemerisInterpreter
{
    /// <inheritdoc cref="ObjectVelocityUncertaintyRTNEphemerisInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEntryInterpreter"><inheritdoc cref="IObjectVelocityUncertaintyRTNInterpreter" path="/summary"/></param>
    public ObjectVelocityUncertaintyRTNEphemerisInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IObjectVelocityUncertaintyRTNInterpreter ephemerisEntryInterpreter)
        : base(ephemerisInterpretationOptionsProvider, ephemerisEntryInterpreter) { }

    IEphemeris<IObjectVelocityUncertaintyRTN> IEphemerisInterpreter<IVectorsHeader, IObjectVelocityUncertaintyRTN>.Interpret(IVectorsHeader header, QueryResult queryResult)
    {
        var ephemeris = InterpretEntries(header, queryResult);

        return GenericEphemerisFactory.FromOrdered(ephemeris);
    }
}
