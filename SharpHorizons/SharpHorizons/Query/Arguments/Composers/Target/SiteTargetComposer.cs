namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Query.Target;

using System;
using System.Runtime.CompilerServices;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="ISiteTarget"/>.</summary>
internal sealed class SiteTargetComposer : ITargetComposer<ISiteTarget>
{
    ITargetArgument IArgumentComposer<ITargetArgument, ISiteTarget>.Compose(ISiteTarget obj)
    {
        Validate(obj);

        return new QueryArgument($"{obj.TargetSite.ComposeIdentifier()}@{obj.TargetObject.ComposeIdentifier()}");
    }

    ICommandArgument IArgumentComposer<ICommandArgument, ISiteTarget>.Compose(ISiteTarget obj) => ((IArgumentComposer<ITargetArgument, ISiteTarget>)this).Compose(obj);

    /// <summary>Validates the <see cref="ISiteTarget"/> <paramref name="siteTarget"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="siteTarget">This <see cref="ISiteTarget"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="siteTarget"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(ISiteTarget siteTarget, [CallerArgumentExpression(nameof(siteTarget))] string? argumentExpression = null)
    {
        ArgumentNullException.ThrowIfNull(siteTarget, argumentExpression);

        try
        {
            ArgumentNullException.ThrowIfNull(siteTarget.TargetSite);
            ArgumentNullException.ThrowIfNull(siteTarget.TargetObject);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<ISiteTarget>(argumentExpression, e);
        }
    }
}
