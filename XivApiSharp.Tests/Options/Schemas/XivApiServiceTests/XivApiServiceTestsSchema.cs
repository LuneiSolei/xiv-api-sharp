using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;
using XivApiSharp.Tests.Options.Schemas.ClauseTests;

namespace XivApiSharp.Tests.Options.Schemas.XivApiServiceTests;

public class XivApiServiceTestsSchema
{
    [Required, ValidateObjectMembers, UsedImplicitly]
    public required IntClauseOptions NewClauseTest { get; set; }

    [Required, ValidateObjectMembers, UsedImplicitly]
    public required ClauseGroupOptions NewClauseGroupTest { get; set; }
}