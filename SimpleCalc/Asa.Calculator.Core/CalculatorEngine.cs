using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.Calculator.Core

{
    public class CalculatorEngine
    {
        //SOLID
        //SRP
        //Axis of change 
        public decimal Add(decimal a, decimal b)
        {
            return a + b;
        }
        public decimal Subtract(decimal a, decimal b) => a - b;


    }
}
