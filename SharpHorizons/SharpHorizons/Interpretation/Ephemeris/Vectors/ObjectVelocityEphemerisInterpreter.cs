namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris;
using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

/// <inheritdoc cref="IObjectVelocityEphemerisInterpreter"/>
internal sealed class ObjectVelocityEphemerisInterpreter : AEphemerisInterpreter<IObjectVelocity, IVectorsHeader>, IObjectVelocityEphemerisInterpreter
{
    /// <inheritdoc cref="ObjectVelocityEphemerisInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEntryInterpreter"><inheritdoc cref="IObjectPositionInterpreter" path="/summary"/></param>
    public ObjectVelocityEphemerisInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IObjectVelocityInterpreter ephemerisEntryInterpreter)
        : base(ephemerisInterpretationOptionsProvider, ephemerisEntryInterpreter) { }

    IEphemeris<IObjectVelocity> IEphemerisInterpreter<IVectorsHeader, IObjectVelocity>.Interpret(IVectorsHeader header, QueryResult queryResult)
    {
        var ephemeris = InterpretEntries(header, queryResult);

        return GenericEphemerisFactory.FromOrdered(ephemeris);
    }
}
