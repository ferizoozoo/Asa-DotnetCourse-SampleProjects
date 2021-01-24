using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public class CustomerConsolePrinter : ICustomerLoanCallback
    {
        public void Print(Customer customer)
        {
            Console.WriteLine(customer);
        }
    }
}
