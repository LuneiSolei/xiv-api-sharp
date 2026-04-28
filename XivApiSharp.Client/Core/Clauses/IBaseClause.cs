using JetBrains.Annotations;

namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Represents a type that is the base type for all clauses related to
/// <see cref="QueryString"/>.
/// </summary>
public interface IBaseClause
{
    /// <summary>
    /// Gets this instance's URI encoded string representation.
    /// </summary>
    /// <returns>
    /// The URI encoded string representation of this instance.
    /// </returns>
    /// <seealso cref="ToUnencodedString"/>
    [UsedImplicitly]
    string ToUriEncodedString();

    /// <summary>
    /// Converts this instance into its unencoded string representation.
    /// </summary>
    /// <returns>
    /// The unencoded string representation of this instance.
    /// </returns>
    /// <seealso cref="ToUriEncodedString"/>
    [UsedImplicitly]
    string ToUnencodedString();

    /// <summary>
    /// A wrapper for <see cref="ToUriEncodedString"/>.
    /// </summary>
    /// <returns>
    /// The URI encoded string representation of this instance.
    /// </returns>
    [UsedImplicitly]
    string ToString() => ToUriEncodedString();
}