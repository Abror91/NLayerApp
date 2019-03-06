using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierDemo.DAL.Infrastructures
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationDbContext Context { get; }
        Task Complete();
    }
}
