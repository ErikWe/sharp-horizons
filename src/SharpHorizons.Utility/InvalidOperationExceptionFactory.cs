namespace SharpHorizons;

using System;

/// <summary>Handles construction of <see cref="InvalidOperationException"/></summary>
public static class InvalidOperationExceptionFactory
{
    /// <summary>Constructs a <see cref="InvalidOperationException"/> describing an instance of <typeparamref name="T"/> representing an invalid state.</summary>
    /// <typeparam name="T">The type of the instance that represents an invalid state.</typeparam>
    /// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="InvalidOperationException"/>.</param>
    public static InvalidOperationException InvalidState<T>(Exception? innerException = null) => new($"The {typeof(T).Name} does not represent a valid state.", innerException);
}
