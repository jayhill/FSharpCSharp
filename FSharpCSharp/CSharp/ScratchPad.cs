using System;
using System.Collections.Generic;
using FSharp.Common;

namespace CSharp { partial class Program { static partial void Demo()
{

    var x = ExpressionsAndQuotations.squareExpr.Compile().Invoke(3);
    Console.WriteLine(x);

} } }