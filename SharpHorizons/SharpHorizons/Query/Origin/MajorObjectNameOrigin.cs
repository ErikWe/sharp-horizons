namespace SharpHorizons.Query.Origin;

using SharpHorizons.Composers.Arguments.Origin;
using SharpHorizons.Identity;

/// <summary>Describes the <see cref="IOriginObject"/> in a query as an object identified by a <see cref="MajorObjectName"/>.</summary>
internal sealed record class MajorObjectNameOrigin : IOriginObject
{
    /// <summary>The <see cref="MajorObjectName"/> of an object which represents the <see cref="IOriginObject"/> in a query.</summary>
    private MajorObjectName Name { get; }

    /// <summary>Used to compose a <see cref="OriginObjectIdentifier"/> describing <see langword="this"/>.</summary>
    private IOriginObjectComposer<MajorObjectName> Composer { get; }

    /// <summary>Describes the <see cref="IOriginObject"/> in a query as an object identified by <paramref name="name"/>.</summary>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public MajorObjectNameOrigin(MajorObjectName name, IOriginObjectComposer<MajorObjectName> composer)
    {
        Name = name;

        Composer = composer;
    }

    OriginObjectIdentifier IOriginObject.ComposeIdentifier() => Composer.Compose(Name);
}
