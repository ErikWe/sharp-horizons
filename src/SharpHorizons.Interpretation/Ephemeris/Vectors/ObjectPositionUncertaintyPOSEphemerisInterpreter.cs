namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris;
using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IObjectPositionUncertaintyPOSEphemerisInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class ObjectPositionUncertaintyPOSEphemerisInterpreter : AEphemerisInterpreter<IObjectPositionUncertaintyPOS, IVectorsHeader>, IObjectPositionUncertaintyPOSEphemerisInterpreter
{
    /// <inheritdoc cref="ObjectPositionUncertaintyPOSEphemerisInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEntryInterpreter"><inheritdoc cref="IObjectPositionUncertaintyPOSInterpreter" path="/summary"/></param>
    public ObjectPositionUncertaintyPOSEphemerisInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IObjectPositionUncertaintyPOSInterpreter ephemerisEntryInterpreter)
        : base(ephemerisInterpretationOptionsProvider, ephemerisEntryInterpreter) { }

    IEphemeris<IObjectPositionUncertaintyPOS> IEphemerisInterpreter<IVectorsHeader, IObjectPositionUncertaintyPOS>.Interpret(IVectorsHeader header, QueryResult queryResult)
    {
        var ephemeris = InterpretEntries(header, queryResult);

        return GenericEphemerisFactory.FromOrdered(ephemeris);
    }
}
