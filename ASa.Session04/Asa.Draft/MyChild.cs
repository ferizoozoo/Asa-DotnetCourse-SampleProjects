using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.Draft
{
    class MyChild : MyClass
    {
        public override void Print()
        {
            Console.WriteLine("******");
            Console.WriteLine($"This is {nameof(MyChild)}.");
            Console.WriteLine("******");

        }
    }
}
