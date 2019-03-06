using NTierDemo.BLL.DTOs;
using NTierDemo.BLL.Infrastructures;
using NTierDemo.BLL.Interfaces;
using NTierDemo.DAL.Entites;
using NTierDemo.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierDemo.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employees;
        public EmployeeService(IEmployeeRepository employees)
        {
            _employees = employees;
        }
        private List<EmployeeDTO> sampleEmployees = new List<EmployeeDTO>(){
               new EmployeeDTO()
               {
                   Id = 1,
                   Name = "Micheal",
                   Age = 25,
                   HiredDate = new DateTime(2015, 05, 05),
                   GrossSalary = 2500m
               },
               new EmployeeDTO()
               {
                   Id = 2,
                   Name = "Smith",
                   Age = 25,
                   HiredDate = new DateTime(2015, 05, 05),
                   GrossSalary = 2500m
               }
             };
        public ICollection<EmployeeDTO> Get()
        {
            return sampleEmployees;
        }
            public EmployeeDTO GetById(int id)
        {
            return sampleEmployees.Where(s => s.Id == id).SingleOrDefault();
        }
        public bool Add(EmployeeDTO employee)
        {
            sampleEmployees.Add(employee);
            return true;
        }
        public async Task Delete(int id)
        {
            await _employees.Delete(id);
        }
        public async Task Update(Employee employee)
        {
            await _employees.Update(employee);
        }
        public void Dispose()
        {
            _employees.Dispose();
        }
    }
}
