namespace SharpHorizons.Composers.Arguments.Target;

using SharpHorizons.Query;
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
}
