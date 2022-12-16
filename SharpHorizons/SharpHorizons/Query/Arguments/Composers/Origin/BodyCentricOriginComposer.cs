namespace SharpHorizons.Query.Arguments.Composers.Origin;

using SharpHorizons.Query.Origin;

using System;
using System.Runtime.CompilerServices;

/// <summary>Composes <see cref="IOriginArgument"/> that describe <see cref="IBodyCentricOrigin"/>.</summary>
internal sealed class BodyCentricOriginComposer : IOriginComposer<IBodyCentricOrigin>
{
    IOriginArgument IArgumentComposer<IOriginArgument, IBodyCentricOrigin>.Compose(IBodyCentricOrigin obj)
    {
        Validate(obj);

        return new QueryArgument($"g@{obj.OriginObject.ComposeIdentifier()}");
    }

    /// <summary>Validates the <see cref="IBodyCentricOrigin"/> <paramref name="origin"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="origin">This <see cref="IBodyCentricOrigin"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="origin"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(IBodyCentricOrigin origin, [CallerArgumentExpression(nameof(origin))] string? argumentExpression = null)
    {
        ArgumentNullException.ThrowIfNull(origin, argumentExpression);

        try
        {
            ArgumentNullException.ThrowIfNull(origin.OriginObject);
        }
        catch (ArgumentNullException e)
        {
            throw ArgumentExceptionFactory.InvalidState<IBodyCentricOrigin>(argumentExpression, e);
        }
    }
}
