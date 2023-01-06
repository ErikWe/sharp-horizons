namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.MPC;
using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="MPCProvisionalObject"/>.</summary>
internal sealed class MPCProvisionalObjectInterpreter : IInterpreter<MPCProvisionalObject>
{
    /// <inheritdoc cref="Ephemeris.MPCProvisionalDesignationInterpreter"/>
    private IInterpreter<MPCProvisionalDesignation> MPCProvisionalDesignationInterpreter { get; }

    /// <inheritdoc cref="MPCProvisionalObjectInterpreter"/>
    /// <param name="mpcProvisionalDesignationInterpreter"><inheritdoc cref="MPCProvisionalDesignationInterpreter" path="/summary"/></param>
    public MPCProvisionalObjectInterpreter(IInterpreter<MPCProvisionalDesignation> mpcProvisionalDesignationInterpreter)
    {
        MPCProvisionalDesignationInterpreter = mpcProvisionalDesignationInterpreter;
    }

    Optional<MPCProvisionalObject> IInterpreter<MPCProvisionalObject>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        if (queryResult.Content[0] is not '(')
        {
            return new();
        }

        if (MPCProvisionalDesignationInterpreter.Interpret(queryResult) is not { HasValue: true, Value: var designation })
        {
            return new();
        }

        return new MPCProvisionalObject(designation);
    }
}
