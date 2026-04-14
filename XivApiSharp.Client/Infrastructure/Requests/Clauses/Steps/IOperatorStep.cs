using System.Numerics;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Requests.Clauses.Steps;

public interface IOperatorStep
{
    // Equal To
    Clause<string> EqualTo(string value);
    Clause<bool> EqualTo(bool value);
    Clause<T> EqualTo<T>(T value) where T : INumber<T>;
    
    // Partially Equal To
    Clause<string> PartiallyEqualTo(string value);
    
    // Greater Than
    Clause<T> GreaterThan<T>(T value) where T : INumber<T>;
    
    // Greater Than or Equal To
    Clause<T> GreaterThanOrEqualTo<T>(T value) where T : INumber<T>;
    
    // Less Than
    Clause<T> LessThan<T>(T value) where T : INumber<T>;
    
    // Less Than or Equal To
    Clause<T> LessThanOrEqualTo<T>(T value) where T : INumber<T>;
}