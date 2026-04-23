using System.Numerics;

namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Defines methods for adding comparison operators to a clause.
/// </summary>
/// <seealso cref="IClause"/>
public interface IOperatorStep
{
    /// <summary>
    /// Sets the clause to use the equal to operator (=) against the provided value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <returns>
    /// An individual <see cref="IClause"/> to be used with a
    /// <see cref="QueryString"/>.
    /// </returns>
    IClause Equal(string value);

    /// <summary>
    /// Sets the clause to use the equal to operator (=) against the provided
    /// value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <returns>
    /// An individual <see cref="IClause"/> to be used with a
    /// <see cref="QueryString"/>.
    /// </returns>
    IClause Equal(bool value);

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
    /// An individual <see cref="IClause"/> to be used with a
    /// <see cref="QueryString"/>.
    /// </returns>
    IClause Equal<T>(T value) where T : INumber<T>;
    
    /// <summary>
    /// Sets the clause to use the partial string match operator (~) against
    /// the provided value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <returns>
    /// An individual <see cref="IClause"/> to be used with a
    /// <see cref="QueryString"/>.
    /// </returns>
    IClause PartiallyEqual(string value);

    /// <summary>
    /// Sets the clause to use the greater than operator (&gt;) against the provided value.
    /// </summary>
    /// <param name="value">The value to compare to.</param>
    /// <typeparam name="T">
    /// Any type that implements the
    /// <see cref="INumber{TSelf}">INumber&lt;TSelf&gt;</see> interface.
    /// </typeparam>
    /// <returns>
    /// An individual <see cref="IClause"/> to be used with a
    /// <see cref="QueryString"/>.
    /// </returns>
    IClause GreaterThan<T>(T value) where T : INumber<T>;

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
    /// An individual <see cref="IClause"/> to be used with a
    /// <see cref="QueryString"/>.
    /// </returns>
    IClause GreaterThanOrEqual<T>(T value) where T : INumber<T>;

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
    /// An individual <see cref="IClause"/> to be used with a
    /// <see cref="QueryString"/>.
    /// </returns>
    IClause LessThan<T>(T value) where T : INumber<T>;

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
    /// An individual <see cref="IClause"/> to be used with a
    /// <see cref="QueryString"/>.
    /// </returns>
    IClause LessThanOrEqual<T>(T value) where T : INumber<T>;
}