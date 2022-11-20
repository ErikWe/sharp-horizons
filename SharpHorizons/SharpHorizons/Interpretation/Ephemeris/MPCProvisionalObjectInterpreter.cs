namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Identity;
using SharpHorizons.Query.Result;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="MPCProvisionalObject"/>.</summary>
internal sealed class MPCProvisionalObjectInterpreter : IPartInterpreter<MPCProvisionalObject>
{
    /// <inheritdoc cref="Ephemeris.MPCProvisionalDesignationInterpreter"/>
    private IPartInterpreter<MPCProvisionalDesignation> MPCProvisionalDesignationInterpreter { get; }

    /// <inheritdoc cref="MPCProvisionalObjectInterpreter"/>
    /// <param name="mpcProvisionalDesignationInterpreter"><inheritdoc cref="MPCProvisionalDesignationInterpreter" path="/summary"/></param>
    public MPCProvisionalObjectInterpreter(IPartInterpreter<MPCProvisionalDesignation> mpcProvisionalDesignationInterpreter)
    {
        MPCProvisionalDesignationInterpreter = mpcProvisionalDesignationInterpreter;
    }

    Optional<MPCProvisionalObject> IPartInterpreter<MPCProvisionalObject>.TryInterpret(string queryPart)
    {
        if (queryPart[0] is not '(')
        {
            return new();
        }

        if (MPCProvisionalDesignationInterpreter.TryInterpret(queryPart) is not { HasValue: true, Value: var designation })
        {
            return new();
        }

        return new MPCProvisionalObject(designation);
    }
}
