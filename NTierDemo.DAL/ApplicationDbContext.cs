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
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
        public new DbSet<T> Set<T>() where T : BaseEntity
        {
            return base.Set<T>();
        }
        public new DbEntityEntry<T> Entry<T>(T t) where T : BaseEntity
        {
            return base.Entry(t);
        }
    }
}
