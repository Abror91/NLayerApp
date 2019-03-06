using NTierDemo.BLL.DTOs;
using NTierDemo.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierDemo.BLL.Interfaces
{
    public interface IEmployeeService : IDisposable
    {
        ICollection<EmployeeDTO> Get();
        EmployeeDTO GetById(int id);
        bool Add(EmployeeDTO employee);
        Task Delete(int id);
        Task Update(Employee employee);
    }
}
