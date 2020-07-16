using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Infrastructure.Interfaces;
using UTEHY.Model.Entities;

namespace UTEHY.Infrastructure.Implementation
{
    public class RepositoryBase<T, K> : IRepositoryBase<T, K> where T : class
    {
        private FITEntities _db;
        private readonly IDbSet<T> _dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected FITEntities DbContext
        {
            get { return _db ?? (_db = DbFactory.Init()); }
        }

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }
        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _dbSet;
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items.Where(predicate);
        }

        public T FindById(K id)
        {
            return _dbSet.Find(id);
        }

        public T FindSingle(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.SingleOrDefault(predicate);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Remove(K id)
        {
            var model = FindById(id);
            _dbSet.Remove(model);
        }

        public void RemoveMultiple(List<T> entities)
        {
            foreach(var item in entities)
            {
                _dbSet.Remove(item);
            }
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }
    }
}
