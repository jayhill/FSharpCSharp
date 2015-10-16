namespace FSharp.Common

module Names =

    let LearnHowToUnderstandNameCompilationInFSharp = ()

    let LearnHowToUnderstandNameCompilationInFSharp' = ()

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












[<AutoOpen>]
//[<CompiledNameAttribute("StringUtils")>]
module String =
    let equalsIgnoreCase a b =
        System.String.Equals(a, b, System.StringComparison.OrdinalIgnoreCase)

    let concat () = ()

module XYZ =
    let foo = String.equalsIgnoreCase "foo" "FOO"