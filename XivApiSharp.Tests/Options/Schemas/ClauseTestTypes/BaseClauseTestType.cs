using System.ComponentModel.DataAnnotations;

namespace XivApiSharp.Tests.Options.Schemas.ClauseTestTypes;

public abstract class BaseClauseTestType<T>
{
    [Required(AllowEmptyStrings = false)]
    public string Specifier { get; set; } = null!;
    
    [Required(AllowEmptyStrings = false)]
    public required virtual T Value { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string ExpectedValue { get; set; } = null!;
    
    [Required(AllowEmptyStrings = false)]
    public string Sheet { get; set; } = null!;
}