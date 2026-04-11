namespace XivApiSharp.Client.Infrastructure.Requests.Clauses.Steps;

public interface IInitialClauseBuilderStep
{
    IConditionStep WhereField(string name);
}