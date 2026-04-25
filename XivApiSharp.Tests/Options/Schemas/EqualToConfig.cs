using System.ComponentModel.DataAnnotations;
using XivApiSharp.Tests.Options.Schemas.ClauseTestTypes;

namespace XivApiSharp.Tests.Options.Schemas;

public class EqualToConfig
{
    [Required(AllowEmptyStrings = false)]
    public StringClauseTestType StringTest { get; set; } = null!;
    
    [Required(AllowEmptyStrings = false)]
    public BoolClauseTestType BoolTest { get; set; } = null!;
    
    [Required(AllowEmptyStrings = false)]
    public IntClauseTestType IntTest { get; set; } = null!;
    
    [Required(AllowEmptyStrings = false)]
    public DoubleClauseTestType DoubleTest { get; set; } = null!;
    
    [Required(AllowEmptyStrings = false)]
    public DecimalClauseTestType DecimalTest { get; set; } = null!;
    
}