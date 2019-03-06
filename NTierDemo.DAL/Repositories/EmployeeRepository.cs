using NTierDemo.DAL.Entites;
using NTierDemo.DAL.Infrastructures;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierDemo.DAL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        private DbSet<Employee> _employees => UnitOfWork.Context.Set<Employee>();

        public async Task<ICollection<Employee>> GetLastHiredEmployees()
        {
            return await _employees.OrderByDescending(s => s.HiredDate).ToListAsync();
        }
    }
}
