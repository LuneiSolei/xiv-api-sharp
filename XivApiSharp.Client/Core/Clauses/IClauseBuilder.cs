using XivApiSharp.Client.Infrastructure.Clauses.Steps;

namespace XivApiSharp.Client.Core.Clauses;

public interface IClauseBuilder : IInitialClauseBuilderStep, IConditionalStep,
    IOperatorStep
{
    
}