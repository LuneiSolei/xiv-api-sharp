namespace XivApiSharp.Client.Core.Extensions;

public static class StringExtensions
{
    extension(string input)
    {
        public string ToFirstCapital() =>
            $"{input[0].ToString().ToUpper()}{input[1..]}";
    }
}