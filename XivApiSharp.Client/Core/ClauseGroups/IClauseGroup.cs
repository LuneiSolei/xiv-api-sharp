namespace XivApiSharp.Client.Core.ClauseGroups;
 
/// <summary>
/// Represents a type that is used to define a group of clauses. This clause 
/// group is then utilized by <see cref="QueryString"/>.
/// </summary>
public interface IClauseGroup : IBaseClause
{
    /// <summary>
    /// Acts as a wrapper for <see cref="ToUriEncodedString"/>. 
    /// </summary>
    /// <returns>A URI encoded string representing this instance.</returns>
    string ToString();
}