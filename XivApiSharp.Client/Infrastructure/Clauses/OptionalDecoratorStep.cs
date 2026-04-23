using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <inheritdoc cref="IOptionalDecoratorStep"/>
internal class OptionalDecoratorStep : OperatorStep, IOptionalDecoratorStep
{
    protected internal SchemaLanguage Language;

    /// <summary>
    /// Constructs a new instance of <see cref="OptionalDecoratorStep"/>.
    /// </summary>
    /// <param name="factory">The factory to create new clauses with.</param>
    /// <param name="specifier">The specifier for the clause to use.</param>
    /// <param name="lang">The language for the clause to use.</param>
    internal OptionalDecoratorStep(IClauseFactory factory, string specifier, 
        SchemaLanguage lang) 
        : base(factory, specifier, ClauseDecorators.May, lang)
    {
        Language = lang;
    }
    
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