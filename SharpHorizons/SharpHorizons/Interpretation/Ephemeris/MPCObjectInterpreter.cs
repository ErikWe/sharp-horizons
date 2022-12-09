namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.MPC;
using SharpHorizons.Query.Result;

using System;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="MPCObject"/>.</summary>
internal sealed class MPCObjectInterpreter : IPartInterpreter<MPCObject>
{
    /// <inheritdoc cref="Ephemeris.MPCProvisionalDesignationInterpreter"/>
    private IPartInterpreter<MPCProvisionalDesignation> MPCProvisionalDesignationInterpreter { get; }

    /// <inheritdoc cref="Ephemeris.MPCSequentialNumberInterpreter"/>
    private IPartInterpreter<MPCSequentialNumber> MPCSequentialNumberInterpreter { get; }

    /// <inheritdoc cref="Ephemeris.MPCNameInterpreter"/>
    private IPartInterpreter<MPCName> MPCNameInterpreter { get; }

    /// <inheritdoc cref="MPCObjectInterpreter"/>
    /// <param name="mpcProvisionalDesignationInterpreter"><inheritdoc cref="MPCProvisionalDesignationInterpreter" path="/summary"/></param>
    /// <param name="mpcSequentialNumberInterpreter"><inheritdoc cref="MPCSequentialNumberInterpreter" path="/summary"/></param>
    /// <param name="mpcNameInterpreter"><inheritdoc cref="MPCNameInterpreter" path="/summary"/></param>
    public MPCObjectInterpreter(IPartInterpreter<MPCProvisionalDesignation> mpcProvisionalDesignationInterpreter, IPartInterpreter<MPCSequentialNumber> mpcSequentialNumberInterpreter, IPartInterpreter<MPCName> mpcNameInterpreter)
    {
        MPCProvisionalDesignationInterpreter = mpcProvisionalDesignationInterpreter;
        MPCSequentialNumberInterpreter = mpcSequentialNumberInterpreter;
        MPCNameInterpreter = mpcNameInterpreter;
    }

    Optional<MPCObject> IPartInterpreter<MPCObject>.Interpret(string queryPart)
    {
        ArgumentNullException.ThrowIfNull(queryPart);

        if (MPCSequentialNumberInterpreter.Interpret(queryPart) is not { HasValue: true, Value: var number })
        {
            return new();
        }

        if (MPCProvisionalDesignationInterpreter.Interpret(queryPart) is not { HasValue: true, Value: var designation })
        {
            return new();
        }

        if (MPCNameInterpreter.Interpret(queryPart) is not { HasValue: true, Value: var name })
        {
            return MPCObject.Unnamed(number, designation);
        }

        return MPCObject.Named(number, name, designation);
    }
}
