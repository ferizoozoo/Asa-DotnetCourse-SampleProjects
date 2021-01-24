using System;

namespace Asa.Calculator.Core
{
    public class Command
    {
        public Command()
        {
            Operands = new string[2];
        }
        public string Operation { get; set; }
        public string[] Operands { get; set; }

        //private string _operation;
        //public string getOperation() => _operation;
        //public string setOperation(string value) => _operation=value;



    }
}
