module Basics

// unit is a thing
// fn() does not an empty arg list*
type UnitFn = unit -> unit

let unitFn1 () = ()

let unitFn2 = fun () -> ()

let myVal = Some ()







// curried and tupled arguments are not the same
let curriedArgs foo bar baz = ()

type CurrySignature = int -> int -> int -> unit

let tupledArgs (foo, bar, baz) = ()

type TupleSignature = int * int * int -> unit





// Whether arguments are curried or tuplized, every
// function accepts one argument and retuns one result.