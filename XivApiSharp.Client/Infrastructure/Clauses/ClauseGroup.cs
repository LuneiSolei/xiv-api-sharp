using System.Text;
using System.Web;
using JetBrains.Annotations;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.Extensions;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <inheritdoc cref="IClauseGroup"/>
internal sealed record ClauseGroup : BaseClause, IClauseGroup
{
    /// <summary>
    ///     The backing field for <see cref="Clauses" />.
    /// </summary>
    private IEnumerable<IBaseClause> _clauses;

    /// <inheritdoc />
    public IEnumerable<IBaseClause> Clauses
    {
        get => _clauses;
        set
        {
            _clauses = value;
            UpdateCaches();
        }
    }

    /// <summary>
    ///     The backing field for <see cref="Decorator" />.
    /// </summary>
    private ClauseDecorators _decorator;

    /// <inheritdoc />
    public ClauseDecorators Decorator
    {
        get => _decorator;
        set
        {
            _decorator = value;
            UpdateCaches();
        }
    }

    /// <summary>
    ///     Constructor for internal use and direct instantiation of its properties.
    /// </summary>
    /// <param name="clauses">
    ///     The clauses to instantiate with.
    /// </param>
    /// <param name="decorator">
    ///     The decorator to instantiate with.
    /// </param>
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
        string encodedClause = string.Join(' ', Clauses.Select(c => c.ToUriEncodedString()));
        UriEncodedCache = $"{encodedDecorator}%28{encodedClause}%29";
    }

    /// <inheritdoc />
    private protected override void RebuildUnencodedCache()
    {
        // Join clauses together without using Join() because Join() calls ToString() and ToString() calls
        // ToUriEncodedString() on clauses.
        StringBuilder builder = new();
        bool isFirst = true;
        foreach (IBaseClause clause in Clauses)
        {
            // Don't put a space before the first one!
            if (!isFirst) builder.Append(' ');

            // Append the unencoded clause
            builder.Append(clause.ToUnencodedString());
            if (isFirst) isFirst = false;
        }

        // Put everything together
        UnencodedCache = $"{Decorator.GetStringValue()}({builder})";
    }
}