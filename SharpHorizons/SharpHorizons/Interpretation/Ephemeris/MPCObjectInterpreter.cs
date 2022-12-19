namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.MPC;
using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="MPCObject"/>.</summary>
internal sealed class MPCObjectInterpreter : IInterpreter<MPCObject>
{
    /// <inheritdoc cref="Ephemeris.MPCProvisionalDesignationInterpreter"/>
    private IInterpreter<MPCProvisionalDesignation> MPCProvisionalDesignationInterpreter { get; }

    /// <inheritdoc cref="Ephemeris.MPCSequentialNumberInterpreter"/>
    private IInterpreter<MPCSequentialNumber> MPCSequentialNumberInterpreter { get; }

    /// <inheritdoc cref="Ephemeris.MPCNameInterpreter"/>
    private IInterpreter<MPCName> MPCNameInterpreter { get; }

    /// <inheritdoc cref="MPCObjectInterpreter"/>
    /// <param name="mpcProvisionalDesignationInterpreter"><inheritdoc cref="MPCProvisionalDesignationInterpreter" path="/summary"/></param>
    /// <param name="mpcSequentialNumberInterpreter"><inheritdoc cref="MPCSequentialNumberInterpreter" path="/summary"/></param>
    /// <param name="mpcNameInterpreter"><inheritdoc cref="MPCNameInterpreter" path="/summary"/></param>
    public MPCObjectInterpreter(IInterpreter<MPCProvisionalDesignation> mpcProvisionalDesignationInterpreter, IInterpreter<MPCSequentialNumber> mpcSequentialNumberInterpreter, IInterpreter<MPCName> mpcNameInterpreter)
    {
        MPCProvisionalDesignationInterpreter = mpcProvisionalDesignationInterpreter;
        MPCSequentialNumberInterpreter = mpcSequentialNumberInterpreter;
        MPCNameInterpreter = mpcNameInterpreter;
    }

    Optional<MPCObject> IInterpreter<MPCObject>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        if (MPCSequentialNumberInterpreter.Interpret(queryResult) is not { HasValue: true, Value: var number })
        {
            return new();
        }

        if (MPCProvisionalDesignationInterpreter.Interpret(queryResult) is not { HasValue: true, Value: var designation })
        {
            return new();
        }

        if (MPCNameInterpreter.Interpret(queryResult) is not { HasValue: true, Value: var name })
        {
            return MPCObject.Unnamed(number, designation);
        }

        return MPCObject.Named(number, name, designation);
    }
}
