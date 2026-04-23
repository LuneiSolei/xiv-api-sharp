using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <inheritdoc cref="IOptionalLanguageStep"/>
internal sealed class OptionalLanguageStep(IClauseFactory factory, string specifier) 
    : OptionalDecoratorStep(factory, specifier, SchemaLanguage.None), 
    IOptionalLanguageStep
{
    /// <inheritdoc/>
    public IOptionalDecoratorStep WithLanguage(SchemaLanguage lang)
    {
        Language = lang;
        return this;
    }
}