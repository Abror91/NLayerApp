using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NTierDemo.DAL.Infrastructures
{
    public interface IGenericRepository<T> : IDisposable where T : BaseEntity
    {
        Task<ICollection<T>> Get(Expression<Func<T, bool>> predicate = null);
        Task<T> GetById(int? id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task Add(T t, bool force = true);
        Task Delete(T t, bool force = true);
        Task Delete(int? id, bool force = true);
        Task Update(T t, bool force = true);
        Task SaveChanges();
    }
}
