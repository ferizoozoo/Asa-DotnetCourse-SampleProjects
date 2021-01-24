using Asa.Payroll.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.Payroll.UI
{
    class PayrollMenu : IUIElement
    {


        Dictionary<EmployeType, IUIElement> _employeForms;
        public PayrollMenu()
        {
            _employeForms = new Dictionary<EmployeType, IUIElement>();
            _employeForms.Add(EmployeType.Permanent, new PermanentEmployeForm());
        }
        public void Render()
        {
            Console.Clear();
            int index = 0;

            foreach (var item in _employeForms)
            {
                index++;
                Console.WriteLine($"{ index}.{item.Key}");
            }
            Console.WriteLine("Choos an item.");
            var selected = (EmployeType)int.Parse(Console.ReadLine());
            var selectedForm = _employeForms[selected];
            selectedForm.Render();
        }
    }
}
