using System.Text;
using System.Web;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Core;

/// <inheritdoc />
public sealed record QueryString : IQueryString
{
    /// <summary>
    ///     Cache for storing the URI encoded representation of this instance.
    /// </summary>
    private string _uriEncodedCache = string.Empty;

    /// <summary>
    ///     Cache for storing the unencoded representation of this instance.
    /// </summary>
    private string _unencodedCache = string.Empty;

    /// <summary>
    /// The backing field for <see cref="Clauses"/>.
    /// </summary>
    private ICollection<IBaseClause> _clauses = [];

    /// <inheritdoc />
    public ICollection<IBaseClause> Clauses
    {
        get => _clauses;
        set
        {
            _clauses = value;
            UpdateCaches();
        }
    }

    /// <inheritdoc />
    public string ToUnencodedString()
    {
        return _unencodedCache;
    }

    /// <inheritdoc />
    public string ToUriEncodedString()
    {
        return _uriEncodedCache;
    }

    private void UpdateCaches()
    {
        RebuildUnencodedStringCache();
        RebuildUriEncodedStringCache();
    }

    private void RebuildUriEncodedStringCache()
    {
        string param = HttpUtility.UrlEncode("query=");
        _uriEncodedCache = $"{param}{string.Join(' ', Clauses)}";
    }

    private void RebuildUnencodedStringCache()
    {
        // Join clauses together without using Join() because Join() calls ToString() and ToString() calls
        // ToUriEncodedString() on clauses.
        StringBuilder builder = new();
        foreach (IBaseClause clause in Clauses)
        {
            // Don't put a space before the first clause
            if (Clauses.First() != clause) builder.Append(' ');

            // Append the clause
            builder.Append(clause.ToUnencodedString());
        }

        _unencodedCache = builder.ToString();
    }
}