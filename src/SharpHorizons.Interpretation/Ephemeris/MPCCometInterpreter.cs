namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.MPC;
using SharpHorizons.Query.Result;

using System.Diagnostics.CodeAnalysis;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="MPCComet"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class MPCCometInterpreter : IInterpreter<MPCComet>
{
    /// <inheritdoc cref="Ephemeris.MPCCometDesignationInterpreter"/>
    private IInterpreter<MPCCometDesignation> MPCCometDesignationInterpreter { get; }

    /// <inheritdoc cref="Ephemeris.MPCCometNameInterpreter"/>
    private IInterpreter<MPCCometName> MPCCometNameInterpreter { get; }

    /// <inheritdoc cref="MPCCometInterpreter"/>
    /// <param name="mpcCometDesignationInterpreter"><inheritdoc cref="MPCCometDesignationInterpreter" path="/summary"/></param>
    /// <param name="mpcCometNameInterpreter"><inheritdoc cref="MPCCometNameInterpreter" path="/summary"/></param>
    public MPCCometInterpreter(IInterpreter<MPCCometDesignation> mpcCometDesignationInterpreter, IInterpreter<MPCCometName> mpcCometNameInterpreter)
    {
        MPCCometDesignationInterpreter = mpcCometDesignationInterpreter;
        MPCCometNameInterpreter = mpcCometNameInterpreter;
    }

    Optional<MPCComet> IInterpreter<MPCComet>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        if (MPCCometDesignationInterpreter.Interpret(queryResult) is not { HasValue: true, Value: var designation })
        {
            return new();
        }

        if (MPCCometNameInterpreter.Interpret(queryResult) is not { HasValue: true, Value: var name })
        {
            return new MPCComet(designation);
        }

        return new MPCComet(designation, name);
    }
}
