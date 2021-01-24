using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.Calculator.Core
{
    public class InputProcessor
    {
        public Operation ParsOperatin(string input)
        {
            // Implement by pattern matching
            var lowerInput = input.ToLower().Trim();
            switch (input)
            {
                case "add":
                    return Operation.Add;
            }
            throw new NotSupportedException($" {input} is not a valid operation.");
        }
        public decimal ParsInput(string input)
        {

            //throw new NotImplementedException();
            var isDecimal = decimal.TryParse(input, out decimal value);
            if (isDecimal)
            {
                return value;

            }
            else
            {
                throw new InvalidCastException($"Cannot convert {input} to a decimal.");
                //throw new InvalidCastException("Cannot convert" + input + " to a decimal.");
            }

        }
    }
}
