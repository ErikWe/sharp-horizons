namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris;
using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

/// <inheritdoc cref="IObjectPositionUncertaintyXYZEphemerisInterpreter"/>
internal sealed class ObjectPositionUncertaintyXYZEphemerisInterpreter : AEphemerisInterpreter<IObjectPositionUncertaintyXYZ, IVectorsHeader>, IObjectPositionUncertaintyXYZEphemerisInterpreter
{
    /// <inheritdoc cref="ObjectPositionUncertaintyXYZEphemerisInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEntryInterpreter"><inheritdoc cref="IObjectPositionUncertaintyXYZInterpreter" path="/summary"/></param>
    public ObjectPositionUncertaintyXYZEphemerisInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IObjectPositionUncertaintyXYZInterpreter ephemerisEntryInterpreter)
        : base(ephemerisInterpretationOptionsProvider, ephemerisEntryInterpreter) { }

    IEphemeris<IObjectPositionUncertaintyXYZ> IEphemerisInterpreter<IVectorsHeader, IObjectPositionUncertaintyXYZ>.Interpret(IVectorsHeader header, QueryResult queryResult)
    {
        var ephemeris = InterpretEntries(header, queryResult);

        return GenericEphemerisFactory.FromOrdered(ephemeris);
    }
}
