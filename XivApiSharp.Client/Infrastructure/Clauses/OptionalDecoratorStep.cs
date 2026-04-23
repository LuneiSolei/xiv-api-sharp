using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <inheritdoc cref="IOptionalDecoratorStep"/>
internal class OptionalDecoratorStep(IClauseFactory clauseFactory, string 
        specifier, SchemaLanguage lang) 
    : OperatorStep(clauseFactory, specifier, ClauseDecorators.May, lang), 
        IOptionalDecoratorStep
{
    protected internal SchemaLanguage Language  = lang;
    
    /// <inheritdoc/>
    public IOperatorStep Must
    {
        get
        {
            Decorator = ClauseDecorators.Must;
            return this;
        }
    }

    /// <inheritdoc/>
    public IOperatorStep MustNot
    {
        get
        {
            Decorator = ClauseDecorators.MustNot;
            return this;
        }
    }
}