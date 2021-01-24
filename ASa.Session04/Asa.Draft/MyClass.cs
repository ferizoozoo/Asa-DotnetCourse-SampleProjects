using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.Draft
{
    class MyClass
    {
        public virtual void Print()
        {
            Console.WriteLine($"This is {nameof(MyClass)}.");
        }
        public void Add()
        {
            //CTRL+K+D
            Console.WriteLine("1+1=2");
        }
    }
}
