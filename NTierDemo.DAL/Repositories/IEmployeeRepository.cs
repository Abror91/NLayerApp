using NTierDemo.DAL.Entites;
using NTierDemo.DAL.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierDemo.DAL.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<ICollection<Employee>> GetLastHiredEmployees();
    }
}
