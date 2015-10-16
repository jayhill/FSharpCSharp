using System;
using System.Text;
using FSharp.Common;
using Microsoft.FSharp.Core;

namespace CSharp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Demo();
            Console.WriteLine();
            Console.WriteLine("Press Enter to quit...");
            Console.ReadLine();
        }

        static partial void Demo();
    }
}