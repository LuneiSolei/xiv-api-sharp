using System.Reflection;

namespace XivApiSharp.Client.Core.Extensions;

/// <summary>
/// Provides extended functionality for enums.
/// </summary>
internal static class EnumExtensions
{
    extension(Enum value)
    {
        /// <summary>
        /// Gets the string value provided by the attribute
        /// <see cref="StringValueAttribute"/>
        /// </summary>
        /// <returns>
        /// The assigned string value for the enum.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Throws if the enum does not have this attribute specified.
        /// </exception>
        /// <seealso cref="StringValueAttribute"/>
        public string GetStringValue()
        {
            ArgumentNullException.ThrowIfNull(value);

            Type type = value.GetType();
            string? name = Enum.GetName(type, value);
            if (name is null) return value.ToString();

            FieldInfo? field = type.GetField(name);
            if (field is null) return value.ToString();
            
            StringValueAttribute? attr = field.GetCustomAttribute<StringValueAttribute>();
            return attr?.Value ?? name;
        }
    }
}