namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris;
using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IObjectDistanceEphemerisInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class ObjectDistanceEphemerisInterpreter : AEphemerisInterpreter<IObjectDistance, IVectorsHeader>, IObjectDistanceEphemerisInterpreter
{
    /// <inheritdoc cref="ObjectDistanceEphemerisInterpreter"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="IEphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisEntryInterpreter"><inheritdoc cref="IObjectDistanceInterpreter" path="/summary"/></param>
    public ObjectDistanceEphemerisInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IObjectDistanceInterpreter ephemerisEntryInterpreter)
        : base(ephemerisInterpretationOptionsProvider, ephemerisEntryInterpreter) { }

    IEphemeris<IObjectDistance> IEphemerisInterpreter<IVectorsHeader, IObjectDistance>.Interpret(IVectorsHeader header, QueryResult queryResult)
    {
        var ephemeris = InterpretEntries(header, queryResult);

        return GenericEphemerisFactory.FromOrdered(ephemeris);
    }
}
