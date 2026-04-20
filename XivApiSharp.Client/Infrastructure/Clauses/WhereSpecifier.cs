using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <inheritdoc cref="IWhereSpecifier"/>
internal sealed class WhereSpecifier(string specifier, IClauseFactory clauseFactory) 
    : WithDecorator(specifier, ClauseDecorators.May, clauseFactory), 
        IWhereSpecifier
{
    /// <inheritdoc/>
    public IWithDecorator Must
    {
        get
        {
            Decorator = ClauseDecorators.Must;
            return this;
        }
    }

    /// <inheritdoc/>
    public IWithDecorator MustNot
    {
        get
        {
            Decorator = ClauseDecorators.MustNot;
            return this;
        }
    }
}