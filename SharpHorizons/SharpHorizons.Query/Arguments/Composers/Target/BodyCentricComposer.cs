namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Query.Target;

using System;
using System.Runtime.CompilerServices;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="IBodyCentricTarget"/>.</summary>
internal sealed class BodyCentricComposer : ITargetComposer<IBodyCentricTarget>
{
    ITargetArgument IArgumentComposer<ITargetArgument, IBodyCentricTarget>.Compose(IBodyCentricTarget obj)
    {
        Validate(obj);

        return new QueryArgument($"g@{obj.TargetObject.ComposeIdentifier()}");
    }

    ICommandArgument IArgumentComposer<ICommandArgument, IBodyCentricTarget>.Compose(IBodyCentricTarget obj) => ((IArgumentComposer<ITargetArgument, IBodyCentricTarget>)this).Compose(obj);

    /// <summary>Validates the <see cref="IBodyCentricTarget"/> <paramref name="bodyCentricTarget"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="bodyCentricTarget">This <see cref="IBodyCentricTarget"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="bodyCentricTarget"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(IBodyCentricTarget bodyCentricTarget, [CallerArgumentExpression(nameof(bodyCentricTarget))] string? argumentExpression = null)
    {
        ArgumentNullException.ThrowIfNull(bodyCentricTarget, argumentExpression);

        try
        {
            ArgumentNullException.ThrowIfNull(bodyCentricTarget.TargetObject);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<ISiteTarget>(argumentExpression, e);
        }
    }
}
