namespace SharpHorizons.Query.Arguments.Composers.Epoch;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

/// <summary>Composes <see cref="IStepSizeArgument"/> that describe <see cref="IFixedStepSize"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class FixedStepSizeComposer : IStepSizeComposer<IFixedStepSize>
{
    IStepSizeArgument IArgumentComposer<IStepSizeArgument, IFixedStepSize>.Compose(IFixedStepSize obj)
    {
        Validate(obj);

        return new QueryArgument($"{obj.DeltaTime.Minutes.Round().ToString("F0", CultureInfo.InvariantCulture)}m");
    }

    /// <summary>Validates the <see cref="IFixedStepSize"/> <paramref name="stepSize"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="stepSize">This <see cref="IFixedStepSize"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="stepSize"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(IFixedStepSize stepSize, [CallerArgumentExpression(nameof(stepSize))] string? argumentExpression = null)
    {
        ArgumentNullException.ThrowIfNull(stepSize, argumentExpression);

        try
        {
            Validate(stepSize.DeltaTime);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<IFixedStepSize>(argumentExpression, e);
        }
    }

    /// <summary>Validates that the <see cref="Time"/> <paramref name="deltaTime"/> represents a <see cref="IFixedStepSize.DeltaTime"/> supported by Horizons, throwing an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="deltaTime">This <see cref="Time"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="deltaTime"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    private static void Validate(Time deltaTime, [CallerArgumentExpression(nameof(deltaTime))] string? argumentExpression = null)
    {
        SharpMeasuresValidation.Validate(deltaTime);

        if (deltaTime.Seconds <= 0)
        {
            throw new ArgumentOutOfRangeException(argumentExpression, deltaTime, $"A value greater than 0 should be used to represent the delta time of an {nameof(IFixedStepSize)}.");
        }
    }
}
