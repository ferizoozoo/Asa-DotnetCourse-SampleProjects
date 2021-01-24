using System;
using System.Collections;
using System.Collections.Generic;

namespace Asa.Draft
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //MyClass child = new MyChild();
            //child.Print();
            //child.Add();
            //List<int> myList = new List<int> { 1,2,3,4,5};
            //Stack<int> mystack = new Stack<int>();
            //mystack.Push(9);
            //mystack.Push(76);
            //mystack.Push(43);
            //mystack.Push(26);
            //for (int i = 0; i < myList.Count; i++)
            //{
            //    Console.WriteLine(myList[i]);
            //}

            //for (int i = 0; i < mystack.Count; i++)
            //{
            //    Console.WriteLine(mystack.Pop());
            //}

            //foreach (var item in myList)
            //{

            //}
            EvenList lst = new EvenList();
            lst.Add(1).Add(2).Add(3);
            foreach (var item in lst)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
