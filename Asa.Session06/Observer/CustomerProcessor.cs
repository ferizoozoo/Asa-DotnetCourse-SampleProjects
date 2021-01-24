using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Observer
{
    public class CustomerProcessor
    {
        List<Customer> _customers;
        public CustomerProcessor(List<Customer> customers)
        {
            _customers = customers;
        }

        public List<Customer> ProcessLoans1(int maxLoan)
        {
            List<Customer> customers = new List<Customer>();
            foreach (var item in _customers)
            {
                Thread.Sleep(10);
                if (item.Loan <= maxLoan)
                {
                    customers.Add(item);
                }
            }
            return customers;
        }





        public void ProcessLoans2(int maxLoan, ICustomerLoanCallback callback)
        {
            foreach (var item in _customers)
            {
                Thread.Sleep(10);
                if (item.Loan <= maxLoan)
                {
                    callback.Print(item);
                }
            }
        }


        public void ProcessLoans3(int maxLoan, Action<Customer> action)
        {
            foreach (var item in _customers)
            {
                Thread.Sleep(10);
                if (item.Loan <= maxLoan)
                {
                    action(item);
                }
            }
        }





        public event EventHandler<Customer> LargeLoanFound;
        public void ProcessLoans4(int maxLoan)
        {


            foreach (var item in _customers)
            {
                Thread.Sleep(10);
                if (item.Loan <= maxLoan)
                {
                    LargeLoanFound(this, item);
                }
            }
        }

    }
}
