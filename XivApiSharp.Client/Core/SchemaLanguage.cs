namespace XivApiSharp.Client.Core;

/// <summary>
/// Known languages supported by FFXIV's data format.
/// </summary>
/// <remarks>
/// Not all languages that are supported by the format are valid for all
/// versions/editions of FFXIV. For example, the global game client acknowledges
/// the existence of the <c>CHS</c> and <c>KR</c> languages, but does not
/// provide any data for them. 
/// <br/>
/// <br/>
/// *Based on the documentation provided by XIV API's
/// <see href="https://v2.xivapi.com/api/docs#model/SchemaLanguage">SchemaLanguage</see>.
/// </remarks>
public enum SchemaLanguage
{
    /// <summary>No language specified.</summary>
    None,
    
    /// <summary>Japanese</summary>
    JA,
    
    /// <summary>English</summary>
    EN,
    
    /// <summary>German</summary>
    DE,
    
    /// <summary>French</summary>
    FR,
    
    /// <summary>Chinese (Simplified)</summary>
    CHS,
    
    /// <summary>Chinese (Traditional)</summary>
    CHT,
    
    /// <summary>Korean</summary>
    KR
}