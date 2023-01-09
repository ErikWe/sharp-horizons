namespace SharpHorizons.Query.Arguments.Composers.Origin;

using SharpHorizons.Query.Origin;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Composes <see cref="OriginObjectIdentifier"/> that describe <see cref="MajorObject"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class MajorObjectComposer : IOriginObjectComposer<MajorObject>
{
    /// <summary>Used to compose a <see cref="OriginObjectIdentifier"/> that describe the <see cref="MajorObjectID"/> associated with a <see cref="MajorObject"/>.</summary>
    private IOriginObjectComposer<MajorObjectID> MajorObjectIDComposer { get; }

    /// <inheritdoc cref="MajorObjectComposer"/>
    /// <param name="majorObjectIDComposer"><inheritdoc cref="MajorObjectIDComposer" path="/summary"/></param>
    public MajorObjectComposer(IOriginObjectComposer<MajorObjectID> majorObjectIDComposer)
    {
        MajorObjectIDComposer = majorObjectIDComposer;
    }

    OriginObjectIdentifier IOriginObjectComposer<MajorObject>.Compose(MajorObject obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        var identifier = MajorObjectIDComposer.Compose(obj.ID);

        try
        {
            OriginObjectIdentifier.Validate(identifier);
        }
        catch (ArgumentException e)
        {
            throw new InvalidOperationException($"The {nameof(IOriginComposer<MajorObjectID>)} for {nameof(MajorObjectID)} provided an invalid {nameof(OriginObjectIdentifier)}.", e);
        }

        return identifier;
    }
}
