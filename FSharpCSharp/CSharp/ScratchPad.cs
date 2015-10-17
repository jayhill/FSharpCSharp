using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FSharp.Common;
using Microsoft.FSharp.Core;

namespace CSharp { partial class Program { static partial void Demo()
{

    var doubleResult = MyModule.double_c.Invoke(3);

    var multResult = MyModule.multiply_e.Invoke(3).Invoke(4);
    Console.WriteLine(multResult);

} } }