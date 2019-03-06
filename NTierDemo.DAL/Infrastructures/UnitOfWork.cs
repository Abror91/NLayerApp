using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierDemo.DAL.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IApplicationDbContext context)
        {
            Context = context;
        }
        public IApplicationDbContext Context { get; }
        public async Task Complete()
        {
            await Context.SaveChangesAsync();
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
