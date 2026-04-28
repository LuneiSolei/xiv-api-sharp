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
    [StringValue("")]
    None,

    /// <summary>Japanese</summary>
    ///
    [StringValue("ja")]
    JA,

    /// <summary>English</summary>
    [StringValue("en")]
    EN,

    /// <summary>German</summary>
    [StringValue("de")]
    DE,

    /// <summary>French</summary>
    [StringValue("fr")]
    FR,

    /// <summary>Chinese (Simplified)</summary>
    [StringValue("chs")]
    CHS,

    /// <summary>Chinese (Traditional)</summary>
    [StringValue("cht")]
    CHT,

    /// <summary>Korean</summary>
    [StringValue("kr")]
    KR
}