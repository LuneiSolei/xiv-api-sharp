using System.Web;
using JetBrains.Annotations;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.Extensions;

namespace XivApiSharp.Client.Core.ClauseGroups;

/// <inheritdoc/>
internal sealed class ClauseGroup : BaseClause, IClauseGroup
{
    private string? _encodedValue;
    private string? _unencodedValue;
    private IEnumerable<IBaseClause> _clauses;
    private ClauseDecorators _decorator;

    internal ClauseGroup(IEnumerable<IBaseClause> clauses, ClauseDecorators decorator)
    {
        _clauses = clauses;
        _decorator = decorator;
        UpdateCaches();
    }

    public void AddClause(IBaseClause clause) =>
        _clauses = _clauses.Append(clause);

    public void AddClauses(IEnumerable<IBaseClause> clauses) =>
        _clauses = _clauses.Concat(clauses);

    /// <inheritdoc cref="IClauseGroup.ToString"/>
    public override string ToString() => ToUriEncodedString();

    /// <inheritdoc/>
    public string ToUriEncodedString() => _encodedValue;

    /// <inheritdoc/>
    public string ToUnencodedString() => _unencodedValue;

    [UsedImplicitly]
    private protected override void RebuildUriEncodedCache()
    {
        // Encode decorator
        string encodedDecorator = HttpUtility.UrlEncode(_decorator.GetStringValue());
        _encodedValue ??= $"{encodedDecorator}%28{string.Join(' ', _clauses)}%28";
    }

    private protected override void RebuildUnencodedCache() =>
        _unencodedValue ??= $"{_decorator}({string.Join(' ', _clauses)})";
}