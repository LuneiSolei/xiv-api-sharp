namespace XivApiSharp.Client.Core.Clauses.Builders;

/// <summary>
/// Defines a type that is used to determine the language type when using the
/// clause builder.
/// </summary>
public interface IOptionalLanguageStep : IOptionalDecoratorStep
{
    /// <summary>
    /// Sets the Language property.
    /// </summary>
    /// <param name="lang">The language to use.</param>
    /// <returns>The next step in the clause building process.</returns>
    IOptionalDecoratorStep WithLanguage(SchemaLanguage lang);
}