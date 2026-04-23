using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <inheritdoc cref="IOptionalLanguageStep"/>
internal sealed class OptionalLanguageStep
    : OptionalDecoratorStep, IOptionalLanguageStep
{
    /// <summary>
    /// Constructs a new instance of <see cref="OptionalLanguageStep"/>.
    /// </summary>
    /// <param name="factory">
    /// The clause factory used to create new clauses.
    /// </param>
    /// <param name="specifier">
    /// The name of the field specifier for the clause to use.
    /// </param>
    internal OptionalLanguageStep(IClauseFactory factory, string specifier) 
        : base(factory, specifier, SchemaLanguage.None) { }
    
    /// <inheritdoc/>
    public IOptionalDecoratorStep WithLanguage(SchemaLanguage lang)
    {
        Language = lang;
        return this;
    }
}