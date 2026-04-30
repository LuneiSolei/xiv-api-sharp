using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;
using XivApiSharp.Tests.Options.Schemas.ClauseTests;
using XivApiSharp.Tests.Options.Schemas.QueryStringTests;
using XivApiSharp.Tests.Options.Schemas.XivApiServiceTests;

namespace XivApiSharp.Tests.Options;

public class TopLevelOptions
{
    [Required, ValidateObjectMembers, UsedImplicitly]
    public required ClauseTestsSchema ClauseTests { get; set; }

    [Required, ValidateObjectMembers, UsedImplicitly]
    public required XivApiServiceTestsSchema XivApiServiceTests { get; set; }

    [Required]
    [ValidateObjectMembers]
    [UsedImplicitly]
    public required QueryStringTestsSchema QueryStringTests { get; set; }
}