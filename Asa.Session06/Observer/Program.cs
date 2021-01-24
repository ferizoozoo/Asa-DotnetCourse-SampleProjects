using System;
using System.Collections.Generic;
using System.Threading;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>(10000);
            for (int i = 0; i < 1000; i++)
            {
                Random r = new Random();
                customers.Add(new Customer { Name = $"Customer-{i + 1}", Loan = r.Next(1000, 1000000) });
                Thread.Sleep(5);
            }
            Console.WriteLine("Start");


            CustomerProcessor customerProcessor = new CustomerProcessor(customers);


            //var result= customerProcessor.ProcessLoans1(900000);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}


            //Observer

            //Interface
            //var printer = new CustomerConsolePrinter();
            //customerProcessor.ProcessLoans2(900000, printer);

            //Delegate
            // customerProcessor.ProcessLoans3(900000, x => Console.WriteLine(x));
            
            //Event

            customerProcessor.LargeLoanFound += CustomerProcessor_LargeLoanFound;
            customerProcessor.ProcessLoans4(900_000);
            Console.WriteLine("End");

            Console.ReadLine();
        }

        private static void CustomerProcessor_LargeLoanFound(object sender, Customer e)
        {
            Console.WriteLine(e);
        }
    }
}
