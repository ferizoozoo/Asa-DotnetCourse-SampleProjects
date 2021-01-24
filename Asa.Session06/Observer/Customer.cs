using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public class Customer
    {
        public string Name{ get; set; }
        public int Loan{ get; set; }
        public override string ToString() => $"Name: {Name} Loan:{Loan} RLS";
        
    }
}
