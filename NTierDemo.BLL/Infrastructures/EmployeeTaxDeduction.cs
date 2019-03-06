using NTierDemo.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierDemo.BLL.Infrastructures
{
    public class EmployeeTaxDeduction
    {
        public static decimal Deduce(Employee employee)
        {
            decimal salaryToReturn = 0;

            if (employee.Age < 30)
            {
                salaryToReturn = employee.GrossSalary * 0.5m;
            }
            else if (employee.Age < 40)
            {
                salaryToReturn = employee.GrossSalary * 0.60m;
            }
            else if (employee.Age < 50)
            {
                salaryToReturn = employee.GrossSalary * 0.70m;
            }
            else if (employee.Age < 60)
            {
                salaryToReturn = employee.GrossSalary * 0.80m;
            }
            else if (employee.Age >= 60)
            {
                salaryToReturn = employee.GrossSalary;
            }
            return Math.Round(salaryToReturn, 2);
        }
    }
}
