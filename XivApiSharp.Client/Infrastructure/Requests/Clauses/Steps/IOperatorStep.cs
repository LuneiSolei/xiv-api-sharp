using System.Numerics;
using XivApiSharp.Client.Core;

namespace XivApiSharp.Client.Infrastructure.Requests.Clauses.Steps;

public interface IOperatorStep
{
    // Partially Equal To
    Clause PartiallyEqualTo(string value);
    Clause PartiallyEqualTo(bool value);
    Clause PartiallyEqualTo<T>(T value) where T : INumber<T>;
    
    // Equal To
    Clause EqualTo(string value);
    Clause EqualTo(bool value);
    Clause EqualTo<T>(T value) where T : INumber<T>;
    
    // Greater Than
    Clause GreaterThan(string value);
    Clause GreaterThan<T>(T value) where T : INumber<T>;
    
    // Greater Than or Equal To
    Clause GreaterThanOrEqualTo(string value);
    Clause GreaterThanOrEqualTo<T>(T value) where T : INumber<T>;
    
    // Less Than
    Clause LessThan(string value);
    Clause LessThan<T>(T value) where T : INumber<T>;
    
    // Less Than or Equal To
    Clause LessThanOrEqualTo(string value);
    Clause LessThanOrEqualTo<T>(T value) where T : INumber<T>;
}