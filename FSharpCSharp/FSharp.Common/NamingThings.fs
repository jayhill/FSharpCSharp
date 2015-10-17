namespace FSharp.Common

module Names =

    // Will show up in C# -- yay!
    let LearnHowToUnderstandNameCompilationInFSharp = ()

    // Notice the tick mark at the end. Won't show up in C#.
    let LearnHowToUnderstandNameCompilationInFSharp' = ()

    // This can be a nice feature for something like the commented code below.
    // This won't show up in C#
    let ``learn how to understand name compilation in F#`` = ()

//    let myWorkflow data =
//       data
//       |> ``parse the data``
//       |> ``validate to ensure the data is in the expected shape``
//       |> ``remove duplicates``
//       |> ``log count``
//       |> ``perform calculations``
//       |> ``log results``
//       |> ``generate report``
//       |> ``post to report distribution api``
//       |> ``log completion metrics``
//       |> ``check out how friggin' declarative this workflow is!``

    // Add the CompiledNameAttribute to get these things to show up in C#.
    [<CompiledName("LearnCompilation")>]
    let ``here is a long F# name with lots of illegal characters!$#%^&*`` =
        "I will compile as a function called LearnCompilation and I will be visible in C# as such."

// An F# module like this, called "String" can add utility functions but can also cause
// ambiguity issues in conflicts in C#.
// CompiledNameAttribute does not work on modules. You don't get an error, but the compiled
// module name does not change.
// You may use the CompilationRepresentationAttribute with
// CompilationRepresentationFlags.ModuleSuffix and then the compiled module name
// will become StringModule.
[<AutoOpen>]
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>] // look it up
module String =
    let equalsIgnoreCase a b =
        System.String.Equals(a, b, System.StringComparison.OrdinalIgnoreCase)

    // Be careful about adding members with the same name as in a previously declared/opened
    // module. This "concat" member will shadow the String.concat from FSharp.Core.StringModule.
    let concat () = String.concat "," ["foo"; "bar"; "baz"]

module XYZ =
    let foo = String.equalsIgnoreCase "foo" "FOO" // <-- calling into our String module

    // Can't access String.concat from FSharp.Core because it has been shadowed in
    // our own String module above. This won't compile:
//    let whichConcat () = String.concat "," ["foo"; "bar"; "baz"]