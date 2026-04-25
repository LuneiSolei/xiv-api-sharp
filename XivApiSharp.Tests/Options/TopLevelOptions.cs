using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;
using XivApiSharp.Tests.Options.Schemas;
using XivApiSharp.Tests.Options.Schemas.ClauseFactoryTests;

namespace XivApiSharp.Tests.Options;

public class TopLevelOptions
{
    [Required, ValidateObjectMembers, UsedImplicitly]
    public required ClauseOptions Clauses { get; set; }
    
    [Required, ValidateObjectMembers]
    public required Schema ClauseFactoryTests { get; set; }
}