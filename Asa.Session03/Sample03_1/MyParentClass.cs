using System;
using System.Collections.Generic;
using System.Text;

namespace Sample03_1
{
    class MyParentClass 
    {
        public virtual void Print()
        {
            Console.WriteLine(nameof(MyParentClass));
        }
        // protected
        // virtual
        // override
    }
}
