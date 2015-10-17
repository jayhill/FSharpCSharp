namespace FSharp.Common

open System
open CSharp.Common

type ImplementsInterface (propertyValue) =

    interface ICSharpInterface with
        member val Property : string = propertyValue with get, set
        member this.Method () = ()
        member this.Function (name, age) = 1

    // Object Expressions
    // It is kind of like being able to create a C# anonymous type that implements an
    // interface or extends another class.
    member this.MyThingFromInterface2 =
        { new ICSharpInterface with
            member x.Property with get() = "foo bar" and set(_) = ()
            member x.Method () = ()
            member x.Function (name, age) = 77 }

    // But, F# does NOT have anonymous types. Sad trombone: wah wah wah.


type InheritsAbstractClass () =
    inherit CSharpAbstractClass ()

    override this.Function (string, age) = 1
    override this.GetSomeStrings () = seq { yield "hello"; yield "world"; }


type InheritsIntermediateClass () =
    inherit CSharpIntermediateClass ()

    // Ugh. Events.
    // You're going to have to look this up.
    // Implemented in 2 parts:
    // 1. the event object
    let somethingHappened = new Event<EventHandler, EventArgs>()

    // 2. The actual .NET event, which is accessed from the event object
    [<CLIEvent>]
    override this.SomethingHappened = somethingHappened.Publish

    // Raise the event by calling Trigger
    member this.RaiseEvent () = somethingHappened.Trigger(this, EventArgs.Empty)

    // This was an abstract function; it must be overridden, just like C#
    override this.GetSomeStrings () = seq { yield "hello"; yield "world"; }

    // "sealed" declared in C# is respected in F#; this sealed function cannot be overridden
//    override this.Function (string, age) = 1 


type ImplementsInterfaceWithEvent () =

    // Seriously.
    // I wasn't kidding about looking it up.

    let somethingHappened = new Event<EventHandler, EventArgs>()

    [<CLIEvent>]
    member this.SomethingHappened = somethingHappened.Publish


    // We add this 3rd part to add and remove handlers.
    interface IInterfaceWithEvent with
        override this.add_SomethingHappened handler = somethingHappened.Publish.AddHandler handler
        override this.remove_SomethingHappened handler = somethingHappened.Publish.RemoveHandler handler