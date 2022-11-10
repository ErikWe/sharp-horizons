namespace SharpHorizons.Query.Arguments.Composers.Epoch;

using SharpHorizons.Query.Epoch;

using System;
using System.Globalization;

/// <summary>Composes <see cref="IStepSizeArgument"/> that describe <see cref="IAngularStepSize"/>.</summary>
internal sealed class AngularStepSizeComposer : IStepSizeComposer<IAngularStepSize>
{
    IStepSizeArgument IArgumentComposer<IStepSizeArgument, IAngularStepSize>.Compose(IAngularStepSize obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return new QueryArgument($"VAR{obj.DeltaAngle.Arcseconds.Round().ToString("F0", CultureInfo.InvariantCulture)}");
    }
}
