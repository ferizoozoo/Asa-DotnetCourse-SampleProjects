using Asa.Calculator.Core;
using System;

namespace Asa.Calculator.UI
{
    class Program
    {
        static void Main(string[] args)
        {

            #region exception sample
            //var myValue = "str";
            //try
            //{
            //    //decimal.Parse(myValue);
            //    var inp = new InputProcessor();
            //    inp.ParsInput(myValue);

            //    //Handle
            //    //Repalce
            //    //Wrap


            //}
            //catch (InvalidCastException invalidcastExp)
            //{
            //    Console.WriteLine(invalidcastExp.Message);
            //}
            //catch (Exception ex)
            //{
            //    //Log
            //    Console.WriteLine("Fatal Error:" + ex.Message);
            //    return;
            //}
            #endregion exception sample

            //Show Operation
            var controller = new CalculatorController();

            Console.WriteLine("Operations:");
            var operations = controller.GetAllValidOperations();
            for (int i = 0; i < operations.Length; i++)
            {
                Console.WriteLine(operations[i]);
            }

            var selectedOperation = Console.ReadLine();
            var operand1 = Console.ReadLine();
            var operand2 = Console.ReadLine();
            
            var cmd = new Command();
            cmd.Operands[0] = operand1;
            cmd.Operands[1] = operand2;
            cmd.Operation = selectedOperation;
            var result=controller.Execute(cmd);
            Console.WriteLine(result);
            
            //GOF
            Console.ReadLine();


        }
    }
}