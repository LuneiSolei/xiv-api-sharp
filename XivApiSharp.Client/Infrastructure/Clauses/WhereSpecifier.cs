using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <inheritdoc/>
internal sealed class WhereSpecifier(string specifier, 
    IClauseFactory clauseFactory) : IWhereSpecifier
{
    /// <summary>
    /// The name of the specifier to be compared.
    /// </summary>
    private readonly string _specifier = specifier;
    
    /// <inheritdoc/>
    public IWithDecorator Must
    {
        get => new WithDecorator(_specifier, 
            ClauseDecorators.Must, clauseFactory);
    }

    /// <inheritdoc/>
    public IWithDecorator MustNot
    {
        get => new WithDecorator(_specifier, 
            ClauseDecorators.MustNot, clauseFactory);
    }
}