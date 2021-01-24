using Asa.Payroll.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.Payroll
{
    public class PayrollController
    {
        Organization _Organization;
        public PayrollController()
        {
            _Organization = new Organization();
        }
        public void AddEmploye(PermanentEmployeDTO employe)
        {
            //   var permanentEmploye = new PermanentEmploye(employe.FirstName, employe.LastName, employe.Salary, employe.OverWorkSalary, employe.OverWorkInHours, employe.TaxRate);
            // _Organization.AddEmploye(permanentEmploye);
        }

//        public List<EmployeType> GetAllEmployeeTypes() => new List<EmployeType> { EmployeType.Contract, EmployeType.Hourly, EmployeType.Permanent };

        public void AddEmploye(ContractEmployeDTO employe)
        {
            //    var contractEmploye = new ContractEmploye(employe.FirstName, employe.LastName, employe.Salary, Organization.MAX_ALLOWED_SALARY_FOR_CONTRACT_EMPLOYEE);
            //   _Organization.AddEmploye(contractEmploye);

        }
    }
}
