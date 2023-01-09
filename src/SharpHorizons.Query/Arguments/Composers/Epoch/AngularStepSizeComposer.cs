namespace SharpHorizons.Query.Arguments.Composers.Epoch;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

/// <summary>Composes <see cref="IStepSizeArgument"/> that describe <see cref="IAngularStepSize"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class AngularStepSizeComposer : IStepSizeComposer<IAngularStepSize>
{
    IStepSizeArgument IArgumentComposer<IStepSizeArgument, IAngularStepSize>.Compose(IAngularStepSize obj)
    {
        Validate(obj);

        return new QueryArgument($"VAR{obj.DeltaAngle.Arcseconds.Round().ToString("F0", CultureInfo.InvariantCulture)}");
    }

    /// <summary>Validates the <see cref="IAngularStepSize"/> <paramref name="stepSize"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="stepSize">This <see cref="IAngularStepSize"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="stepSize"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(IAngularStepSize stepSize, [CallerArgumentExpression(nameof(stepSize))] string? argumentExpression = null)
    {
        ArgumentNullException.ThrowIfNull(stepSize, argumentExpression);

        try
        {
            Validate(stepSize.DeltaAngle);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<IAngularStepSize>(argumentExpression, e);
        }
    }

    /// <summary>Validates that the <see cref="Angle"/> <paramref name="deltaAngle"/> represents a <see cref="IAngularStepSize.DeltaAngle"/> supported by Horizons, throwing an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="deltaAngle">This <see cref="Angle"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="deltaAngle"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    private static void Validate(Angle deltaAngle, [CallerArgumentExpression(nameof(deltaAngle))] string? argumentExpression = null)
    {
        SharpMeasuresValidation.Validate(deltaAngle);

        if (deltaAngle.Degrees <= 0)
        {
            throw new ArgumentOutOfRangeException(argumentExpression, deltaAngle, $"A value greater than 0 should be used to represent the delta angle of a {nameof(IAngularStepSize)}.");
        }
    }
}
