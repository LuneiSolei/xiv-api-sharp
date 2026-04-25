using System.Web;
using JetBrains.Annotations;
using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.Extensions;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <inheritdoc cref="IClause{T}"/>
internal sealed class Clause<T> : BaseClause, IClause<T> where T : notnull
{
    /// <summary>
    /// Backing field for <see cref="Value"/>
    /// </summary>
    private T _value;
    
    /// <summary>
    /// The value of clause to be compared.
    /// </summary>
    [UsedImplicitly]
    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            UpdateCaches();
        }
    }

    /// <summary>
    /// Backing field for <see cref="Language"/>
    /// </summary>
    private SchemaLanguage _language;
    
    /// <inheritdoc />
    public SchemaLanguage Language
    {
        get => _language;
        set         
        {
            _language = value; 
            UpdateCaches();
        }
    }

    /// <summary>
    /// Backing field for <see cref="Specifier"/>
    /// </summary>
    private string _specifier;
    
    /// <inheritdoc />
    public string Specifier
    {
        get => _specifier;
        set         
        {
            _specifier = value; 
            UpdateCaches();
        }
    }

    /// <summary>
    /// Backing field for <see cref="ClauseOperator"/>.
    /// </summary>
    private ClauseOperators _clauseOperator;
    
    /// <inheritdoc />
    public ClauseOperators ClauseOperator
    {
        get => _clauseOperator;
        set
        {
            _clauseOperator = value; 
            UpdateCaches();
        }
    }
    
    /// <summary>
    /// Backing field for <see cref="Decorator"/>.
    /// </summary>
    private ClauseDecorators _decorator;
    
    /// <inheritdoc/>
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
    /// <seealso cref="IClause{T}"/>
    internal Clause(
        ClauseDecorators decorator, 
        string specifier, 
        SchemaLanguage language, 
        ClauseOperators operation, 
        T value)
    {
        _decorator = decorator;
        _specifier = specifier;
        _language = language;
        _clauseOperator = operation;
        _value = value;
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
}