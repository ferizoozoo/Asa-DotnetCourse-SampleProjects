using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.Payroll.DTO
{
    public class PermanentEmployeDTO
    {
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public decimal Salary { get; set; }
        public int OverWorkInHours { get; set; }
        public decimal TaxRate { get; }
        public decimal OverWorkSalary { get; set; }
    }
}
