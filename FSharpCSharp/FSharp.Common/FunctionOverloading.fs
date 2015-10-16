module FunctionOverloading

// Functions in a module may not be overloaded.
// Why not?
let myFunction a b = a + b
//let myFunction (a:int) (b:int) = a + b
//let myFunction (a:decimal) (b:decimal) = a + b
//let myFunction a b c = myFunction a b |> myFunction c

// In a type, let-bound values can be shadowed
type MyClass (name, age) =
    let myFunction a b = a + b
    let myFunction a b c = myFunction a b |> myFunction c
    let myFunction (a:decimal) b = a + b

    member this.TestOverloads () =
//        let result = myFunction 1 1
//        let result' = myFunction 1 1 1
//        let result'' = myFunction (decimal 1) (decimal 1)
        ()

// Member functions *can* be overloaded, but not by arity.
type MyRecord = {
    name : string
    age : int
}
with member this.CalculateAgeToRankRatio rank = decimal(this.age) / decimal(rank)
     member this.CaluclateAgeToRankRatio rank = decimal(this.age) / rank
//     member this.CaluclateAgeToRankRatio rank adjustment = decimal(this.age) / (rank * adjustment)

     // Overloaded functions may only take one argument, so "multiple arguments" must be tuplized.
     // Why must they take only one argument?
     member this.CalculateAgeToRankRatio (rank, adjustment) = decimal(this.age) / (rank * adjustment)