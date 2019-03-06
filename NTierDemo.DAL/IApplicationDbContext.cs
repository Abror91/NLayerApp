using NTierDemo.DAL.Entites;
using NTierDemo.DAL.Infrastructures;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierDemo.DAL
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<Employee> Employees { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
        DbSet<T> Set<T>() where T : BaseEntity;
        DbEntityEntry<T> Entry<T>(T t) where T : BaseEntity;
    }
}
