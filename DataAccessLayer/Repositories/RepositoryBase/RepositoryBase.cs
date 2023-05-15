using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationContext ApplicationContext { get; set; }

        public RepositoryBase(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
        }

        public IQueryable<T> FindAll() => ApplicationContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => ApplicationContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => ApplicationContext.Set<T>().Add(entity);
        public void Update(T entity) => ApplicationContext.Set<T>().Update(entity);
        public void Delete(T entity) => ApplicationContext.Set<T>().Remove(entity);


    }
}
