namespace XivApiSharp.Client.Infrastructure.Requests.Clauses.Steps;

public interface IConditionStep
{
    IOperatorStep Is();
    IOperatorStep IsNot();
}