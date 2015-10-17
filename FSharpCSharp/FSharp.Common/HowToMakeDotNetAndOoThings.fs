namespace FSharp.Common

open System

// "type" for everything!

type MonthEnum =
    | January = 1
    | February = 2
    | March = 3
    | April = 4
    | May = 5
    | June = 6
    | July = 7
    | August = 8
    | September = 9
    | October = 10
    | November = 11
    | December = 12





// class
type MyClass () =
    member val Name = "" with get, set
    member val Age = 0 with get, set





// struct
type MyStruct = // <-- no default, primary constructor
    struct // <- has its own keyword
        val Name : string
        val Age : int
        new (name, age) = { Name = name; Age = age } // <-- constructor
    end





// interface
// No keyword; contains only abstract members: no implementation, no let or do bindings, no constructor
type IMyInterface =
    abstract member Name : string with get, set
    abstract member Age : int with get, set





// Add the AbstractClassAttribute and that interface becomes an abstract class
// No keyword, just an attribute. May have implementation, let and do bindings.
[<AbstractClass>]
type NotAnInterface =
    abstract member Name : string with get, set
    abstract member Age : int with get, set



    

// abstract class
[<AbstractClass>]
type MyAbstractClass () =

    abstract member Name : string with get, set

    // A virtual function is declared in two parts: the "abstract" (above)
    // and a default implementation (below).
    default val Name : string = "" with get, set

    // Implement an interface
    interface IMyInterface with
        member this.Name with get() : string = this.Name and set(value:string) = this.Name <- value // Name is virtual
        member val Age : int = 0 with get, set

        // There is no implicit interface implementation in F#; it must be explicit.
        // As such, we are implementing IMyInterface.Name by delegating to the abstract Name property,
        // which in turn has a default implementation that returns an empty string, but which could be
        // overridden in a derived class.

        // Age is implemented as an auto-property with an initial value of 0.
        // It cannot be overridden.

    // Implement a protected function
    // (visible in dervied classes only)
    // abstract member protected ImplementMe () = do something 
    //
    // Just kidding. There is no "protected" access modifier in F#!
    //
    // No sealed modifier for members either. Sorry! Get over it.
    // Sorry for telling you to get over it, but not really.
    //
    // You can use the [<Sealed>] attribute to mark a class.






// use C# "params"
module ParamsDemo =

    // cannot use curried arguments
    // member this.AcceptsParams fooArg barArg ([<ParamArray>]args:string array) = ()

    // must use tuplized arguments and ParamArrayAttribute
    let AcceptsParams (fooArg, barArg, [<ParamArray>]args:string array) = ()
    let NoParams (fooArg, barArg, args:string array) = ()

    // This is strictly for C# consumption; you must use an array explicitly in F#.
    // let noGood = AcceptsParams ("foo", "bar", "baz", "bing", "bam", "boom")
    let good = AcceptsParams ("foo", "bar", [| "baz"; "bing"; "bam"; "boom" |])

[<AbstractClass>]
type ParamsInAbstractMembers () =

    // In interfaces and abstract classes, the ParamArrayAttribute does not go in the signature.
    abstract member AcceptsParams : string * string * string array -> unit

type ParamsInAConcreteClass () =
    inherit ParamsInAbstractMembers()

    // It only goes in the implementation.
    override this.AcceptsParams (foo, bar, [<ParamArray>] args) = ()
