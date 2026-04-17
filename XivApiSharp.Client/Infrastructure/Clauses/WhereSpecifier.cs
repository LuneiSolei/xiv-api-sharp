using XivApiSharp.Client.Application.Clauses;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

internal sealed class WhereSpecifier(string specifier) : IWhereSpecifier
{
    private readonly string _specifier = specifier;
    
    /// <inheritdoc/>
    public IWithConditional MustBe
    {
        get => new WithConditional(_specifier, ClauseConditionals.MustBe);
    }

    /// <inheritdoc/>
    public IWithConditional MustNotBe
    {
        get => new WithConditional(_specifier, 
            ClauseConditionals.MustNotBe);
    }
}