using System.Web;
using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.Extensions;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <inheritdoc cref="IClause"/>
internal sealed class Clause<T> : BaseClause, IClause where T : notnull
{
        /// <summary>
    /// The value of clause to be compared.
    /// </summary>
    private T Value { get; }
    
    /// <inheritdoc cref="IClause.Language"/>
    public SchemaLanguage Language
    {
        get => GetCached(ref field);
        set => SetCached(ref field, value);
    }
    
    /// <inheritdoc />
    public string Specifier
    {
        get => GetCached(ref field);
        set => SetCached(ref field, value);
    }

    /// <inheritdoc />
    public ClauseOperators ClauseOperator
    {
        get => GetCached(ref field);
        set => SetCached(ref field, value);
    }

    /// <inheritdoc/>
    public ClauseDecorators Decorator
    {
        get => GetCached(ref field);
        set => SetCached(ref field, value);
    }

    /// <summary>
    /// Main constructor for clause.
    /// </summary>
    /// <param name="decorator">
    ///     The matching decorator for the clause.
    /// </param>
    /// <param name="specifier">
    ///     The specifier to be compared against.
    /// </param>
    /// <param name="language">
    /// the language to use for this clause.
    /// </param>
    /// <param name="operation">
    ///     The comparison operator to perform.
    /// </param>
    /// <param name="value">
    ///     The value to be compared.
    /// </param>
    /// <seealso cref="IClause"/>
    internal Clause(
        ClauseDecorators decorator, 
        string specifier, 
        SchemaLanguage language, 
        ClauseOperators operation, 
        T value)
    {
        Decorator = decorator;
        Specifier = specifier;
        Language = language;
        ClauseOperator = operation;
        Value = value;
    }

    /// <inheritdoc/>
    public override string ToString() => ToUriEncodedString();
    
    /// <inheritdoc/>
    private protected override void RebuildUriEncodedCache()
    {
        string encodedDecorator = Decorator.ToUriEncodedString();
        string encodedOperator = ClauseOperator.ToUriEncodedString();
        string encodedSpecifier = HttpUtility.UrlEncode(Specifier);
        string encodedLanguage = string.Empty;
        
        // Use language, if any was provided
        if (Language != SchemaLanguage.None)
        {
            encodedLanguage = HttpUtility.UrlEncode(
                $"@{Language.ToString().ToLower()}");
        }
        
        // Determine new encoded clause value
        string encodedValue = Value switch
        {
            // Convert boolean values to lowercase because .NET capitalizes
            // them by default.
            bool b => b.ToString().ToLowerInvariant(), 
            
            // Encode strings.
            string s => $"\"{HttpUtility.UrlEncode(s)}\"", 
            
            // Anything else gets to be a string without encoding.
            _ => Value.ToString() ?? string.Empty 
        };

        UriEncodedCache = $"{encodedDecorator}{encodedSpecifier}"
                          + $"{encodedLanguage}{encodedOperator}{encodedValue}";
    }

    /// <inheritdoc/>
    private protected override void RebuildUnencodedCache()
    {
        string decorator = Decorator.GetStringValue();
        string specifier = Specifier;
        string lang = Language == SchemaLanguage.None ? string.Empty : Language.ToString();
        string clauseOperator = ClauseOperator.GetStringValue();
        string value = Value.ToString() ?? string.Empty;

        UnencodedCache =  $"{decorator}{specifier}{lang}"
                          + $"{clauseOperator}{value}";
    }

    /// <summary>
    /// Rebuilds all cached values.
    /// </summary>
    private void UpdateCache()
    {
        RebuildUnencodedCache();
        RebuildUriEncodedCache();
        IsCacheStale = false;
    }

    /// <summary>
    /// Updates the cache, if necessary, and then retrieves the cached value 
    /// from its backing field.
    /// </summary>
    /// <param name="field">The backing field.</param>
    /// <typeparam name="TCache">The backing field's type.</typeparam>
    /// <returns>The updated cache value.</returns>
    private TCache GetCached<TCache>(ref TCache field)
    {
        if (IsCacheStale) UpdateCache();
        return field;
    }

    /// <summary>
    /// Sets the backing field to the updated value and then rebuilds all 
    /// caches.
    /// </summary>
    /// <param name="field">The backing field.</param>
    /// <param name="value">The new value.</param>
    /// <typeparam name="TCache">The backing field's type.</typeparam>
    // ReSharper disable once RedundantAssignment
    private void SetCached<TCache>(ref TCache field, TCache value)
    {
        field = value;
        UpdateCache();
    }
}