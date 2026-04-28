using System.Web;
using JetBrains.Annotations;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.Extensions;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <inheritdoc cref="IClauseGroup"/>
internal sealed class ClauseGroup : BaseClause, IClauseGroup
{
    private IEnumerable<IBaseClause> _clauses;
    private ClauseDecorators _decorator;

    internal ClauseGroup(IEnumerable<IBaseClause> clauses, ClauseDecorators decorator)
    {
        _clauses = clauses;
        _decorator = decorator;
        UpdateCaches();
    }

    /// <inheritdoc />
    public void AddClause(IBaseClause clause) =>
        _clauses = _clauses.Append(clause);

    /// <inheritdoc />
    public void AddClauses(IEnumerable<IBaseClause> clauses) =>
        _clauses = _clauses.Concat(clauses);

    /// <inheritdoc cref="IClauseGroup.ToString"/>
    public override string ToString() => ToUriEncodedString();

    /// <inheritdoc />
    [UsedImplicitly]
    private protected override void RebuildUriEncodedCache()
    {
        // Encode decorator
        string encodedDecorator = HttpUtility.UrlEncode(_decorator.GetStringValue());
        UriEncodedCache = $"{encodedDecorator}%28{string.Join(' ', _clauses)}%28";
    }

    /// <inheritdoc />
    private protected override void RebuildUnencodedCache() =>
        UnencodedCache = $"{_decorator}({string.Join(' ', _clauses)})";
}