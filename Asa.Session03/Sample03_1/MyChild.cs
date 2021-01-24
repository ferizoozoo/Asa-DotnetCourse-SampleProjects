using System;
using System.Collections.Generic;
using System.Text;

namespace Sample03_1
{
    class MyChild : MyParentClass
    {
        //public new void Print()
        //{
        //    Console.WriteLine(nameof(MyChild));
        //}
        public override void Print()
        {

            Console.WriteLine("This is " + nameof(MyChild));
        }

        public void ChildPrint()
        {
            Console.WriteLine("It's child.");
        }


    }
}
