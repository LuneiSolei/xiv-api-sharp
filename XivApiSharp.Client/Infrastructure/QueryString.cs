using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure;

/// <inheritdoc />
internal sealed record QueryString : IQueryString
{
    /// <summary>
    ///     Cache for storing the URI encoded representation of this instance.
    /// </summary>
    private string _uriEncodedCache = string.Empty;

    /// <summary>
    ///     Cache for storing the unencoded representation of this instance.
    /// </summary>
    private string _unencodedCache = string.Empty;

    /// <inheritdoc />
    public ObservableCollection<IBaseClause> Clauses
    {
        get;
        set
        {
            if (field is INotifyCollectionChanged oldCollection)
                oldCollection.CollectionChanged -= OnClausesChanged;

            field = value;

            if (field is INotifyCollectionChanged newCollection)
                newCollection.CollectionChanged += OnClausesChanged;

            UpdateCaches();
        }
    }

    internal QueryString() => Clauses = [];

    /// <inheritdoc />
    public string ToUnencodedString() => _unencodedCache;

    /// <inheritdoc />
    public string ToUriEncodedString() => _uriEncodedCache;

    private void OnClausesChanged(object? sender, NotifyCollectionChangedEventArgs e) =>
        UpdateCaches();

    private void UpdateCaches()
    {
        RebuildUnencodedStringCache();
        RebuildUriEncodedStringCache();
    }

    private void RebuildUriEncodedStringCache()
    {
        StringBuilder builder = new();
        var isFirst = true;
        foreach (IBaseClause clause in Clauses)
        {
            BuildString(ref builder, clause.ToUriEncodedString(), isFirst);
            if (isFirst) isFirst = false;
        }

        string encodedEquals = HttpUtility.UrlEncode("=").ToUpper();
        _uriEncodedCache = $"query{encodedEquals}{builder}";
    }

    private void RebuildUnencodedStringCache()
    {
        // Join clauses together without using Join() because Join() calls ToString() and ToString() calls
        // ToUriEncodedString() on clauses.
        StringBuilder builder = new();
        var isFirst = true;
        foreach (IBaseClause clause in Clauses)
        {
            BuildString(ref builder, clause.ToUnencodedString(), isFirst);
            if (isFirst) isFirst = false;
        }

        _unencodedCache = builder.ToString();
    }

    private static void BuildString(ref StringBuilder builder, string clauseString, bool isFirst)
    {
        // Don't put a space before the first clause
        if (clauseString.Length == 0) return;

        switch (isFirst)
        {
            // Separate clauses via space (if not the first)
            case false:
                builder.Append($" {clauseString}");
                break;
            // Drop the decorator if it's the first clause AND it starts with a '+'
            case true when clauseString[0] == '+':
                builder.Append(clauseString[1..]);
                break;
            case true when clauseString.StartsWith("%2B"):
                builder.Append(clauseString[3..]);
                break;
            // If first with no '+' decorator, just append
            case true:
                builder.Append(clauseString);
                break;
        }
    }
}