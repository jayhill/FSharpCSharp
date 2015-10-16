using System;
using System.Collections.Generic;

namespace CSharp.Common
{
    public interface ICSharpInterface
    {
        string Property { get; set; }
        void Method();
        int Function(string name, int? age);
    }

    public abstract class CSharpAbstractClass : ICSharpInterface
    {
        public string Property { get; set; }

        public void Method() { }

        public abstract int Function(string name, int? age);

        protected abstract IEnumerable<string> GetSomeStrings();
    }

    public interface IInterfaceWithEvent
    {
        event EventHandler SomethingHappened;
    }

    public abstract class CSharpIntermediateClass : CSharpAbstractClass, IInterfaceWithEvent
    {
        public sealed override int Function(string name, int? age)
        {
            return -1;
        }

        public abstract event EventHandler SomethingHappened;
    }
}