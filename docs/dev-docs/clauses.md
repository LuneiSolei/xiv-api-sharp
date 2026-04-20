# Clauses

> [!NOTE]
> Our implementation of clauses differs slightly from the official XIV API 
> documentation. 
> 
> This is due to the fact that using the official syntax verbatim may 
> result in some undesired behavior such as returning results that don't 
> quite match what was queried.

## Base Clause

<hr/>

Clauses are blocks of text inside QueryStrings which apply various rules when 
comparing a specifier against a value. In their most basic form, a clause 
consists of the following: `[specifier][operator][value]`


1) **Specifier:** The name of the field to compare the value to.
2) **Operator:** The type of comparison to perform.
3) **Value:** The value of the field.

> Example:
> > Literal: Foo="Bar"
> >
> > URI Encoded: `Foo%3D%22Bar%22`
> >
> > Matches when a result's "Foo" field has a value of "Bar".

In the above example:

* Specifier = `Foo`
* Operator = `=`
* Value = `"Bar"` (quotations included)

## Specifiers

<hr/>

Specifiers determine which field to apply the comparison operator to. They also
have their own small set of syntax and rules.

> [!IMPORTANT]
> Specifiers are CASE SENSITIVE! Use PascalCase. 
> > "Name" != "name"

<br/>

Dot notation can be used to specify fields nested inside structs and other 
relationships:

> Example:
> > Literal: `ClassJob.Abbreviation="BLM"`
> >
> > URI Encoded: `ClassJob.Abbreviation%3D%22BLM%22`
> > 
> > Matches when the field "ClassJob" contains an object that contains 
> > a field called "Abbreviation" that itself matches "BLM".

Similarly, array access notation can be used to specify elements in an array:

> Example:
> > Literal: `BaseParam[2].Name="Spell Speed"`
> >
> > URI Encoded: `BaseParam%5B2%5D.Name%3D%22Spell%20Speed%22`
> >
> > Matches when the second (2nd) element of an array that is in a field called 
> > "BaseParam" contains a field called "Name" that itself has a value of 
> > "Spell Speed".

Lastly, languages may be specified, individually per clause, via an `@` 
decorator:

> Example: 
> > Literal: `Name@ja="天使の筆"`
> > 
> > URI Encoded: `Name%40ja%3D%22%E5%A4%A9%E4%BD%BF%E3%81%AE%E7%AD%86%22`
> > 
> > Matches results where the "Name" field has a value of "天使の筆" in the 
> > Japanese language.

> [!NOTE]
> Non-English characters are non-ASCII which means that they must be URI 
> encoded.

## Operators

<hr/>

Clauses support multiple comparison operations.

| Operation             | Applicable Type | Example                                                                                                       | Description                                       |
|-----------------------|-----------------|---------------------------------------------------------------------------------------------------------------|---------------------------------------------------|
| `=`                   | any             | `Name="Curtana"` <br/><br/>Only matches "Name" fields that are exactly "Curtana".                             | Matches on exact value.                           |
| `>=`, `>`, `<=`, `<`  | number          | `Amount<=243.03`                                                                                              | Matches on mathematical statements that are true. |
| `~`                   | string          | `Name~"Phantom"` <br/><br/>Matches "Name" fields that contain the word "Phantom" anywhere inside their value. | Matches on partial string values.                 |

## Values

<hr/>

Values may be any one of the following:

| Type   | Example           |
|--------|-------------------|
| string | `"some value"`    |
| number | `1`, `-2`, `3.0`  |
| bool   | `true`, `false`   |

> [!CAUTION]
> String values *MUST* include the double quotation marks.


## Multiple Clauses & Decorators

<hr/>

Decorators are extra syntax that modify the behavior of a clause. An earlier 
example showcased this via the `@` decorator. Pluses (`+`) and minuses 
(`-`) can also be used as decorators by placing them *in front* of the clause.

* **Plus(+):** Result(s) *MUST* match this clause in order to be returned.
* **Minus(-):** Result(s) **MUST NOT** match this clause in order to be 
  returned. In other words, result(s) that do match are thrown out.

> Examples:
> > Literal: `+Name="Runaway Rod"`
> >
> > URI Encoded: `%2BName%3D%22Runaway%20Rod%22`
> >
> > The "Name" field *Must* be "Runaway Rod".
> 
> > `-Name~"Materia XI"`
> >
> > URI Encoded: `-Name~%22Materia %20XI%22`
> >
> > The "Name" field *must not* contain (partially match) the phrase 
> > "Materia XI".

> [!WARNING]
> The second example would reject any "Materia XI" matches, but it would also 
> reject any "Materia XII" matches as well!

> [!TODO]
> Add link to QueryString documentation.

Multiple clauses may be specified in a single QueryString by utilizing 
whitespace between them. Using multiple single clauses and/or grouped 
clauses acts as a logical OR operator; meaning each result returned matches 
at least one single clause or clause group.

> Example:
> > Literal: `Name="Crystal Paste" Icon>=0`
> >
> > Encoded: `Name%3D%22Crystal%20Paste%22%20Icon%3E%3D0`
> >
> > Include any result where the "Name" field is "Crystal Paste" _OR_ the 
> > "Icon" field is greater than 0.

> [!DEV_NOTE]
> Due to the confusing nature of `+` usage in URIs, XIV API Sharp 
> automatically applies URI encoding. However, documentation examples should 
> use:
> * Literal values only
> 
> OR
> 
> * Two (2) examples; one that shows literal values and one that shows URI 
    > encoded values


## Grouping Clauses

<hr/>

Clauses may be "grouped" together via parentheses `()`. Doing so alters 
the behavior of the `+` and `-` decorators when applied to the clause group. 
Similarly to standard clauses, the decorator goes *in front* of the opening 
parenthesis. By default, or with a `+` in front, grouped clauses act as an 
*inclusive* logical OR operation. On the other hand, a `-` means that the 
group acts as an *exclusive* logical OR operation.

The behavior of the `+` and `-` decorators that are applied to *individual* 
clauses (`(-Name~"phantom")`) does not change. Each clause inside a group is 
assessed individually before determining if the group as a whole matches a 
result. In this case, this means that `+` has no effect and is the same as a 
clause without a decorator. However, a `-` still means that a clause *must 
not* match and therefore, still negates that individual clause.

> Examples:
> > Literal: `-(Name~"phantom" -Icon=30694)`
> >
> > URI Encoded: `-(Name~%22phantom%22%20-Icon%3D30694)`
> >
> > Exclude any result where either the "Name" field contains the word 
> > "phantom" OR the "Icon" field is not 30694.
> 
> > Literal: `+(Name~"phantom" +Icon=30694)`
> >
> > URI Encoded: `%2B(Name~%22phantom%22%20%2BIcon%3D30694)`
> >
> > Include any result where either the "Name" field contains the word "phantom"
> > OR the "Icon" field is 30694.
> 
> > > [!NOTE]
> > > This is exactly the same as `+(Name~"phantom" Icon=30694)` or 
> > > `(Name~"phantom" Icon=30694)` or `(Name~"phantom" +Icon=30694)`
> 
> > Literal: `+Name~"paste" -(Name~"crystal" Icon=25101)`
> >
> > URI Encoded: `%2BName~%22paste%22%20-%28Name~%22crystal%22%20Icon%3D25101
> > %29`
> >
> > Include any result where:
> > * The "Name" field contains the word "paste".
> > 
> > AND exclude the results where EITHER:
> > * The "Name" does not contain the word "crystal".
> > * The "Icon" field is not 25101.