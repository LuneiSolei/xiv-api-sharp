namespace XivApiSharp.Client.Core;

/// <summary>
/// Used for customizing the string value of a field.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
internal sealed class StringValueAttribute : Attribute
{
    /// <summary>
    /// The value of the "UriEncodedCache" attribute.
    /// </summary>
    public string Value { get; }
    
    /// <summary>
    /// A simple constructor that stores the value of the "UriEncodedCache"
    /// attribute.
    /// </summary>
    /// <param name="value">
    /// The string value to be stored.
    /// </param>
    public StringValueAttribute(string value) => Value = value;
}