﻿namespace SharpHorizons.Query.Arguments.Composers;

using SharpHorizons.Query;
using SharpHorizons.Query.Arguments;
using System.ComponentModel;

/// <inheritdoc cref="IObjectDataInclusionComposer"/>
internal sealed class ObjectDataInclusionComposer : IObjectDataInclusionComposer
{
    IObjectDataInclusionArgument IArgumentComposer<IObjectDataInclusionArgument, ObjectDataInclusion>.Compose(ObjectDataInclusion obj) => new QueryArgument(obj switch
    {
        ObjectDataInclusion.Disable => "NO",
        ObjectDataInclusion.Enable => "YES",
        _ => throw new InvalidEnumArgumentException(nameof(obj), (int)obj, typeof(ObjectDataInclusion))
    });
}