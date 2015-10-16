using FSharp.Common;
using Microsoft.FSharp.Core;
namespace CSharp { class Equality { void Demo() {



    // F# types use structural equality by default
    var one = new FSharpRecord("Jane", FSharpOption<int>.Some(27));
    var two = new FSharpRecord("Jane", new FSharpOption<int>(27));

    var kindOfEqual = one == two;
    var actualEqual = one == one;
    var reallyEqual = one.Equals(two);


    // Attributes can be used to specify equality and comparison characteristics


} } }