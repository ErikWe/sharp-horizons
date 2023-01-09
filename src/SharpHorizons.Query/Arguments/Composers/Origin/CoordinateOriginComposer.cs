namespace SharpHorizons.Query.Arguments.Composers.Origin;

using SharpHorizons.Query.Origin;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Composes <see cref="IOriginArgument"/> that describe <see cref="ICoordinateOrigin"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class CoordinateOriginComposer : IOriginComposer<ICoordinateOrigin>
{
    IOriginArgument IArgumentComposer<IOriginArgument, ICoordinateOrigin>.Compose(ICoordinateOrigin obj)
    {
        Validate(obj);

        return new QueryArgument($"c@{obj.OriginObject.ComposeIdentifier()}");
    }

    /// <summary>Validates the <see cref="ICoordinateOrigin"/> <paramref name="origin"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="origin">This <see cref="ICoordinateOrigin"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="origin"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(ICoordinateOrigin origin, [CallerArgumentExpression(nameof(origin))] string? argumentExpression = null)
    {
        ArgumentNullException.ThrowIfNull(origin, argumentExpression);

        try
        {
            ArgumentNullException.ThrowIfNull(origin.OriginObject);
        }
        catch (ArgumentNullException e)
        {
            throw ArgumentExceptionFactory.InvalidState<ICoordinateOrigin>(argumentExpression, e);
        }
    }
}
