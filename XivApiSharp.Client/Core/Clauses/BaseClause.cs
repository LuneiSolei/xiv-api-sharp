namespace XivApiSharp.Client.Core.Clauses;

/// <inheritdoc/>
internal abstract record BaseClause : IBaseClause
{
    /// <summary>
    /// Cache for storing the URI encoded string representation of the instance.
    /// </summary>
    private protected string UriEncodedCache { get; set; } = string.Empty;

    /// <summary>
    /// Cache for storing the unencoded string representation of this instance.
    /// </summary>
    private protected string UnencodedCache { get; set; } = string.Empty;

    /// <summary>
    /// Gets this instance's URI encoded string representation.
    /// </summary>
    /// <returns>
    /// The URI encoded string representation of this instance.
    /// </returns>
    /// <seealso cref="ToUnencodedString"/>
    public string ToUriEncodedString() => UriEncodedCache;

    /// <summary>
    /// Converts this instance into its unencoded string representation.
    /// </summary>
    /// <returns>
    /// The unencoded string representation of this instance.
    /// </returns>
    /// <seealso cref="ToUriEncodedString"/>
    public string ToUnencodedString() => UnencodedCache;

    /// <summary>
    /// A wrapper for <see cref="ToUriEncodedString"/>.
    /// </summary>
    /// <returns>
    /// The URI encoded string representation of this instance.
    /// </returns>
    public override string ToString() => ToUriEncodedString();

    /// <summary>
    /// Rebuilds the URI encoded string cache for this instance.
    /// </summary>
    private protected abstract void RebuildUriEncodedCache();

    /// <summary>
    /// Rebuilds the unencoded string cache for this instance.
    /// </summary>
    private protected abstract void RebuildUnencodedCache();

    /// <summary>
    /// Rebuilds all caches.
    /// </summary>
    private protected void UpdateCaches()
    {
        RebuildUriEncodedCache();
        RebuildUnencodedCache();
    }
}