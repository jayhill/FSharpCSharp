module Collections
    
// Arrays are one-to-one between F# and C#

// FSharpMap<'key,'value>, FSharpList<'t> and FSharpSet<'t>
// do not have C# equivalents but can be used in C#.
// Rule of thumb: don't.

// map<'key,'value> implements IDictionary<'key,'value>
// System.Collections.Generic.Dictionary<'key,'value> is also useful in F#.
// It is faster than Map for large sets.

// list<'t> does NOT implement IList<'t>!
// list is central to many functional idioms in F# and has the richest
// pattern-matching support of any collection structure.
// You definitely don't want to try to use IList<'t> instead and
// I recommend against using FSharpList<'t> in C#.

// seq<'t> is the great equalizer.
// It will be exposed to C# as IEnumerable<T> and vice-versa,
// which means your F# functions can accept seqs and be passed
// any IEnumerable<T> in C# code.

let CanEnterExpressLane items = Seq.length items <= 10