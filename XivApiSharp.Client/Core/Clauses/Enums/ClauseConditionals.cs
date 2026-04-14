namespace XivApiSharp.Client.Core.Clauses.Enums;

/// <summary>
/// Represents the boolean state of a clause.
/// </summary>
/// <seealso cref="Clause{T}"/>
public enum ClauseConditionals
{
    IsNot,
    Is
}

// Use a plain XML doc cref with the fully qualified type name (or the simple name since both types are in the same namespace). Examples (no leading ///, plaintext):
// 
// <summary>Represents the boolean state of a clause.</summary>
// <seealso cref="Clause{T}"/>
// 
// Fully qualified (optional since same namespace):
// <seealso cref="XivApiSharp.Client.Core.Clauses.Clause{T}"/>
// 
// With a concrete type argument:
// <seealso cref="XivApiSharp.Client.Core.Clauses.Clause{SomeType}"/>