using System.Numerics;

namespace XivApiSharp.Client.Core.Clauses;

public interface IValueStep
{
    IClause<T> WithValue<T>(T value);

    IClause<string> WithValue(string value);

    IClause<bool> WithValue(bool value);
}