namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris;
using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

/// <inheritdoc cref="IObjectVelocityUncertaintyXYZEphemerisInterpreter"/>
internal sealed class ObjectVelocityUncertaintyXYZEphemerisInterpreter : AEphemerisInterpreter<IObjectVelocityUncertaintyXYZ, IVectorsHeader>, IObjectVelocityUncertaintyXYZEphemerisInterpreter
{
    /// <inheritdoc cref="ObjectVelocityUncertaintyXYZEphemerisInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEntryInterpreter"><inheritdoc cref="IObjectVelocityUncertaintyXYZInterpreter" path="/summary"/></param>
    public ObjectVelocityUncertaintyXYZEphemerisInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IObjectVelocityUncertaintyXYZInterpreter ephemerisEntryInterpreter)
        : base(ephemerisInterpretationOptionsProvider, ephemerisEntryInterpreter) { }

    IEphemeris<IObjectVelocityUncertaintyXYZ> IEphemerisInterpreter<IVectorsHeader, IObjectVelocityUncertaintyXYZ>.Interpret(IVectorsHeader header, QueryResult queryResult)
    {
        var ephemeris = InterpretEntries(header, queryResult);

        return GenericEphemerisFactory.FromOrdered(ephemeris);
    }
}
