namespace XivApiSharp.Client.Core;

public record Clause
{
    public string Specifier = string.Empty;
    public string Operator = string.Empty;
    public string Value = string.Empty;

    public override string ToString()
    {
        return $"{Specifier}{Operator}{Value}";
    }
}