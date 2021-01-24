using System.Collections.Generic;

namespace Asa.Payroll
{
    internal class Organization
    {
        public const decimal MAX_ALLOWED_SALARY_FOR_CONTRACT_EMPLOYEE = 1_000_000;
        List<Employee> _employes;
        public Organization()
        {
            _employes = new List<Employee>();
        }
        public void AddEmploye(Employee employee)
        {
            _employes.Add(employee);
        }
    }
}
