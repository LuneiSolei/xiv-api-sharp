using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;

namespace XivApiSharp.Tests.Options.Schemas.ClauseTests;

public class ClauseTestsSchema
{
    [Required, ValidateObjectMembers, UsedImplicitly]
    public required StringClauseOptions ToUriEncodedStringTest { get; set; }

    [Required, ValidateObjectMembers, UsedImplicitly]
    public required StringClauseOptions CreateClauseTest { get; set; }
}