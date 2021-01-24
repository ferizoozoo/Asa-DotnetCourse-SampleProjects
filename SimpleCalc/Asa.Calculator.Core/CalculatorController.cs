using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.Calculator.Core
{
    public class CalculatorController
    {
        InputProcessor _processor;
        CalculatorEngine _engine;

        public CalculatorController()
        {
            _processor = new InputProcessor();
            _engine = new CalculatorEngine();
        }
        public decimal Execute(Command cmd)
        {
            var operation = _processor.ParsOperatin(cmd.Operation);
            switch (operation)
            {
                case Operation.Add:
                    return DoAdd(cmd.Operands);
                default:
                    throw new InvalidOperationException($"Cannot processe the command!");
            }
        }
        public string[] GetAllValidOperations() => new string[] { Operation.Add.ToString(), Operation.Subtract.ToString() };
        
        private decimal DoAdd(string[] operands)
        {
            var operand1 = _processor.ParsInput(operands[0]);
            var operand2 = _processor.ParsInput(operands[1]);
            return _engine.Add(operand1, operand2);
        }
    }
}
