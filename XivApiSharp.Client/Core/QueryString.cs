using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Core;

/// <summary>
/// Represents the query parameter used when making certain calls to the API.
/// </summary>
public record QueryString
{
    private List<IClauseGroup> ClauseGroups { get; } = [];
    private List<IClause> Clauses { get; } = [];

    /// <summary>
    /// Adds a single clause to the query string.
    /// </summary>
    /// <param name="clause">The clause to add.</param>
    /// <typeparam name="T">The type of the value to be compared in the clause.</typeparam>
    /// <example>
    /// <code>
    /// QueryString query = new();
    /// Clause&lt;string&gt; clause = XivApiService.NewClause()
    ///     .WhereSpecifier("Name")
    ///     .Is.EqualTo("Tank You, Paladin I");
    /// query.AddClause(clause);
    /// </code>
    /// </example>
    public void AddClause<T>(Clause<T> clause) => 
        Clauses.Add(clause);

    /// <summary>
    /// Adds a multiple single clauses to the query string.
    /// </summary>
    /// <param name="clauses">The clauses to add.</param>
    /// <typeparam name="T">The type of the value to be compared.</typeparam>
    /// <example>
    /// <code>
    /// QueryString query = new();
    /// Clause&lt;int&gt; clause = XivApiService.NewClause()
    ///     .WhereSpecifier("Amount")
    ///     .Is.GreaterThanOrEqualTo(4);
    /// </code>
    /// </example>
    public void AddClauses<T>(IEnumerable<Clause<T>> clauses) =>
        Clauses.AddRange(clauses);

    /// <summary>
    /// Adds a single clause group to the query string.
    /// </summary>
    /// <param name="group">The clause group to add.</param>
    // TODO: Add example code.
    public void AddClauseGroup(ClauseGroup group) => 
        ClauseGroups.Add(group);
    
    /// <summary>
    /// Adds multiple clause groups to the query string.
    /// </summary>
    /// <param name="groups">The clause groups to add.</param>
    // TODO: Add example code.
    public void AddClauseGroups(IEnumerable<ClauseGroup> groups) =>
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