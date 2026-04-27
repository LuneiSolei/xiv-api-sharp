using JetBrains.Annotations;

namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Represents a type that is used for the final step of the "multistep" method chain for the
/// <see cref="IClauseBuilder{T}"/>.
/// </summary>
public interface IValueStep
{
    /// <summary>
    /// Sets the value for the clause to compare the specifier against.
    /// </summary>
    /// <param name="value">
    /// The value for the clause to use.
    /// </param>
    /// <typeparam name="T">
    /// The type of the value. Can be either a <c>string</c>, <c>boolean</c>, or <c>INumber</c>.
    /// </typeparam>
    /// <returns>
    /// The built, typed clause.
    /// </returns>
    /// <seealso cref="IClause{T}"/>
    [UsedImplicitly]
    IClause<T> WithValue<T>(T value);

    /// <inheritdoc cref="WithValue{T}"/>
    [UsedImplicitly]
    IClause<string> WithValue(string value);

    /// <inheritdoc cref="WithValue{T}"/>
    [UsedImplicitly]
    IClause<bool> WithValue(bool value);
}