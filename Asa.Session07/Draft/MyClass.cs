using System;
using System.Collections.Generic;
using System.Text;

namespace Draft
{
    class MyClass : IDisposable
    {
        public void Action(int i)
        {
            if (i > 100)
            {
                Console.WriteLine($"Result: {i * 10}");
            }
            else
            {

                int sx = 100 / i;
            }
        }

        public void Dispose()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Done!");
            Console.WriteLine("Done!");
            Console.WriteLine("Done!");
            Console.WriteLine("Done!");
            Console.WriteLine("Done!");
            Console.WriteLine("Done!");
            Console.ForegroundColor = ConsoleColor.White;


        }
    }
}
