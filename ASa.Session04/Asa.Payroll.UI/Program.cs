using System;

namespace Asa.Payroll.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PayrollMenu menu = new PayrollMenu();
            menu.Render();

            Console.ReadLine();
        }
    }
}
