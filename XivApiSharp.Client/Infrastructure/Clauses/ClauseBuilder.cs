using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <summary>
/// Builds a singular clause for use in a <see cref="QueryString"/>.
/// </summary>
/// <seealso cref="IClause{T}"/>
internal sealed partial class ClauseBuilder<T> : IClauseBuilder<T>, IOptionalLanguageStep where T : notnull
{
    /// <summary>
    /// The injected IClauseFactory for the builder to use.
    /// </summary>
    private readonly IClauseFactory _factory;

    /// <summary>
    /// The decorator for the clause to use.
    /// </summary>
    private ClauseDecorators _decorator;

    /// <summary>
    /// The specifier for the clause to use.
    /// </summary>
    private string _specifier;

    /// <summary>
    /// The language override for the clause to use.
    /// </summary>
    private SchemaLanguage _language;

    /// <summary>
    /// The operator for the clause to use.
    /// </summary>
    private ClauseOperators _operator;

    /// <summary>
    ///     The value of the clause.
    /// </summary>
    private object _value;

    /// <summary>
    /// Configures the clause to require itself to match on any returned result.
    /// </summary>
    public IOperatorStep Must
    {
        get
        {
            _decorator = ClauseDecorators.Must;
            return this;
        }
    }

    /// <summary>
    /// Configures the clause to require itself not to match on any returned
    /// result.
    /// </summary>
    public IOperatorStep MustNot
    {
        get
        {
            _decorator = ClauseDecorators.MustNot;
            return this;
        }
    }

    /// <summary>
    /// Creates a new instance with an injected IClauseFactory.
    /// </summary>
    /// <param name="factory">
    /// The factory instance for the builder to use.
    /// </param>
    internal ClauseBuilder(IClauseFactory factory)
    {
        _factory = factory;
        _language = SchemaLanguage.None;
        _specifier = string.Empty;
        _decorator = ClauseDecorators.None;
        _value = "";
    }

    /// <inheritdoc />
    public IClauseBuilder<T> WithDecorator(ClauseDecorators decorator)
    {
        _decorator = decorator;
        return this;
    }

    /// <inheritdoc/>
    public IOptionalLanguageStep WhereSpecifier(string specifier)
    {
        _specifier = specifier;
        return this;
    }

    /// <inheritdoc/>
    public IOptionalDecoratorStep WithLanguage(SchemaLanguage language)
    {
        _language = language;
        return this;
    }
}