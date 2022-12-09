namespace SharpHorizons;

using System;

/// <summary>Describes instantiation of an <see cref="Exception"/> of type <typeparamref name="TException"/>.</summary>
/// <typeparam name="TException">The type of the <see cref="Exception"/> that is instantiated.</typeparam>
/// <param name="innerException">The <see cref="Exception"/> that caused the current <see cref="Exception"/>.</param>
public delegate TException ExceptionInstantiation<TException>(Exception? innerException = null) where TException : Exception;
