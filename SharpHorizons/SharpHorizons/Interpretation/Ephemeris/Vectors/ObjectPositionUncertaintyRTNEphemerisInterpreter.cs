namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris;
using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

/// <inheritdoc cref="IObjectPositionUncertaintyRTNEphemerisInterpreter"/>
internal sealed class ObjectPositionUncertaintyRTNEphemerisInterpreter : AEphemerisInterpreter<IObjectPositionUncertaintyRTN, IVectorsHeader>, IObjectPositionUncertaintyRTNEphemerisInterpreter
{
    /// <inheritdoc cref="ObjectPositionUncertaintyRTNEphemerisInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEntryInterpreter"><inheritdoc cref="IObjectPositionUncertaintyRTNInterpreter" path="/summary"/></param>
    public ObjectPositionUncertaintyRTNEphemerisInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IObjectPositionUncertaintyRTNInterpreter ephemerisEntryInterpreter)
        : base(ephemerisInterpretationOptionsProvider, ephemerisEntryInterpreter) { }

    IEphemeris<IObjectPositionUncertaintyRTN> IEphemerisInterpreter<IVectorsHeader, IObjectPositionUncertaintyRTN>.Interpret(IVectorsHeader header, QueryResult queryResult)
    {
        var ephemeris = InterpretEntries(header, queryResult);

        return GenericEphemerisFactory.FromOrdered(ephemeris);
    }
}
