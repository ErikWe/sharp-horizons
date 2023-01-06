namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris;
using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

/// <inheritdoc cref="IObjectVelocityUncertaintyACNEphemerisInterpreter"/>
internal sealed class ObjectVelocityUncertaintyACNEphemerisInterpreter : AEphemerisInterpreter<IObjectVelocityUncertaintyACN, IVectorsHeader>, IObjectVelocityUncertaintyACNEphemerisInterpreter
{
    /// <inheritdoc cref="ObjectVelocityUncertaintyACNEphemerisInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEntryInterpreter"><inheritdoc cref="IObjectVelocityUncertaintyACNInterpreter" path="/summary"/></param>
    public ObjectVelocityUncertaintyACNEphemerisInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IObjectVelocityUncertaintyACNInterpreter ephemerisEntryInterpreter)
        : base(ephemerisInterpretationOptionsProvider, ephemerisEntryInterpreter) { }

    IEphemeris<IObjectVelocityUncertaintyACN> IEphemerisInterpreter<IVectorsHeader, IObjectVelocityUncertaintyACN>.Interpret(IVectorsHeader header, QueryResult queryResult)
    {
        var ephemeris = InterpretEntries(header, queryResult);

        return GenericEphemerisFactory.FromOrdered(ephemeris);
    }
}
