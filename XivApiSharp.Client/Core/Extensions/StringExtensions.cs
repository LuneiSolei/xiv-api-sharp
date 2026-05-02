namespace XivApiSharp.Client.Core.Extensions;

/// <summary>
/// Provides additional functionality to strings.
/// </summary>
internal static class StringExtensions
{
    extension(string input)
    {
        /// <summary>
        /// Capitalizes the first character of the string.
        /// </summary>
        /// <returns>
        /// The resulting string.
        /// </returns>
        public string ToFirstCapital() =>
            $"{input[0].ToString().ToUpper()}{input[1..]}";
    }
}