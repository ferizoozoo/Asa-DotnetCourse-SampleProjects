using System;
using System.Collections.Generic;

namespace Sample03_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //object o = 12;
            //object o2 = "string";
            MyParentClass myParent = new MyParentClass();
            MyChild myChild = new MyChild();
            //myParent.Print();
            //myChild.Print();

            MyParentClass myParent_Reference_To_Child = new MyChild();
            // myParent_Reference_To_Child.Print();


            MyChild myParent_Child_To_Child = new MyChild();
            // myParent_Child_To_Child.Print();


            //CheckType(myChild);
            //CheckType("my string");

            //DoUnsafeCast(myChild);
            //DoUnsafeCast("my string");

            // DoSafeCast(myChild);

            // DoSafeCast("my string");
            AboutLSP(myParent);
            AboutLSP(myChild);
            
            Console.ReadLine();
        }

        private static void AboutLSP(MyParentClass myObject)
        {
            //LSP Violation
            if (myObject is MyChild child)
            {
                child.ChildPrint();
            }
            else
            {
                myObject.Print();
            }
        }
        private static void DoSafeCast_inLine(object obj)
        {
            if (obj is MyParentClass parent)
            {
                Console.WriteLine("Cast is done!");
            }
            else
            {
                Console.WriteLine("Cast failed!");
            }


        }



        private static void DoSafeCast(object obj)
        {
            MyParentClass parent = obj as MyParentClass;
            if (parent == null)
            {
                Console.WriteLine("Cast failed!");
            }
            else
            {
                Console.WriteLine("Cast is done!");
                parent.Print();
            }
        }

        private static void DoUnsafeCast(object obj)
        {
            MyParentClass parent = (MyParentClass)obj;
            Console.WriteLine("Cast is done!");
        }

        private static void CheckType(object obj)
        {
            bool isMyParentType = obj is MyParentClass;
            Console.WriteLine(isMyParentType);
        }
    }
}
