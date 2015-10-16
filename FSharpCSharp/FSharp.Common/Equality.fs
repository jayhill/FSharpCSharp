namespace FSharp.Common

open System

type FSharpRecord = {
    name : string
    age : int option
}

type FSharpUnion = Yes | No | Maybe of likelihood:decimal