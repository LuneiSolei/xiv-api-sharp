using System.Numerics;

namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Defines methods for selecting comparison operators to create a single query clause.
/// </summary>
/// <remarks>
/// Implementations produce a <see cref="Clause{T}">Clause&lt;T&gt;</see> using operators such as equals, partial match,
/// greater/less than, and their variants.
/// </remarks>
public interface IOperatorStep
{
    /// <summary>
    /// Sets the clause to use the equal to operator (=) against the provided value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <returns>
    /// An individual <see cref="Clause{T}">Clause&lt;T&gt;</see> to be used with a <see cref="QueryString"/>.
    /// </returns>
    IClause EqualTo(string value);

    /// <summary>
    /// Sets the clause to use the equal to operator (=) against the provided value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <returns>
    /// An individual <see cref="Clause{T}">Clause&lt;T&gt;</see> to be used with a <see cref="QueryString"/>.
    /// </returns>
    IClause EqualTo(bool value);

    /// <summary>
    /// Sets the clause to use the equal to operator (=) against the provided value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <typeparam name="T">
    /// Any type that implements the <see cref="INumber{TSelf}">INumber&lt;TSelf&gt;</see> interface.
    /// </typeparam>
    /// <returns>
    /// An individual <see cref="Clause{T}">Clause&lt;T&gt;</see> to be used with a <see cref="QueryString"/>.
    /// </returns>
    IClause EqualTo<T>(T value) where T : INumber<T>;
    
    /// <summary>
    /// Sets the clause to use the partial string match operator (~) against the provided value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <returns>
    /// An individual <see cref="Clause{T}">Clause&lt;T&gt;</see> to be used with a <see cref="QueryString"/>.
    /// </returns>
    IClause PartiallyEqualTo(string value);

    /// <summary>
    /// Sets the clause to use the greater than operator (&gt;) against the provided value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <typeparam name="T">
    /// Any type that implements the <see cref="INumber{TSelf}">INumber&lt;TSelf&gt;</see> interface.
    /// </typeparam>
    /// <returns>
    /// An individual <see cref="Clause{T}">Clause&lt;T&gt;</see> to be used with a <see cref="QueryString"/>.
    /// </returns>
    IClause GreaterThan<T>(T value) where T : INumber<T>;

    /// <summary>
    /// Sets the clause to use the greater than or equal to operator (&gt;=) against the provided value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <typeparam name="T">
    /// Any type that implements the <see cref="INumber{TSelf}">INumber&lt;TSelf&gt;</see> interface.
    /// </typeparam>
    /// <returns>
    /// An individual <see cref="Clause{T}">Clause&lt;T&gt;</see> to be used with a <see cref="QueryString"/>.
    /// </returns>
    IClause GreaterThanOrEqualTo<T>(T value) where T : INumber<T>;

    /// <summary>
    /// Sets the clause to use the less than operator (&lt;) against the provided value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <typeparam name="T">
    /// Any type that implements the <see cref="INumber{TSelf}">INumber&lt;TSelf&gt;</see> interface.
    /// </typeparam>
    /// <returns>
    /// An individual <see cref="Clause{T}">Clause&lt;T&gt;</see> to be used with a <see cref="QueryString"/>.
    /// </returns>
    IClause LessThan<T>(T value) where T : INumber<T>;

    /// <summary>
    /// Sets the clause to use the less than or equal to operator (&lt;=) against the provided value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <typeparam name="T">
    /// Any type that implements the <see cref="INumber{TSelf}">INumber&lt;TSelf&gt;</see> interface.
    /// </typeparam>
    /// <returns>
    /// An individual <see cref="Clause{T}">Clause&lt;T&gt;</see> to be used with a <see cref="QueryString"/>.
    /// </returns>
    IClause LessThanOrEqualTo<T>(T value) where T : INumber<T>;
}