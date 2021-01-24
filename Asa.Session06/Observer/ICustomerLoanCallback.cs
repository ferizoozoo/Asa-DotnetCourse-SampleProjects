using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public interface ICustomerLoanCallback
    {
        void Print(Customer customer);
    }
}
