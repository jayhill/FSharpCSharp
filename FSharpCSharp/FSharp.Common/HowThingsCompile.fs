namespace FSharp.Common

open System
open System.Text.RegularExpressions

type MyRecord = {
    name : string
    age : int option
}

[<CLIMutable>]
type MutableRecord = {
    name : string
    age : int option
}
    

type MyUnion =
    | Unknown
    | First of int
    | Second of string
    | Third of double * string


module MyModule = 

    // custom operators
    let public (/~/) pattern input = Regex.IsMatch (pattern, input)

    
// 1 argument

    let double_a i = i * 2

    let double_b = fun i -> i * 2

    let double_c =
        let multiply x y = x * y
        fun i -> multiply i 2

    let double_d i =
        let multiply x y = x * y
        multiply i 2

    let double_e =
        let multiply x y = x * y
        Func<int,int>(fun i -> multiply i 3)


// 2 arguments (curried or tupled)

    let multiply_a x y = x * y

    let multiply_b (x,y) = x * y

    let multiply_c = fun x y -> x * y

    let multiply_d = fun (x,y) -> x * y

    let multiply_e =
        let doMult = fun x y -> x * y
        fun x y -> doMult x y

    let multiply_f =
        let doMult = fun x y -> x * y
        fun (x,y) -> doMult x y


// partial application

    let quadruple = multiply_e 4