using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;
using XivApiSharp.Tests.Options.Schemas.ClauseTests;

namespace XivApiSharp.Tests.Options.Schemas.QueryStringTests;

public class QueryStringTestsSchema
{
    [Required]
    [ValidateObjectMembers]
    [UsedImplicitly]
    public required StringClauseOptions AddClauseTest { get; set; }

    [Required]
    [ValidateObjectMembers]
    [UsedImplicitly]
    public required ClauseGroupOptions AddClausesTest { get; set; }

    [Required]
    [ValidateObjectMembers]
    [UsedImplicitly]
    public required ClauseGroupOptions AddClauseGroupTest { get; set; }
}