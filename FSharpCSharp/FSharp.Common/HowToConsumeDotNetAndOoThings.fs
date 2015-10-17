namespace FSharp.Common

open System
open CSharp.Common

type ImplementsInterface (propertyValue) =

    interface ICSharpInterface with
        member val Property : string = propertyValue with get, set
        member this.Method () = ()
        member this.Function (name, age) = 1

    member this.MyThingFromInterface2 =
        { new ICSharpInterface with
            member x.Property with get() = "foo bar" and set(_) = ()
            member x.Method () = ()
            member x.Function (name, age) = 77 }







type InheritsAbstractClass () =
    inherit CSharpAbstractClass ()

    override this.Function (string, age) = 1
    override this.GetSomeStrings () = seq { yield "hello"; yield "world"; }








type InheritsIntermediateClass () =
    inherit CSharpIntermediateClass ()

    // Ugh. Events.
    // You're going to have to look this up.
    let somethingHappened = new Event<EventHandler, EventArgs>()

    [<CLIEvent>]
    override this.SomethingHappened = somethingHappened.Publish

    member this.RaiseEvent () = somethingHappened.Trigger(this, EventArgs.Empty)

//    override this.Function (string, age) = 1 // <-- "sealed" works from C#
    override this.GetSomeStrings () = seq { yield "hello"; yield "world"; }







type ImplementsInterfaceWithEvent () =

    let somethingHappened = new Event<EventHandler, EventArgs>()

    [<CLIEvent>]
    member this.SomethingHappened = somethingHappened.Publish

    // Seriously.
    // I wasn't kidding about looking it up.
    // You should come to terms with it.

    interface IInterfaceWithEvent with
        override this.add_SomethingHappened handler = somethingHappened.Publish.AddHandler handler
        override this.remove_SomethingHappened handler = somethingHappened.Publish.RemoveHandler handler