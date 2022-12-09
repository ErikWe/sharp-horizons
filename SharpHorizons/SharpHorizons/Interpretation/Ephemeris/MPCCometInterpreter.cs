namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.MPC;
using SharpHorizons.Query.Result;

using System;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="MPCComet"/>.</summary>
internal sealed class MPCCometInterpreter : IPartInterpreter<MPCComet>
{
    /// <inheritdoc cref="Ephemeris.MPCCometDesignationInterpreter"/>
    private IPartInterpreter<MPCCometDesignation> MPCCometDesignationInterpreter { get; }

    /// <inheritdoc cref="Ephemeris.MPCCometNameInterpreter"/>
    private IPartInterpreter<MPCCometName> MPCCometNameInterpreter { get; }

    /// <inheritdoc cref="MPCCometInterpreter"/>
    /// <param name="mpcCometDesignationInterpreter"><inheritdoc cref="MPCCometDesignationInterpreter" path="/summary"/></param>
    /// <param name="mpcCometNameInterpreter"><inheritdoc cref="MPCCometNameInterpreter" path="/summary"/></param>
    public MPCCometInterpreter(IPartInterpreter<MPCCometDesignation> mpcCometDesignationInterpreter, IPartInterpreter<MPCCometName> mpcCometNameInterpreter)
    {
        MPCCometDesignationInterpreter = mpcCometDesignationInterpreter;
        MPCCometNameInterpreter = mpcCometNameInterpreter;
    }

    Optional<MPCComet> IPartInterpreter<MPCComet>.TryInterpret(string queryPart)
    {
        ArgumentNullException.ThrowIfNull(queryPart);

        if (MPCCometDesignationInterpreter.TryInterpret(queryPart) is not { HasValue: true, Value: var designation })
        {
            return new();
        }

        if (MPCCometNameInterpreter.TryInterpret(queryPart) is not { HasValue: true, Value: var name })
        {
            return new MPCComet(designation);
        }

        return new MPCComet(designation, name);
    }
}
