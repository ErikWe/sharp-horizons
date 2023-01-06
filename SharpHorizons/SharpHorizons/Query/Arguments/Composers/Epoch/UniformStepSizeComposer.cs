namespace SharpHorizons.Query.Arguments.Composers.Epoch;

using SharpHorizons.Query.Epoch;

using System;
using System.Globalization;
using System.Runtime.CompilerServices;

/// <summary>Composes <see cref="IStepSizeArgument"/> that describe <see cref="IUniformStepSize"/>.</summary>
internal sealed class UniformStepSizeComposer : IStepSizeComposer<IUniformStepSize>
{
    IStepSizeArgument IArgumentComposer<IStepSizeArgument, IUniformStepSize>.Compose(IUniformStepSize obj)
    {
        Validate(obj);

        return new QueryArgument(obj.StepCount.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>Validates the <see cref="IUniformStepSize"/> <paramref name="stepSize"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="stepSize">This <see cref="IUniformStepSize"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="stepSize"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(IUniformStepSize stepSize, [CallerArgumentExpression(nameof(stepSize))] string? argumentExpression = null)
    {
        ArgumentNullException.ThrowIfNull(stepSize, argumentExpression);

        try
        {
            Validate(stepSize.StepCount);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<IUniformStepSize>(argumentExpression, e);
        }
    }

    /// <summary>Validates that the <see cref="int"/> <paramref name="stepCount"/> represents a <see cref="IUniformStepSize.StepCount"/> supported by Horizons, throwing an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="stepCount">This <see cref="int"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="stepCount"/>.</param>
    /// <exception cref="ArgumentOutOfRangeException"/>
    private static void Validate(int stepCount, [CallerArgumentExpression(nameof(stepCount))] string? argumentExpression = null)
    {
        if (stepCount <= 0)
        {
            throw new ArgumentOutOfRangeException(argumentExpression, stepCount, $"A value greater than 0 should be used to represent the step count of a {nameof(IUniformStepSize)}.");
        }
    }
}
