namespace FSharp.Common

open System

// F# types use structural equality by default, rather than reference equality.
// The compiler implicitly adds implementations of System.IEquatable<'t> and
// System.IComparable<'t>.

type FSharpRecord = {
    name : string
    age : int option
}

type FSharpUnion = Yes | No | Maybe of likelihood:decimal

// In order to control this, one must use a combination of attributes:

// open Microsoft.FSharp.Core

// [<CustomEqualityAttribute>]   // allows you to override IEquatable<'t>.Equals(…)
// [<CustomComparisonAttribute>] // allows you to override IComparable<'t>.CompareTo(…)
// [<NoEqualityAttribute>]       // omits IEquatable<'t>
// [<NoComparisonAttribute>]     // omits IEquatable<'t>

// When an attribute is specified for equality or comparison,
// an attribute must also be specified for the other.