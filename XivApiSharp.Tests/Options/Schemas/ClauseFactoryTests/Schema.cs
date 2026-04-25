using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Microsoft.Extensions.Options;

namespace XivApiSharp.Tests.Options.Schemas.ClauseFactoryTests;

public class Schema
{
    [Required, ValidateObjectMembers, UsedImplicitly]
    public required CreateClauseTest CreateClauseTest { get; set; }
}