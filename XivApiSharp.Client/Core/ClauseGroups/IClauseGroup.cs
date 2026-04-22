namespace XivApiSharp.Client.Core.ClauseGroups;
 
/// <summary>
/// Represents a type that is used to define a group of clauses. This clause 
/// group is then utilized by <see cref="QueryString"/>.
/// </summary>
internal interface IClauseGroup
{
    /// <summary>
    /// Acts as a wrapper for <see cref="ToEncodedString"/>. 
    /// </summary>
    /// <returns>A URI encoded string representing this instance.</returns>
    string ToString();

    /// <summary>
    /// Converts this instance into its URI encoded string representation.
    /// </summary>
    /// <returns>A URI encoded string representing this instance.</returns>
    /// <seealso cref="ToUnencodedString"/>
    string ToEncodedString();

    /// <summary>
    /// Converts this instance into its unencoded string representation.
    /// </summary>
    /// <returns>A string representing this instance.</returns>
    /// <seealso cref="ToEncodedString"/>
    string ToUnencodedString();
}