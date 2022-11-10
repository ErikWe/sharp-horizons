namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Query.Target;

using System;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="ISiteTarget"/>.</summary>
internal sealed class SiteTargetComposer : ITargetComposer<ISiteTarget>
{
    ITargetArgument IArgumentComposer<ITargetArgument, ISiteTarget>.Compose(ISiteTarget obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return new QueryArgument($"{obj.TargetSite.ComposeIdentifier()}@{obj.TargetSiteObject.ComposeIdentifier()}");
    }

    ICommandArgument IArgumentComposer<ICommandArgument, ISiteTarget>.Compose(ISiteTarget obj) => ((IArgumentComposer<ITargetArgument, ISiteTarget>)this).Compose(obj);
}
