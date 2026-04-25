using System.ComponentModel.DataAnnotations;

namespace XivApiSharp.Tests.Options.Schemas;

public class ClauseOptions
{
    [Required(AllowEmptyStrings = false)]
    public EqualToConfig EqualTo { get; set; } = null!;
    
    [Required(AllowEmptyStrings = false)]
    public StringConfig PartiallyEqualTo { get; set; } = null!;
    
    [Required(AllowEmptyStrings = false)]
    public NumberConfig GreaterThan { get; set; } = null!;
    
    [Required(AllowEmptyStrings = false)]
    public NumberConfig GreaterThanOrEqualTo { get; set; } = null!;
    
    [Required(AllowEmptyStrings = false)]
    public NumberConfig LessThan { get; set; } = null!;
    
    [Required(AllowEmptyStrings = false)]
    public NumberConfig LessThanOrEqualTo { get; set; } = null!;
}