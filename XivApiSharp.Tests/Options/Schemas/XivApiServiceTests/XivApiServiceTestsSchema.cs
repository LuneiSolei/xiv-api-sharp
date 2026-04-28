using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;

namespace XivApiSharp.Tests.Options.Schemas.XivApiServiceTests;

public class XivApiServiceTestsSchema
{
    [Required, ValidateObjectMembers, UsedImplicitly]
    public required NewClauseTest NewClauseTest { get; set; }

    [Required, ValidateObjectMembers, UsedImplicitly]
    public required NewClauseGroupTest NewClauseGroupTest { get; set; }
}