using System;

namespace Draft
{
    class Program
    {
        static void Main(string[] args)
        {
            //Conn

            //Open
            //=> Exception
            //Close
            //try
            //{
            //    MyClass myClass = new MyClass();
            //    myClass.Action(90);
            //    myClass.Action(1000);
            //    Console.WriteLine("Done.");

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}");
            //}
            ////finally
            ////{
            ////    Console.WriteLine("Done.");
            ////}

            using (var myClass = new MyClass())
            {
                myClass.Action(90);
            }

            using (var myClass = new MyClass())
            {
                myClass.Action(0);
            }
            Console.ReadLine();
        }
    }
}
