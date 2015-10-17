namespace FSharp.Common

module AugmentationsAndExtensionMethods =

    open System.Collections

    // We can extend types with augmentations at any time, including
    // built-in and third-party types.

    // There are three types of augmentations and they compile differently:
    // 1) implicit extensions:
    //      - compile into the extended type
    //      - must be declared in the same namespace and source file as the extended type
    // 2) optional extensions:
    //      - must be declared in a module
    //      - compile as static methods with encoded names (could theoretically be called
    //          via reflection, but the encoding is not specified in the language spec)
    //      - can be created for any type, including built-in and third-party types
    //      - may only be used as though they are instance members when:
    //          1. in F#, and
    //          2. in a scope where the containing module is open 
    // 3) CLR extension methods:
    //      - same as C# extension methods
    //      - consumable in C# as extension methods
    //      - must be tagged with System.Runtime.CompilerServices.ExtensionAttribute

    type System.Object with
        member o.IsEnumerable =
            o :? IEnumerable

        member o.ToExclamatoryString () =
            if o = null then null
            else o.ToString() + "!"

    type System.Decimal with
        member m.Rounded with get() = System.Math.Round(m)



open System.Runtime.CompilerServices // <-- ExtensionAttribute lives here

[<Extension>] // <-- must put the attribute here…
module DotNetExtensionMethod =

    open AugmentationsAndExtensionMethods

    [<Extension>] // <-- AND here.
    let Rounded (m:decimal) = m.Rounded



module Consumption =

    open DotNetExtensionMethod

//    let dotNextExtensionMethod = (4.5m).Rounded(); // NOPE
    let dotNextExtensionMethod = Rounded 4.5m // SURE!

    // Oddly, you can call an extension method as an instance member when it is
    // defined in C#. You can't when it is defined in F#.

    open System.Collections.Generic
    open CSharp.Common

    // Call an extension method that is declared in a C# -- this works
    let cSharpExtensionMethod (coll:IEnumerable<'t>) =
        coll.Second();

    open AugmentationsAndExtensionMethods
    
    // Call an F# optional extension (function)
    let optionalExtensionMethod = 4.4.ToExclamatoryString ()

    // Call an F# optional extension (property)
    let optionExtensionProperty = 4.5.IsEnumerable