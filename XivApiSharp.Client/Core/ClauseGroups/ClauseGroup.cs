using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Core.ClauseGroups;

/// <inheritdoc/>
internal sealed class ClauseGroup(ClauseGroupOperators? groupOperator) : IClauseGroup
{
    private List<IClause> Clauses { get; }
    private ClauseGroupOperators Operators { get; } = 
        groupOperator ?? ClauseGroupOperators.Or;
 
    /// <inheritdoc cref="IClauseGroup"/>
    public override string ToString() =>
        throw new NotImplementedException();

    /// <inheritdoc/>
    public string ToEncodedString() =>
        throw new NotImplementedException();

    /// <inheritdoc/>
    public string ToUnencodedString() =>
        throw new NotImplementedException();
}