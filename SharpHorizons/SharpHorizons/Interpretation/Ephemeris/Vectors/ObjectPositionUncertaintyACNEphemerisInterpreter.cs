namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris;
using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

/// <inheritdoc cref="IObjectPositionUncertaintyACNEphemerisInterpreter"/>
internal sealed class ObjectPositionUncertaintyACNEphemerisInterpreter : AEphemerisInterpreter<IObjectPositionUncertaintyACN, IVectorsHeader>, IObjectPositionUncertaintyACNEphemerisInterpreter
{
    /// <inheritdoc cref="ObjectPositionUncertaintyACNEphemerisInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEntryInterpreter"><inheritdoc cref="IObjectPositionUncertaintyACNInterpreter" path="/summary"/></param>
    public ObjectPositionUncertaintyACNEphemerisInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IObjectPositionUncertaintyACNInterpreter ephemerisEntryInterpreter)
        : base(ephemerisInterpretationOptionsProvider, ephemerisEntryInterpreter) { }

    IEphemeris<IObjectPositionUncertaintyACN> IEphemerisInterpreter<IVectorsHeader, IObjectPositionUncertaintyACN>.Interpret(IVectorsHeader header, QueryResult queryResult)
    {
        var ephemeris = InterpretEntries(header, queryResult);

        return GenericEphemerisFactory.FromOrdered(ephemeris);
    }
}
