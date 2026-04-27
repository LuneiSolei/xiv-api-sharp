using System.Web;
using JetBrains.Annotations;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.Extensions;

namespace XivApiSharp.Client.Core.ClauseGroups;

/// <inheritdoc/>
internal sealed class ClauseGroup(IEnumerable<IBaseClause> clauses,
    ClauseDecorators decorator) : IClauseGroup
{
    private string? _encodedValue;
    private string? _unencodedValue;

    /// <inheritdoc cref="IClauseGroup.ToString"/>
    public override string ToString() => ToUriEncodedString();

    /// <inheritdoc/>
    public string ToUriEncodedString()
    {
        string encodedDecorator = HttpUtility.UrlEncode(decorator.GetStringValue());
        _encodedValue ??= $"{encodedDecorator}%28{string.Join(' ', clauses)}%28";

        return _encodedValue;
    }

    /// <inheritdoc/>
    public string ToUnencodedString()
    {
        _unencodedValue ??= $"{decorator}({string.Join(' ', clauses)})";

        return _unencodedValue;
    }

    [UsedImplicitly]
    private void RebuildEncodedCache()
    {
        // Encode all clauses
        IEnumerable<string> encodedClauses = clauses.Select(clause =>
            clause.ToUriEncodedString());

        // Encode decorator
        decorator.ToUriEncodedString();
        _encodedValue = $"{decorator}({string.Join(' ', encodedClauses)})";
    }
}