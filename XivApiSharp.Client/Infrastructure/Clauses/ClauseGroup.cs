using System.Text;
using System.Web;
using JetBrains.Annotations;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.Extensions;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <inheritdoc cref="IClauseGroup"/>
internal sealed class ClauseGroup : BaseClause, IClauseGroup
{
    private IEnumerable<IBaseClause> _clauses;

    public IEnumerable<IBaseClause> Clauses
    {
        get => _clauses;
        set
        {
            _clauses = value;
            UpdateCaches();
        }
    }

    private ClauseDecorators _decorator;

    public ClauseDecorators Decorator {
        get => _decorator;
        set
        {
            _decorator = value;
            UpdateCaches();
        }
    }

    internal ClauseGroup(IEnumerable<IBaseClause> clauses, ClauseDecorators decorator)
    {
        _clauses = clauses;
        _decorator = decorator;
        UpdateCaches();
    }

    /// <inheritdoc />
    public void AddClause(IBaseClause clause) =>
        Clauses = _clauses.Append(clause);

    /// <inheritdoc />
    public void AddClauses(IEnumerable<IBaseClause> clauses) =>
        Clauses = _clauses.Concat(clauses);

    /// <inheritdoc />
    [UsedImplicitly]
    private protected override void RebuildUriEncodedCache()
    {
        // Encode decorator
        string encodedDecorator = HttpUtility.UrlEncode(Decorator.GetStringValue());
        UriEncodedCache = $"{encodedDecorator}%28{string.Join(' ', Clauses)}%28";
    }

    /// <inheritdoc />
    private protected override void RebuildUnencodedCache()
    {
        // Join clauses together without using Join() because Join() calls ToString() and ToString() calls
        // ToUriEncodedString() on clauses.
        StringBuilder stringBuilder = new();
        foreach (IBaseClause clause in Clauses)
        {
            // Don't put a space before the first one!
            if (Clauses.First() != clause) stringBuilder.Append(' ');

            // Append the unencoded clause
            stringBuilder.Append(clause.ToUnencodedString());
        }

        // Put everything together
        UnencodedCache = $"{Decorator.GetStringValue()}({stringBuilder})";
    }

}