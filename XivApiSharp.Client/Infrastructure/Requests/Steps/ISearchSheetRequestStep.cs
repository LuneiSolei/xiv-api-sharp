using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Enums;

namespace XivApiSharp.Client.Infrastructure.Requests.Steps;

public interface ISearchSheetRequestStep
{
    // Sheets
    ISearchSheetRequestStep WithSheet(string sheet);
    ISearchSheetRequestStep WithSheets(List<string> sheets);
    
    // Query
    ISearchSheetRequestStep WithClause(Clause clause);
    ISearchSheetRequestStep WithClauses(IEnumerable<Clause> clauses);
    ISearchSheetRequestStep WithClauseGroup(ClauseGroup group);
    ISearchSheetRequestStep WithClauseGroups(IEnumerable<ClauseGroup> groups);
    
    // Parameters
    ISearchSheetRequestStep WithVersion(string version);
    ISearchSheetRequestStep WithCursor(string cursor);
    ISearchSheetRequestStep WithLimit(uint limit);
    ISearchSheetRequestStep WithLanguage(SchemaLanguage lang); 
    ISearchSheetRequestStep WithSchema(string schemaSpecifier);
    ISearchSheetRequestStep WithFields(List<string> fields);
    ISearchSheetRequestStep WithTransient(string transient);

    string Build();

    /*
     * TODO: Define SchemaLanguage, SchemaSpecifier, and FilterString as used
     * by XIV API
     */
}