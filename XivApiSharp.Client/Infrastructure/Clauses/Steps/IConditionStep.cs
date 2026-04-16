namespace XivApiSharp.Client.Infrastructure.Clauses.Steps;

public interface IConditionStep
{
    IOperatorStep MustBe { get; }
    IOperatorStep MustNotBe { get; }
}