namespace SharpHorizons.Query.Arguments.Composers.Origin;

using SharpHorizons.Query.Origin;

/// <summary>Composes <see cref="OriginObjectIdentifier"/> that describe <see cref="ObjectRadiiInterpretation"/>.</summary>
internal sealed class MajorObjectNameComposer : IOriginObjectComposer<ObjectRadiiInterpretation>
{
    OriginObjectIdentifier IOriginObjectComposer<ObjectRadiiInterpretation>.Compose(ObjectRadiiInterpretation obj)
    {
        ObjectRadiiInterpretation.Validate(obj);

        return new(obj.Value);
    }
}
