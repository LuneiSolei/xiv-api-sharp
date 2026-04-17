using XivApiSharp.Client.Application.Clauses;
using XivApiSharp.Client.Core.ClauseGroups;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Core;

/// <summary>
/// A string used for searching data in the XIV API. 
/// </summary>
/// 
/// <remarks>
/// <para>
///     QueryStrings are formed from one (1) or more <see cref="Clause{T}">Clause&lt;T&gt;</see> and/or <see cref="ClauseGroup"/>
///     instances.
/// </para>
/// 
/// <para>
///     <b>Note</b>: In XivApiSharp, "QueryString" refers specifically to the parameter named "query" and <b>NOT</b> the
///     traditional URL query string.
/// </para>
/// <para>
///     *Based on the XIV API model <see href="https://v2.xivapi.com/api/docs#model/QueryString">QueryString</see> documentation.
/// </para>
/// </remarks>
/// 
/// <seealso cref="Clause{T}">Clause&lt;T&gt;</seealso>
/// <seealso cref="ClauseGroup"/>
public sealed record QueryString
{
    /// <summary>
    /// A collection of <see cref="ClauseGroups"/>.
    /// </summary>
    private List<IClauseGroup> ClauseGroups { get; } = [];
    
    /// <summary>
    /// A collection of single instances of <see cref="Clause{T}">Clause&lt;T&gt;</see>.
    /// </summary>
    private List<IClause> Clauses { get; } = [];

    /// <summary>
    /// Adds a single clause to the query string.
    /// </summary>
    /// <param name="clause">The clause to add.</param>
    /// <example>
    /// <code>
    /// QueryString query = new();
    /// Clause&lt;string&gt; clause = XivApiService.NewClause()
    ///     .WhereSpecifier("Name")
    ///     .Is.EqualTo("Tank You, Paladin I");
    /// query.AddClause(clause);
    /// </code>
    /// </example>
    public void AddClause(IClause clause) => 
        Clauses.Add(clause);

    /// <summary>
    /// Adds a multiple single clauses to the query string.
    /// </summary>
    /// <param name="clauses">The clauses to add.</param>
    /// <example>
    /// <code>
    /// QueryString query = new();
    /// Clause&lt;int&gt; clause = XivApiService.NewClause()
    ///     .WhereSpecifier("Amount")
    ///     .Is.GreaterThanOrEqualTo(4);
    /// </code>
    /// </example>
    public void AddClauses(IEnumerable<IClause> clauses) =>
        Clauses.AddRange(clauses);

    /// <summary>
    /// Adds a single clause group to the query string.
    /// </summary>
    /// <param name="group">The clause group to add.</param>
    // TODO: Add example code.
    public void AddClauseGroup(IClauseGroup group) => 
        ClauseGroups.Add(group);
    
    /// <summary>
    /// Adds multiple clause groups to the query string.
    /// </summary>
    /// <param name="groups">The clause groups to add.</param>
    // TODO: Add example code.
    public void AddClauseGroups(IEnumerable<IClauseGroup> groups) =>
        ClauseGroups.AddRange(groups);
    
    /// <summary>
    /// Converts the value of this instance to its string representation.
    /// </summary>
    /// <returns>The converted clauses in a formatted string.</returns>
    public override string ToString()
    {
        // Query clauses MUST be separated via whitespace
        string result = string.Join(" ", Clauses);
        result += string.Join(" ", ClauseGroups);
        
        return result;
    }
}