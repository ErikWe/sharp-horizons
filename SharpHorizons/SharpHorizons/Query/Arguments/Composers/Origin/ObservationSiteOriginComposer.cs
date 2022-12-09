namespace SharpHorizons.Query.Arguments.Composers.Origin;

using SharpHorizons.Query.Origin;

using System;
using System.Runtime.CompilerServices;

/// <summary>Composes <see cref="IOriginArgument"/> that describe <see cref="IObservationSiteOrigin"/>.</summary>
internal sealed class ObservationSiteOriginComposer : IOriginComposer<IObservationSiteOrigin>
{
    IOriginArgument IArgumentComposer<IOriginArgument, IObservationSiteOrigin>.Compose(IObservationSiteOrigin obj)
    {
        Validate(obj);

        return new QueryArgument($"{obj.ObservationSiteID}@{obj.OriginObject.ComposeIdentifier()}");
    }

    /// <summary>Validates the <see cref="IObservationSiteOrigin"/> <paramref name="observationSiteOrigin"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="observationSiteOrigin">This <see cref="IObservationSiteOrigin"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="observationSiteOrigin"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(IObservationSiteOrigin observationSiteOrigin, [CallerArgumentExpression(nameof(observationSiteOrigin))] string? argumentExpression = null)
    {
        ArgumentNullException.ThrowIfNull(observationSiteOrigin, argumentExpression);

        try
        {
            ObservationSiteID.Validate(observationSiteOrigin.ObservationSiteID);
            ArgumentNullException.ThrowIfNull(observationSiteOrigin.OriginObject);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<IObservationSiteOrigin>(argumentExpression, e);
        }
    }
}
