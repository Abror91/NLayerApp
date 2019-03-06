using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NTierDemo.DAL.Infrastructures
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        protected IUnitOfWork UnitOfWork { get; }
        private DbSet<T> _dbSet => UnitOfWork.Context.Set<T>();

        public async Task<ICollection<T>> Get(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbSet.ToListAsync();
            }
            return await _dbSet.Where(predicate).ToListAsync();
        }
        public async Task<T> GetById(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await _dbSet.Where(s => s.Id == id).FirstOrDefaultAsync();
        }
        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsNoTracking();
        }
        public async Task Add(T t, bool force = true)
        {
            if (t == null)
                throw new ArgumentNullException(nameof(t));
            _dbSet.Add(t);
            ChangeState(t, EntityState.Added);
            if (force)
                await SaveChanges();
        }

        public async Task Delete(T t, bool force = true)
        {
            if (t == null)
                throw new ArgumentNullException(nameof(t));
            if (!_dbSet.Local.Contains(t)) _dbSet.Attach(t);
            _dbSet.Remove(t);
            ChangeState(t, EntityState.Deleted);
            if (force)
                await SaveChanges();
        }
        public async Task Delete(int? id, bool force = true)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var entityToDelete = await FindBy(s => s.Id == id).FirstOrDefaultAsync();
            if (entityToDelete == null)
            {
                throw new NullReferenceException();
            }
            if (!_dbSet.Local.Contains(entityToDelete)) _dbSet.Attach(entityToDelete);
            _dbSet.Remove(entityToDelete);
            ChangeState(entityToDelete, EntityState.Deleted);
            if (force)
                await SaveChanges();
        }
        public async Task Update(T t, bool force = true)
        {
            if (t == null)
                throw new ArgumentNullException(nameof(t));
            _dbSet.Attach(t);
            ChangeState(t, EntityState.Modified);
            if (force)
                await SaveChanges();
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }

        public async Task SaveChanges()
        {
            await UnitOfWork.Complete();
        }

        private void ChangeState(T t, EntityState state)
        {
            UnitOfWork.Context.Entry(t).State = state;
        }
    }
}
