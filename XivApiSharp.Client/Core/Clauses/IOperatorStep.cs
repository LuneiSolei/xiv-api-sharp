using System.Numerics;
using JetBrains.Annotations;
using XivApiSharp.Client.Infrastructure;

namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Defines methods for adding comparison operators to a clause.
/// </summary>
/// <seealso cref="IClause{T}"/>
public interface IOperatorStep
{
    /// <summary>
    /// Sets the clause to use the equal to operator (=) against the provided value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <returns>
    /// An individual <see cref="IClause{T}"/> to be used with a
    /// <see cref="QueryString"/>.
    /// </returns>
    [UsedImplicitly]
    IClause<string> Equal(string value);

    /// <summary>
    /// Sets the clause to use the equal to operator (=) against the provided
    /// value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <returns>
    /// An individual <see cref="IClause{T}"/> to be used with a
    /// <see cref="QueryString"/>.
    /// </returns>
    [UsedImplicitly]
    IClause<bool> Equal(bool value);

    /// <summary>
    /// Sets the clause to use the equal to operator (=) against the provided
    /// value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <typeparam name="T">
    /// Any type that implements the
    /// <see cref="INumber{TSelf}">INumber&lt;TSelf&gt;</see> interface.
    /// </typeparam>
    /// <returns>
    /// An individual <see cref="IClause{T}"/> to be used with a
    /// <see cref="QueryString"/>.
    /// </returns>
    [UsedImplicitly]
    IClause<T> Equal<T>(T value) where T : INumber<T>;

    /// <summary>
    /// Sets the clause to use the partial string match operator (~) against
    /// the provided value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <returns>
    /// An individual <see cref="IClause{T}"/> to be used with a
    /// <see cref="QueryString"/>.
    /// </returns>
    [UsedImplicitly]
    IClause<string> PartiallyEqual(string value);

    /// <summary>
    /// Sets the clause to use the greater than operator (&gt;) against the provided value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <typeparam name="T">
    /// Any type that implements the
    /// <see cref="INumber{TSelf}">INumber&lt;TSelf&gt;</see> interface.
    /// </typeparam>
    /// <returns>
    /// An individual <see cref="IClause{T}"/> to be used with a
    /// <see cref="QueryString"/>.
    /// </returns>
    [UsedImplicitly]
    IClause<T> GreaterThan<T>(T value) where T : INumber<T>;

    /// <summary>
    /// Sets the clause to use the greater than or equal to operator (&gt;=)
    /// against the provided value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <typeparam name="T">
    /// Any type that implements the
    /// <see cref="INumber{TSelf}">INumber&lt;TSelf&gt;</see> interface.
    /// </typeparam>
    /// <returns>
    /// An individual <see cref="IClause{T}"/> to be used with a
    /// <see cref="QueryString"/>.
    /// </returns>
    [UsedImplicitly]
    IClause<T> GreaterThanOrEqual<T>(T value) where T : INumber<T>;

    /// <summary>
    /// Sets the clause to use the less than operator (&lt;) against the
    /// provided value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <typeparam name="T">
    /// Any type that implements the
    /// <see cref="INumber{TSelf}">INumber&lt;TSelf&gt;</see> interface.
    /// </typeparam>
    /// <returns>
    /// An individual <see cref="IClause{T}"/> to be used with a
    /// <see cref="QueryString"/>.
    /// </returns>
    [UsedImplicitly]
    IClause<T> LessThan<T>(T value) where T : INumber<T>;

    /// <summary>
    /// Sets the clause to use the less than or equal to operator (&lt;=)
    /// against the provided value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <typeparam name="T">
    /// Any type that implements the
    /// <see cref="INumber{TSelf}">INumber&lt;TSelf&gt;</see> interface.
    /// </typeparam>
    /// <returns>
    /// An individual <see cref="IClause{T}"/> to be used with a
    /// <see cref="QueryString"/>.
    /// </returns>
    [UsedImplicitly]
    IClause<T> LessThanOrEqual<T>(T value) where T : INumber<T>;
}